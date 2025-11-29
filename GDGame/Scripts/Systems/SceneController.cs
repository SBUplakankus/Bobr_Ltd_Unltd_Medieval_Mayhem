using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDEngine.Core.Components;
using GDEngine.Core.Entities;
using GDEngine.Core.Services;
using GDEngine.Core.Systems;
using GDEngine.Core.Systems.Base;
using GDEngine.Core.Timing;
using Microsoft.Xna.Framework;

namespace GDGame.Scripts.Systems
{
    public class SceneController : DrawableGameComponent
    {
        #region Fields
        private Dictionary<string, Scene> _scenesDict;
        private static Scene _currentScene;
        #endregion

        #region Constructors
        public SceneController(Game game) : base (game) 
        { 
            _scenesDict = new();
        }
        #endregion

        #region Accessors
        public Scene CurrentScene => _currentScene;
        #endregion

        #region Methods
        /// <summary>
        /// Initialise the base scene of the game (Only 1 for now) 
        /// </summary>
        public void Initialise()
        {
            CreateScene(AppData.MAIN_SCENE_NAME);
            SetCurrentScene(AppData.MAIN_SCENE_NAME);
        }

        private Scene CreateScene(string name)
        {
            if (_scenesDict.TryGetValue(name, out var existing))
                return existing;

            var s = new Scene(EngineContext.Instance, name);
            _scenesDict.Add(name, s);
            return s;
        }

        private void SetCurrentScene(string name)
        {
            if (_scenesDict.TryGetValue(name, out var existing))
                _currentScene = existing;
            else
                throw new InvalidOperationException($"Scene '{name}' doest not exist.");
        }

        public static void AddToCurrentScene(GameObject go) => _currentScene.Add(go);

        public static void AddToCurrentScene(SystemBase sys) => _currentScene.Add(sys);

        public static void SetActiveCamera(Camera cam) => _currentScene.ActiveCamera = cam;

        public override void Update(GameTime gameTime)
        {
            if (!Enabled)
            {
                base.Update(gameTime);
                return;
            }

            _currentScene?.Update(Time.DeltaTimeSecs);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (!Visible)
            {
                base.Draw(gameTime);
                return;
            }

            _currentScene?.Draw(Time.DeltaTimeSecs);

            base.Draw(gameTime);
        }

        #endregion
    }
}
