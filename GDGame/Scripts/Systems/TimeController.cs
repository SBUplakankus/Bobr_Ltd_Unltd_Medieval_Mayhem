using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDEngine.Core.Timing;

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
