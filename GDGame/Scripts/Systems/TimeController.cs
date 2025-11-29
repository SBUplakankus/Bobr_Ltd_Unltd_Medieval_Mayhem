using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDEngine.Core.Timing;
using GDGame.Scripts.Events.Channels;

namespace GDGame.Scripts.Systems
{
    public class TimeController
    {
        #region Fields
        private bool _isPlaying;
        #endregion

        #region Constructors
        public TimeController() 
        {
            _isPlaying = true;
            Time.TimeScale = 1.0f;
            EventChannelManager.Instance.InputEvents.PauseToggle.Subscribe(TogglePause);
        }
        #endregion

        #region Methods
        public void TogglePause()
        {
            if (_isPlaying)
                Time.TimeScale = 0;
            else
                Time.TimeScale = 1;

            _isPlaying = !_isPlaying;
        }
        #endregion
    }
}
