using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGame.Scripts.Events.Channels
{
    public class InputEventChannel
    {
        public InputEventChannel() { }

        private event Action OnFullscreenToggleRequested;
        private event Action OnPauseToggleRequested;
        private event Action OnApplicationExitRequested;

        #region Requests
        public void RaiseFullscreenToggleRequest() => OnFullscreenToggleRequested?.Invoke();
        public void RaisePauseToggleRequest() => OnPauseToggleRequested?.Invoke();
        public void RaiseApplicationExitRequest() => OnApplicationExitRequested?.Invoke();
        #endregion

        #region Subsribers
        public void SubscribeToFullscreenToggle(Action action) => OnFullscreenToggleRequested += action;
        public void UnsubscribeToFullscreenToggle(Action action) => OnFullscreenToggleRequested -= action;
        public void SubscribeToPauseToggle(Action action) => OnPauseToggleRequested += action;
        public void UnsubscribeToPauseToggle(Action action) => OnPauseToggleRequested -= action;
        public void SubscribeToExitRequest(Action action) => OnApplicationExitRequested += action;
        public void UnsubscribeToExitRequest(Action action) => OnApplicationExitRequested -= action;
        #endregion
    }
}
