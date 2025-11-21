# 📝 Development Notes & Tips

A shared place for quick notes, how-tos, reminders, and useful information discovered during development.

---

## 📌 Quick Tips

- Be careful when editing main, try to avoid it as much as possible to prevent conflicts. 
- Make sure all of our content is loaded into the dictonaries at the top of main. 
- To update the engine, copy over the **GDEngine** folder to the repo only.

---

## 🛠️ How-To Guides

### ✔️ Importing Models
Steps:

1. Open content.mcgb in Visual Studio
2. Click into Assets -> Models
3. With Models selected, click on Add Existing Item at the top *(Grey Box with Black Border and Green + Sign)*
4. Select the .fbx file
5. Click Build -> Build after it is successfully added
6. Re-open Visual Studio
7. Go to Content -> Assets -> Data and open `asset_manifest.json`
8. Create a new entry in the models section
9. Give it a name to be referenced by in the model dictionary
10. Insert the path to the model
11. Create through `multi_model_spawn.json` or individually in main

### ✔️ Importing Textures
Steps:

1. Open content.mcgb in Visual Studio
2. Click into Assets -> Textures
3. With Textures selected, click on Add Existing Item at the top *(Grey Box with Black Border and Green + Sign)*
4. Select the texture file
5. Click Build -> Build after it is successfully added
6. Re-open Visual Studio
7. Go to Content -> Assets -> Data and open `asset_manifest.json`
8. Create a new entry in the textures section
9. Give it a name to be referenced by in the texture dictionary
10. Insert the path to the texture
11. When creating models, assign it this texture name

---

## 🧩 Common Problems & Fixes

### ❗ Problem: Model has no Texture 
**Fix:**  Load texture to dictionary and apply through code

---

## 📁 Project Workflow Notes

-  Engine is very basic, keep things simple.
-  Don't worry about lighting or animations at the moment.
-  Keep this updated as we progress.

---
