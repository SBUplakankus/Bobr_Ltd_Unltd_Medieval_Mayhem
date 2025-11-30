using GDGame.Scripts.Systems;

namespace GDGame.Scripts.Events.Channels
{
    public class PlayerEventChannel
    {
        public EventBase PlayerLose = new();
        public EventBase PlayerWin = new();
        public EventBase<GameState> GameStateChange = new();

        /// <summary>
        /// Unsubscribe from all events in the Channel
        /// </summary>
        public void ClearEventChannel()
        {
            PlayerLose.UnsubscribeAll();
            PlayerWin.UnsubscribeAll();
            GameStateChange.UnsubscribeAll();
        }
    }
}
