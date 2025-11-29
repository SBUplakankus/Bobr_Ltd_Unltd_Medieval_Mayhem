using System.Collections.Generic;
using GDEngine.Core.Components;

namespace GDGame.Scripts.Traps
{
    public class TrapManager : Component
    {
        #region Fields
        private List<TrapBase> _trapList;
        #endregion

        #region Constructor
        public TrapManager() 
        {
            _trapList = new List<TrapBase>();
            _trapList.Add(new MovingTrap(1,5));
        }
        #endregion

        #region Accessors
        public List<TrapBase> TrapList => _trapList;
        #endregion

        #region Game Methods
        private void InitTraps()
        {
            if (_trapList.Count == 0) return;

            foreach (var trap in _trapList)
            {
                trap.InitTrap();
            }
                
        }
        private void UpdateTraps()
        {
            if(_trapList.Count == 0) return;

            foreach(var trap in _trapList)
                trap.UpdateTrap();
        }
        #endregion

        #region Engine Methods
        protected override void Start()
        {
            InitTraps();
        }
        protected override void Update(float deltaTime)
        {
            UpdateTraps();
        }
        #endregion
    }
}
