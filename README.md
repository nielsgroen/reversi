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
- Completely replaces old GameState
- And draws to screen

### 1.2 Game
- Takes player actions
- Updates the GameState object accordingly
- GameState is made available as read only
