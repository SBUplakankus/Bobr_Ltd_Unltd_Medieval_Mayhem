using GDEngine.Core.Components;
using GDEngine.Core.Entities;
using Microsoft.Xna.Framework;

namespace GDGame.Scripts.Player
{
    /// <summary>
    /// Controls the player camera movement.
    /// Created in <see cref="PlayerController"/>.
    /// </summary>
    public class PlayerCamera : Component
    {
        #region Fields
        private Camera _camera;
        private float _cameraFOV = 0.9f;
        private const int FAR_PLANE_LIMIT = 1000;
        #endregion

        #region Constructors
        public PlayerCamera(float aspectRatio)
        {
            _camera = new()
            {
                FarPlane = FAR_PLANE_LIMIT,
                AspectRatio = aspectRatio,
                FieldOfView = _cameraFOV
            };
        }
        #endregion

        #region Accessors
        public Camera Cam => _camera;
        #endregion

        #region Methods

        #endregion

    }
}
