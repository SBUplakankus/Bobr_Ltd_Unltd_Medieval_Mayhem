using GDEngine.Core.Components;
using GDEngine.Core.Entities;
using Microsoft.Xna.Framework;

namespace GDGame.Scripts.Player
{
    public class PlayerMovement
    {
        #region Fields
        private float _moveSpeed = 1f;
        private RigidBody _rb;
        private SphereCollider _collider;
        private GameObject _playerParent;
        #endregion

        #region Constructors
        public PlayerMovement(GameObject parent)
        {
            _playerParent = parent;

            _collider = new SphereCollider();
            _collider.Diameter = Vector3.One.Length();
            _playerParent.AddComponent(_collider);

            _rb = new RigidBody();
            _rb.BodyType = BodyType.Dynamic;
            _rb.Mass = 1f;
            _playerParent.AddComponent(_rb);

            // parent.AddComponent<KeyboardWASDController>();
        }
        #endregion

        #region Methods
        public void HandleMovement()
        {

        }
        #endregion
    }
}
