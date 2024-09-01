# PokeGotchiApp
PokeGotchi is a standalone WebAssembly app made with Blazor. It is a game inspired by Tamogatchi and Pokemon.

## Changelog
#### 31/08/2024
- Created base play Screen, added riolu animation 
        ![walk-trip](https://github.com/user-attachments/assets/7f4a7c3a-4c51-4491-89da-92e54a943821)
- Created playground screen structure
- Added animation on selecting play

#### 01/09/2024
- Now redirects user to play screen when program starts
- Changed the project to use a one-page model where the game does not direct the user to another page
Instead, each screen component is rendered based on the AppState's `GameScreen` property
- Created an event that fires whenever the `GameScreen` property is changed. When it is fired, the `StateHasChanged` Blazor method is invoked, causing the main component to re-render
