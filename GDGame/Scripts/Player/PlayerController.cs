using System.Numerics;
using GDEngine.Core.Components;
using GDEngine.Core.Entities;
using GDGame.Scripts.Audio;
using GDGame.Scripts.Events.Channels;
using GDGame.Scripts.Systems;

namespace GDGame.Scripts.Player
{
    /// <summary>
    /// Controls the player.
    /// Uses <see cref="PlayerCamera"/> and <see cref="PlayerMovement"/>.
    /// </summary>
    public class PlayerController : Component
    {
        #region Fields
        private GameObject _playerGO;
        private PlayerMovement _playerMovement;
        private PlayerCamera _playerCamera;
        private Vector3 _startPos = new (0, 0, 0);
        private Vector3 _startRot = new (0, 0, 0);
        #endregion

        #region Constructors
        public PlayerController(float aspectRatio, AudioController audio) 
        {
            _playerGO = new GameObject(AppData.PLAYER_NAME);

            _playerCamera = new PlayerCamera(_playerGO, aspectRatio);
            _playerMovement = new PlayerMovement(_playerGO);

            _playerGO.AddComponent(this);
            _playerGO.AddComponent(audio);

            _playerGO.Transform.TranslateTo(_startPos);
            _playerGO.Transform.RotateEulerBy(_startRot);

            SceneController.AddToCurrentScene(_playerGO);
        }
        #endregion

        #region Accessors
        public GameObject PlayerGO => _playerGO;
        public Camera PlayerCam => _playerCamera.Cam;
        #endregion

        #region EventHandlers
        #endregion

        #region Methods
        protected override void Awake()
        {
            // EventChannelManager.Instance.InputEvents.MovementInput.Subscribe(_playerMovement.HandleMovement);
            base.Awake();
        }
        #endregion
    }
}
