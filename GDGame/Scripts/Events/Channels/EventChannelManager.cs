using System;

namespace GDGame.Scripts.Events.Channels
{
    public class EventChannelManager
    {
        // Instance
        private static EventChannelManager _instance;

        // Channels
        private readonly InputEventChannel _inputEvents;
        private readonly PlayerEventChannel _playerEvents;

        public EventChannelManager() 
        {
            _inputEvents = new InputEventChannel();
            _playerEvents = new PlayerEventChannel();
        }

        #region Accessors
        public static EventChannelManager Instance
        {
            get
            {
                if (_instance == null)
                    throw new InvalidOperationException("Ensure you call Initialise() first");

                return _instance;
            }
        }
        public InputEventChannel InputEvents => _inputEvents;
        public PlayerEventChannel PlayerEvents => _playerEvents;
        #endregion

        #region Methods
        public static void Initialise()
        {
            if(_instance != null) return;

            _instance = new EventChannelManager();
        }

        #endregion
    }
}
