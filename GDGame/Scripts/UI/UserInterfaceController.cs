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

        #region Methods
        private void InitCursor()
        {
            _cursorController = new CursorController(_interfaceTextures.Get(AppData.RETICLE_NAME));
            SceneController.AddToCurrentScene(_cursorController.Reticle);
        }

        private void CreateText(string key, Vector2 pos)
        {
            var textGO = new GameObject($"Text Object: {key}");
            var uiText = new UIText
            {
                Color = Color.White,
                Font = _fonts.Get("gamefont"),
                LayerDepth = UILayer.HUD,
                TextProvider = () => LocalisationController.Instance.Get(key),
                PositionProvider = () => pos
            };

            textGO.AddComponent(uiText);
            SceneController.AddToCurrentScene(textGO);
        }

        private void InitText()
        {
            var startPos = new Vector2(200, 200);
            var increment = new Vector2(0, 50);
            CreateText("Play", startPos);
            CreateText("Pause", startPos += increment);
            CreateText("GameOver", startPos += increment);
            CreateText("Victory", startPos += increment);
            CreateText("Score", startPos += increment);
        }

        public void Initialise()
        {
            InitCursor();
            InitText();
        }

        public override void Draw(float deltaTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.End();
        }
        #endregion
    }
}
