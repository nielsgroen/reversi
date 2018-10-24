# reversi

## Table of Contents
[1. Overall lay-out](#overall-lay-out)
- [1.1 User Interface](#11-user-interface)
- [1.2 Game](#12-game)

[2. Game](#game)
- [2.1 Public properties](#21-public-properties)
- [2.2 Private properties](#22-private-properties)
- [2.3 GameState](#23-gamestate)


## 1. Overall lay-out

### 1.1 User Interface
- Converts clicks etc. into player actions.
- Passes converted action to the Game.
- Takes GameState from Game.
- And draws to screen.

### 1.2 Game
- Takes player actions.
- Updates the GameState object accordingly.
- GameState is made available as read only.


## 2. Game

### 2.1 Public properties
- A game makes a read-only GameState available.
- Game offers makeMove function which allows for moves. 
- It also offers the posibility to get the amount of stones of each player.
- It also offers the posibility to check if a move is available for each player.

### 2.2 Private properties
- Game has an internal gamestate (Which is made available publicly read-only as .State)
- Game makes changes to the GameState each time when makeMove is called.

### 2.3 Gamestate
- Has a state who's turn it is or the outcome of the game.
- Has 2D-array of BoardFields.
- Also stores boardWidth and boardHeight.
