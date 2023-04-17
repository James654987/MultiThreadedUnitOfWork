using System;
using System.Collections.Generic;

namespace MultiThreadedUnitOfWork.RequestStates
{
    public class PerThreadRequestState : IRequestState
    {
        [ThreadStatic]
        private static IDictionary<string, object> _state;
        
        private static IDictionary<string, object> State => _state ?? (_state = new Dictionary<string, object>());

        public void Store<T>(T something)
        {
            lock (State)
            {
                State[typeof(T).FullName] = something;
            }
        }
        
        public T Get<T>()
        {
            lock (State)
            {
                if (State.TryGetValue(typeof(T).FullName, out var state)) 
                    return (T)state;

                return default;
            }
        }
    }
}