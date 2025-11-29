using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using GDEngine.Core.Components;
using GDEngine.Core.Entities;

namespace GDGame.Scripts.Systems
{
    public class CinematicCamController : Component
    {
        #region Fields
        private GameObject _cineCamGO;
        private Camera _camera;
        private Vector3 _startPos = new (8,8,8);
        private Vector3 _endPos = new (18, 5, 18);
        private bool _isActive;
        private readonly float _duration = 5f;
        private float _counter = 0f;
        private float _cameraFOV = 0.9f;
        private const int FAR_PLANE_LIMIT = 1000;
        #endregion

        #region Constructors
        public CinematicCamController()
        {
            _cineCamGO = new GameObject("CineCam");
            _cineCamGO.AddComponent(this);
            _camera = _cineCamGO.AddComponent<Camera>();
            _camera.FarPlane = FAR_PLANE_LIMIT;
            _camera.AspectRatio = 0.5f;
            _camera.FieldOfView = _cameraFOV;
        }
        #endregion

        #region Methods
        public void Initialise()
        {
            SceneController.AddToCurrentScene(_cineCamGO);
            SceneController.SetActiveCamera(_camera);
            _cineCamGO.Transform.TranslateTo(_startPos);
            _isActive = true;
        }

        protected override void Update(float deltaTime)
        {
            Debug.WriteLine("Hi");
            if (!_isActive) return;

            if(_counter < _duration)
            {
                _counter += deltaTime;
                float t = Math.Clamp(_counter / _duration, 0f, 1f);
                Debug.WriteLine(t);

                _cineCamGO.Transform.TranslateTo(Vector3.Lerp(_startPos, _endPos, t));
            }
            else
            {
                _isActive = false;
                SceneController.SetActiveCamera(AppData.PLAYER_NAME);
            }

            base.Update(deltaTime);
        }
        #endregion
    }
}
