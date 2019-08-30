using System;
using System.Threading.Tasks;

namespace LazyConditions
{
    public class LazyTask<T>
    {
        private readonly Lazy<Task<T>> _task;

        public LazyTask(Func<Task<T>> func)
        {
            _task = new Lazy<Task<T>>(func);
        }

        public static LazyTask<T> Create(Func<Task<T>> func) => new LazyTask<T>(func);

        public Lazy<Task<T>> Get() => _task;

        public Task Execute()
        {
            return _task.Value;
        }
        public Task ExecuteIfValueIsNotCreated()
        {
            if (_task.IsValueCreated)
                return Task.CompletedTask;
            else
                return _task.Value;
        }
    }
}
