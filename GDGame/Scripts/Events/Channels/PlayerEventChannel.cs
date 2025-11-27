using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGame.Scripts.Events.Channels
{
    public class PlayerEventChannel
    {
        public EventBase PlayerLose = new();
        public EventBase PlayerWin = new();

        /// <summary>
        /// Unsubscribe from all events in the Channel
        /// </summary>
        public void ClearEventChannel()
        {
            PlayerLose.UnsubscribeAll();
            PlayerWin.UnsubscribeAll();
        }
    }
}
