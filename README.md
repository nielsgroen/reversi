# reversi

## Table of Contents
[1. Overall lay-out](#overall-lay-out)
- [1.1 User Interface](#11-user-interface)
- [1.2 Game](#12-game)

## 1. Overall lay-out

### 1.1 User Interface
- Converts clicks etc. into player actions
- Passes converted action to the Game

- Takes GameState from Game
- And draws to screen

### 1.2 Game
- Takes player actions
- Updates the GameState object accordingly
- GameState is made available as read only

## 2. Game

### 2.1 Public properties
- A game makes an read-only gamestate available.
- Game offers makeMove function which allows for moves 
- It also offers the posibility to get the amount of stones of each player.
- It also offers the posibility to check if a move is available for each player.

### 2.2 Private properties
- Game has an internal gamestate (Which is made available publicly read-only as .State)
- Game makes changes to the gamestate each time when makeMove is called.

### 2.3 Gamestate
- Has a state who's turn it is or the outcome of the game.
- Has 2d array of BoardField.
- Also stores boardWidth and boardHeight.
