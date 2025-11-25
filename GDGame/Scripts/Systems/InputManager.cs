using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDEngine.Core.Components;
using GDEngine.Core.Entities;
using GDEngine.Core.Input.Data;
using GDEngine.Core.Input.Devices;
using GDEngine.Core.Orchestration;
using GDEngine.Core.Services;
using GDEngine.Core.Systems;
using GDEngine.Core.Systems.Base;
using GDGame.Scripts.Events.Channels;
using GDGame.Scripts.Events.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GDGame.Scripts.Systems
{
    public class InputManager : Component
    {
        #region Fields
        private InputEventChannel _inputEventChannel;
        private InputSystem _inputSystem;
        private KeyboardState _newKBState, _oldKBState;
        private float _mouseSensitivity = 0.12f;
        private int _debounceMs = 60;
        private bool _enableKeyRepeat = true;
        private int _keyRepeatMs = 300;
        #endregion

        #region Input Keys
        private Keys _pauseKey = Keys.Escape;
        private Keys _fullscreenKey = Keys.F11;
        private Keys _exitKey = Keys.E;
        #endregion

        #region Constructors
        public InputManager() 
        {
            var bindings = InputBindings.Default;

            // Set Inititial Parameters
            bindings.MouseSensitivity = _mouseSensitivity;  
            bindings.DebounceMs = _debounceMs;          
            bindings.EnableKeyRepeat = _enableKeyRepeat;   
            bindings.KeyRepeatMs = _keyRepeatMs;       

            _inputSystem = new InputSystem();

            // Register Devices
            _inputSystem.Add(new GDKeyboardInput(bindings));
            _inputSystem.Add(new GDMouseInput(bindings));
            _inputSystem.Add(new GDGamepadInput(PlayerIndex.One, AppData.GAMEPAD_P1_NAME));

            _inputEventChannel = new InputEventChannel();
        }
        #endregion

        #region Accessors
        public InputSystem Input => _inputSystem;
        public InputEventChannel InputEventChannel => _inputEventChannel;
        #endregion

        #region Input Methods
        private void CheckForPause()
        {
            bool isPressed = _newKBState.IsKeyDown(_pauseKey) && !_oldKBState.IsKeyDown(_pauseKey);
            if (!isPressed) return;

            _inputEventChannel.RaisePauseToggleRequest();    
        }

        private void CheckForFullscreen()
        {
            bool isPressed = _newKBState.IsKeyDown(_fullscreenKey) && !_oldKBState.IsKeyDown(_fullscreenKey);
            if (!isPressed) return;

            _inputEventChannel.RaiseFullscreenToggleRequest();
        }

        private void CheckForExit()
        {
            bool isPressed = _newKBState.IsKeyDown(_exitKey) && !_oldKBState.IsKeyDown(_exitKey);
            if (!isPressed) return;

            _inputEventChannel.RaiseApplicationExitRequest();
        }
        
        private void CheckForInputs()
        {
            CheckForPause();
            CheckForFullscreen();
            CheckForExit();
        }
        #endregion

        #region Engine Methods
        protected override void Update(float deltaTime)
        {
            _newKBState = Keyboard.GetState();
            CheckForInputs();
            _oldKBState = _newKBState;

            base.Update(deltaTime);
        }
        #endregion
    }
}
