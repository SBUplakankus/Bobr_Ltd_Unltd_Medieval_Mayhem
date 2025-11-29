using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDEngine.Core.Entities;
using GDEngine.Core.Rendering.UI;
using GDGame.Scripts.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GDGame.Scripts.UI
{
    public class PlayerHUD
    {
        #region Fields
        private SpriteFont _hudFont;
        private Color _hudTextColour = Color.White;
        #endregion

        #region Constructors
        public PlayerHUD(SpriteFont hudFont)
        {
            _hudFont = hudFont;
        }
        #endregion

        #region Methods
        private void CreateText(string key, Vector2 pos)
        {
            var textGO = new GameObject($"Text Object: {key}");
            var uiText = new UIText
            {
                Color = _hudTextColour,
                Font = _hudFont,
                LayerDepth = UILayer.HUD,
                TextProvider = () => LocalisationController.Instance.Get(key),
                PositionProvider = () => pos
            };

            textGO.AddComponent(uiText);
            SceneController.AddToCurrentScene(textGO);
        }

        private void InitHUDText()
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
            InitHUDText();
        }
        #endregion
    }
}
