using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGame.Scripts.Events.Channels
{
    public class EventBaseList
    {
        private readonly List<EventBase> _events;

        public EventBaseList(List<EventBase> events)
        {
            _events = events;
        }

        public void ClearList()
        {
            foreach(var e in _events)
                e.UnsubscribeAll();

            _events.Clear();
        }
    }
}
