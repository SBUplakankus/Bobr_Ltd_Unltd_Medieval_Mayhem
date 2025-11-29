using GDEngine.Core.Entities;
using GDGame.Scripts.Systems;

namespace GDGame.Scripts.Traps
    {
        public abstract class TrapBase
        {
            #region Fields
            private GameObject _trapGO;
            private int _trapID;
            #endregion

            #region Constructors
            public TrapBase(int id)
            {
                _trapID = id;
                _trapGO = new GameObject(AppData.TRAP_NAME + _trapID);
                SceneController.AddToCurrentScene(_trapGO);
            }
            #endregion

            #region Accessors
            public GameObject TrapGO => _trapGO;
            #endregion

            #region Methods
            public abstract void InitTrap();
            public abstract void UpdateTrap();
            public abstract void HandlePlayerHit();
            #endregion
        }
    }
