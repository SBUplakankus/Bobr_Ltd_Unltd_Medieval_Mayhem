using GDEngine.Core.Components;
using GDEngine.Core.Entities;
using GDGame.Scripts.Systems;
using Microsoft.Xna.Framework;
using System;

namespace GDGame.Scripts.Traps
{
    /// <summary>
    /// Moving Obstacle Trap which inherits from <see cref="TrapBase"/>.
    /// </summary>
    public class RotatingTrap : TrapBase
    {
        #region Fields
        private float _rotSpeed = 5f;
        private float _endAngle = 60f;
        private float _currentAngle = 0f;
        private bool _rotatingClockwise = true;
        #endregion

        #region Constructors
        public RotatingTrap(int id, Vector3 position, Vector3 rotation, Vector3 scale, string textureName, string modelName, string objectName, float rotSpeed) : base(id)
        {
            //_trapGO = ModelGenerator.Instance.GenerateCube(
            //    new Vector3(-3, 5, 0),
            //    Vector3.Zero,
            //    new Vector3(0.5f, 0.5f, 0.5f),
            //    "ground_grass",
            //    AppData.TRAP_NAME + id);

            //_trapGO = ModelGenerator.Instance.GenerateModel(
            //    new Vector3(3.4f, 5.2f, 0.2f), Vector3.Zero, new Vector3(3,3,3),
            //    "Guilitinne_openPBR_shader1_BaseColor",
            //    "Guilitinne_final",
            //    AppData.TRAP_NAME + id);

            _trapGO = ModelGenerator.Instance.GenerateModel(
                position,
                rotation,
                scale,
                textureName,
                modelName,
                objectName + id);

            _trapGO.AddComponent<BoxCollider>();

            SceneController.AddToCurrentScene(_trapGO);
            //SceneController.AddToCurrentScene(_trapModelGO);


            // Make sure parent has no scale applied
            _trapGO.Transform.ScaleTo(Vector3.One);

            _rotSpeed = rotSpeed;
        }
        #endregion

        #region Methods
        //public override void UpdateTrap()
        //{
        //    _trapGO.Transform.RotateBy(Quaternion.CreateFromAxisAngle(Vector3.Forward, MathHelper.ToRadians(_rotSpeed)));
        //    if (_rotatingClockwise)
        //    {
        //        _currentAngle++;
        //    }
        //    else
        //    {
        //        _currentAngle--;
        //    }

        //    if (_currentAngle >= _endAngle)
        //    {
        //        _rotatingClockwise = false;
        //        flip();
        //    }
        //    if (_currentAngle <= _startAngle)
        //    {
        //        _rotatingClockwise = true;
        //        flip();
        //    }


        //}

        public override void UpdateTrap()
        {
            float Lerp(float a, float b, float t) => a + (b - a) * t;

            float baseRad = MathHelper.ToRadians(_rotSpeed);

            float distFromCenter = MathF.Abs(_currentAngle) / 60f;
            distFromCenter = Math.Clamp(distFromCenter, 0f, 1f);

            float easing = (1f + MathF.Cos(distFromCenter * MathF.PI)) * 0.5f;
            float easedMul = Lerp(0.2f, 1f, easing);

            float finalRot = baseRad * easedMul;
            float degChange = MathHelper.ToDegrees(finalRot);

            if (_rotatingClockwise)
                _currentAngle += degChange;
            else
                _currentAngle -= degChange;

            if (_currentAngle >= _endAngle)
            {
                _currentAngle = _endAngle;
                _rotatingClockwise = false;
                flip();
            }
            else if (_currentAngle <= -_endAngle)
            {
                _currentAngle = -_endAngle;
                _rotatingClockwise = true;
                flip();
            }

            _trapGO.Transform.RotateBy(
                Quaternion.CreateFromAxisAngle(
                    Vector3.Forward,
                    finalRot * (_rotatingClockwise ? 1f : -1f)
                )
            );
        }

        public override void InitTrap()
        {
            
        }

        public override void HandlePlayerHit()
        {
            throw new NotImplementedException();
        }
        #endregion

        public void flip()
        {
            _rotSpeed = -_rotSpeed;
        }
    }
}
