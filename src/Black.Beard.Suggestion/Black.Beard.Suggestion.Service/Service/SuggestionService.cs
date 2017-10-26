using Bb.Sdk;
using Bb.Suggestion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Suggestion.Service
{

    public class SuggestionService<TEntities> : ISuggestionService<TEntities>
        where TEntities : ISuggerableModel
    {

        public SuggestionService(RuleRepository<TEntities> ruleRepository, ISourceResolver sourceResolver)
        {

            if (ruleRepository == null)
                throw new ArgumentNullException(nameof(ruleRepository));

            if (sourceResolver == null)
                throw new ArgumentNullException(nameof(sourceResolver));

            this.ruleRepository = ruleRepository;
            this.sourceResolver = sourceResolver;

        }

        public ServiceResponse<TEntities> Resolve(ServiceRequest request)
        {

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            ServiceResponse<TEntities> result = new ServiceResponse<TEntities>();

            IFunctionResolver<TEntities> functionResolver = new FonctionResolver<TEntities>(this.ruleRepository);
            functionResolver.Initialize(request);
            IEnumerable<TEntities> source = sourceResolver.Resolve<TEntities>(request);

            Resolve(functionResolver, source, result);            

            return result;

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Resolve(IFunctionResolver<TEntities> functionResolver, IEnumerable<TEntities> source, ServiceResponse<TEntities> result)
        {

            Func<TEntities, bool> fnc = functionResolver.Filter;
            int maxDistance = functionResolver.MaxDistance;
            IPoint origin = functionResolver.Origin;
            bool testDistance = maxDistance > 0;
            List<TEntities> _lst = new List<TEntities>();

            List<Task> _tasks = new List<Task>();
            foreach (var item in source)
            {
                var t = Task.Factory.StartNew(() =>
                {
                    if (fnc(item))
                    {

                        double distance;
                        if (testDistance)
                        {
                            distance = DistanceCalulator.DistanceInMeters(origin.Y, origin.X, item.Location.Y, item.Location.X);
                            if (distance > maxDistance)
                                return;
                        }
                        else
                            distance = 0;

                        var s = new SuggestionResult<TEntities>() { Poi = item, Distance = distance };

                        result.Add(s);

                    }
                });

                _tasks.Add(t);

            }

            Task.WaitAll(_tasks.ToArray());

            //result.AddRange(_lst.OrderBy(functionResolver.KeySelector));
            //// Func<TSource, TKey> keySelector

        }

        private readonly RuleRepository<TEntities> ruleRepository;
        private readonly ISourceResolver sourceResolver;

    }

}
