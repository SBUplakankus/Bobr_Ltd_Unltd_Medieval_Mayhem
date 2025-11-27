# 📝 Game Documentation

A place for nots on any classes created for our game in the engine.

---

## ⚙️ Custom Systems

### 🔉Audio Controller
- Created in `Main`
- Encapsulates functions for playing audio to clear up main
- Takes in the Sounds Dictionary when constructed

### 🔊 3D Audio Controller
- Created in `AudioController` and attached to a `GameObject`
- Takes in a sound effect, spawn position, volume and radius
- Plays 3D Audio in the Game Scene

### ⛰️ Scene Controller
- Created in `Main`
- Stores the current scene and any new ones created
- `_scene` in `Main` is gotten from `SceneController.CurrentScene`

### 🏡 Scene Generator
- Created in `Main`
- Generates the Skybox and Ground

### 🗽 Model Generator
- Created in `Main`
- Returns created Models

### 💻 User Interface Controller
- Created in `Main`
- Takes in the Fonts and 2D Textures on construction

### 🎮 Input Manager
- Created in `Main`
- Creates the Input System based off of the given settings
- Sends out events through the `InputEventChannel`

### 🖌️ Material Generator
- Created in `Main`
- Generates the Lit, Unlit and UnlitGround Materials

### 🕐 Time Controller
- Created in `Main`
- Controls the `Time.TimeScale` which pauses and unpauses the game

### 🌍 Localisation Controller
- Initialised in `Main`
- Creates Dictionaries for each language option
- English is used as the key and fallback option
- Options are stored in `.csv` files in the `Languages` folder
- When accessing text to display in game, you use `LocalisationController.Get("text")`

---

## ⚙️ Player Systems

### 🕹️ Player Controller
- Created in `Main`
- Stores the `PlayerMovement` and `PlayerCamera` logic

### 🎥 Player Camera
- Created in `PlayerController`
- Handles the first person perspective logic

### 🚶 Player Movement
- Created in `PlayerController`
- Handles the physics based player movement

---

## 🖥️ User Interface Systems

### 🖱️ Cursor Controller
- Created in `Main`
- Creates the Reticle in in the middle of the screen.
- Loads the texture named `reticle` from the JSON

---

## 🎮 Game Systems

### ⚙️ Trap Manager
- Created in `Main`
- Creates a list of `TrapBase` to add to the scene
- Initialises all of the traps
- Updates the list of traps each frame

### 🏹 Trap Base
- Base abstract class all traps inherit from
- Holds the trap `GameObject` and core abstract functions all traps need

### 🪓 Moving Trap
- Inherits from `TrapBase`
- Holds the logic for a moving trap such as platforms or axes

---

## 🛥️ Event Systems

### ⛵ Event Base
- Uses C# `event Action` as a base
- Uses `Subscribe` to add a listener to the event
- Uses `Unsubscribe` to remove a listener from the event
- Uses `Raise` to call the event

### 🕹️ Input Event Channel
- Created in `EventChannelManager`
- Events created from `EventBase`
- Controls Fullscreen Toggle, Pause Toggle, Movement and Exit Events

### 🧔 Player Event Channel
- Created in `EventChannelManager`
- Events created from `EventBase`
- Controls Game Over and Game Won events

### 🧰 Event Channel Manager
- Static Class that can be accessed anywhere
- Initialised in `Main`
- Creates a `PlayerEventChannel` and `InputEventChannel`

---
