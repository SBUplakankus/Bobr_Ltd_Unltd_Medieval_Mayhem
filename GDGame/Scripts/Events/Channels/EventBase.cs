using System;

namespace GDGame.Scripts.Events.Channels
{
    public class EventBase
    {
        private event Action Handlers;

        public void Raise() => Handlers?.Invoke();
        public void Subscribe(Action a) => Handlers += a;
        public void Unsubscribe(Action a) => Handlers -= a;
        public void UnsubscribeAll() => Handlers = null;
    }

    public class EventBase<T>
    {
        private event Action<T> Handlers;
        public void Raise(T var) => Handlers?.Invoke(var);
        public void Subscribe(Action<T> a) => Handlers += a;
        public void Unsubscribe(Action<T> a) => Handlers -= a;
        public void UnsubscribeAll() => Handlers = null;
    }
}
