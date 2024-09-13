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
- Changed the project to use a one-page model where the game does not direct the user to another page.
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
  
  ![import-demo-resized](https://github.com/user-attachments/assets/5b1f7d25-561c-4a95-bed5-26ab25fb40c0)

#### **10/09/2024**
- Added grid container for playground
- Made number of cells fit the area of container
- Added bounds to the container (Partner Pokemon cannot move outside of them)

#### **11/09/2024**
- Partner Pokemon now slides across cells instead of snapping to them
- Placed the mood attribute in between the current state container and stats container
- Made a pathfinding algorithm where the user can click on a cell and the Partner sprite will move towards it
- The player can now interrupt the Partner Pokemon's current movement to a cell to another cell with a another cell click
- Made the cell the player clicks last the active cell with a background indicating so


  ![walk-click-demo](https://github.com/user-attachments/assets/345797a5-7b8e-40a8-aa11-e48464c09913)

#### **12/09/2024**
- Added ability to 'pick up' Partner Pokemon and move to another cell (will decrease happiness)
- Redesigned Partner Information UI

![dragging-demo-resize](https://github.com/user-attachments/assets/c36af887-0208-4210-8270-5f3d47d4e662)

#### **13/09/2024**
- Added Player data - Name and Money
- Added a shop and basic inventory system - The player can buy items and they go into the inventory
- Added the ability for the Partner Pokemon to move autonomously

![walkin-resize](https://github.com/user-attachments/assets/a2a1ade2-4b59-47a1-9cc3-862ea2508f1a)



All sprites and animations are the property of Nintendo and have been sourced from https://sprites.pmdcollab.org/


Credits to: https://github.com/PMDCollab/SpriteCollab/blob/master/credit_names.txt



