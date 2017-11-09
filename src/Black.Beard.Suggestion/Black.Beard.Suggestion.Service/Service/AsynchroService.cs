using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Service
{

    public class AsynchroService
    {

        public AsynchroService()
        {

            this._actions = new System.Collections.Concurrent.ConcurrentQueue<Action[]>();

        }

        public void Add(Action[] actions)
        {

                this._actions.Enqueue(actions);

            Run();

        }

        private void Run()
        {
            if (!_running)
                lock (_lock)
                    if (!_running)
                    {
                        _running = true;
                        Task.Run(() =>
                        {
                            Consume();
                            _running = false;
                        });
                    }

        }

        private void Consume()
        {

            Action[] actions;
            while (this._actions.TryDequeue(out actions))
            {
                
                try
                {
                    foreach (Action action in actions)
                        action();
                }
                catch (Exception e)
                {
                    this._actions.Enqueue(actions);
                }

            }

        }

        public bool IsEmpty
        {
            get
            {
                return this._actions.Count == 0 && !this._running;
            }
        }

        private volatile object _lock = new object();
        private volatile bool _running;
        private readonly ConcurrentQueue<Action[]> _actions;

    }

}
