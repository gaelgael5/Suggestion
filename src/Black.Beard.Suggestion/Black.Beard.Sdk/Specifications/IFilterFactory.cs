using System;

namespace Bb.Specifications
{
    public interface IFilterFactory<TEntity> where TEntity : ISuggerableModel
    {
        Func<TEntity, bool> Build(QueryContext<TEntity> context);

    }
}