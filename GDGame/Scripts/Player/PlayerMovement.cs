using GDEngine.Core.Components;
using GDEngine.Core.Entities;
using GDEngine.Core.Timing;
using Microsoft.Xna.Framework;

namespace GDGame.Scripts.Player
{
    public class PlayerMovement
    {
        #region Fields
        private float _moveSpeed = 20f;
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
            _rb.AngularDamping = 1;
            _rb.LinearDamping = 1;
            _playerParent.AddComponent(_rb);

            // parent.AddComponent<KeyboardWASDController>();
        }
        #endregion

        #region Methods
        private void Move(Vector3 dir)
        {
            dir.Normalize();
            Vector3 delta = dir * _moveSpeed;
            _rb.AddForce(delta);
        }
        public void HandleMovement(int dir)
        {
            var forward = _rb.Transform.Forward;
            var right = _rb.Transform.Right;

            forward.Y = 0;
            right.Y = 0;

            var moveDir = Vector3.Zero;

            if (dir == 0)
                moveDir += forward;

            if(dir == 1)
                moveDir -= forward;

            if (dir == 2)
                moveDir -= right;

            if(dir == 3)
                moveDir += right;

            if(moveDir.LengthSquared() == 0) return;

            Move(moveDir);
        }
        #endregion
    }
}
