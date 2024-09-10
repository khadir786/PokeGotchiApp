# PokeGotchiApp
PokeGotchi is a standalone WebAssembly app made with Blazor. It is a game inspired by Tamogatchi and Pokemon.

## Changelog
#### **31/08/2024**
- Created base play Screen, added riolu animation 
        ![walk-trip](https://github.com/user-attachments/assets/7f4a7c3a-4c51-4491-89da-92e54a943821)
- Created playground screen structure
- Added animation on selecting play

#### **01/09/2024**
- Now redirects user to play screen when program starts
- Changed the project to use a one-page model where the game does not direct the user to another page
Instead, each screen component is rendered based on the AppState's `GameScreen` property
- Created an event that fires whenever the `GameScreen` property is changed. When it is fired, the `StateHasChanged` Blazor method is invoked, causing the main component to re-render

#### **05/09/2024**
- Added animations
- Created base logic for movement, with animation corresponding to direction of movement

     ![Walk-Anim animation-all](https://github.com/user-attachments/assets/b9555913-34a3-48ff-9d69-b20a0941952f)

#### **07/09/2024**
- Added the pixelised image-rerendering property in styling of the animations so they scale better

#### **08/09/2024**
- Updated and fixed animations having some frames be cut out
- Added current state container in the partner info section


![current-state-demo-resized](https://github.com/user-attachments/assets/956ccc9f-d3b6-4746-9fec-51297e0e9487)


#### **09/09/2024**
-  Added stats in the stats section
                 
![stats](https://github.com/user-attachments/assets/2be7bc66-ab1d-4b34-ba9a-70094c6e774a)

- Added energy stat
- Added local storage to keep save data
- Added **export and import** functionality - Players can export their game data as a JSON file, and also import save files. Save data is saved to local storage.
- Created modal for import
  





