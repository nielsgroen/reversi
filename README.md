# reversi

## Table of Contents
[1. Overall lay-out](#overall-lay-out)
  [1.1 User Interface](#user-interface)
  [1.2 Game](#game)

## 1. Overall lay-out

### 1.1 User Interface
- Converts clicks etc. into player actions
- Passes converted action to the Game

- Takes GameState from Game
- Completely replaces old GameState
- And draws to screen

### 1.2 Game
- Takes player actions
- Updates the GameState object accordingly
- Returns updated GameState with each call.
