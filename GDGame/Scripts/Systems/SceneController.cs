using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDEngine.Core.Entities;
using GDEngine.Core.Services;
using GDEngine.Core.Systems;
using Microsoft.Xna.Framework;

namespace GDGame.Scripts.Systems
{
    public class SceneController : DrawableGameComponent
    {
        #region Fields
        private List<Scene> _scenes;
        private Scene _currentScene;
        #endregion

        #region Constructors
        public SceneController(Game game) : base (game) 
        { 
            InitBaseScene();
        }
        #endregion

        #region Accessors
        public Scene CurrentScene { get { return _currentScene; } }
        #endregion

        #region Methods
        /// <summary>
        /// Initialise the base scene of the game (Only 1 for now) 
        /// </summary>
        public void InitBaseScene()
        {
            _scenes = [new Scene(EngineContext.Instance, AppData.MAIN_SCENE_NAME)];
            _currentScene = _scenes[0];
            _currentScene.Name = AppData.MAIN_SCENE_NAME;
        }


        #endregion
    }
}
