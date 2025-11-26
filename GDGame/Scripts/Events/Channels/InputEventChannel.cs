using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGame.Scripts.Events.Channels
{
    public class InputEventChannel
    {
        public EventBase FullscreenToggle = new();
        public EventBase PauseToggle = new();
        public EventBase ApplicationExit = new();
        public EventBase<int> MovementInput = new();

        /// <summary>
        /// Unsubscribe from all events in the Channel
        /// </summary>
        public void ClearEventChannel()
        {
            FullscreenToggle.UnsubscribeAll();
            PauseToggle.UnsubscribeAll();
            ApplicationExit.UnsubscribeAll();
            MovementInput.UnsubscribeAll();
        }
    }
}
