using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDEngine.Core.Collections;
using GDEngine.Core.Components;
using GDEngine.Core.Entities;
using GDEngine.Core.Enums;
using GDEngine.Core.Rendering.UI;
using GDEngine.Core.Systems.Base;
using GDGame.Scripts.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GDGame.Scripts.Systems
{
    public class UserInterfaceController : SystemBase
    {
        #region Fields
        private SpriteBatch _spriteBatch;
        private ContentDictionary<SpriteFont> _fonts;
        private ContentDictionary<Texture2D> _interfaceTextures;
        private CursorController _cursorController;
        private List<GameObject> _uiObjects;
        #endregion

        #region Constructors
        public UserInterfaceController(SpriteBatch batch, 
            ContentDictionary<SpriteFont> fonts, ContentDictionary<Texture2D> textures) : 
            base(FrameLifecycle.PostRender, order: 10)
        {
            _spriteBatch = batch;
            _fonts = fonts;
            _interfaceTextures = textures;
        }
        #endregion

        #region Accessors
        public List<GameObject> UIObjects 
        { 
            get 
            {
                _uiObjects ??= [];

                return _uiObjects;
            } 
        }

        #endregion

        #region Methods
        private void InitCursor()
        {
            _cursorController = new CursorController(_interfaceTextures.Get(AppData.RETICLE_NAME));
            _uiObjects = [_cursorController.Reticle];
        }

        private void InitText()
        {
            var textGO = new GameObject("TextTest");
            var uiText = new UIText();
            uiText.Color = Color.White;
            uiText.TextProvider = () => LocalisationController.Instance.Get("Play");
            uiText.PositionProvider = () => new Vector2(200, 200);
            uiText.Font = _fonts.Get("menufont");
            uiText.LayerDepth = UILayer.HUD;
            textGO.AddComponent(uiText);
            SceneController.AddToCurrentScene(textGO);
        }

        private void DisplayText()
        {
            
        }

        private void AddObjectsToScene()
        {
            foreach (var obj in _uiObjects)
                SceneController.AddToCurrentScene(obj);
        }

        public void Initialise()
        {
            InitCursor();
            InitText();
            AddObjectsToScene();
        }

        public override void Draw(float deltaTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.End();
        }
        #endregion
    }
}
