# Haunted Jaunt Game - Features

## Core Mechanics

### Red Screen Warning
- Uses linear interpolation (Lerp) for smooth screen transitions
- Fades to red when an enemy's eyesight is almost catching the player the player

### Interactive Key
- Uses the dot product to calculate the distace between the player and the key
  - If the player is within a certain distance, the key starts to move to a different location (this happens twice)
  - The player must follow the key in order to collect it at its final location
- There are 3 locations for keys: (The key also linearly interpolates to each position so the player can see the general direction the key move towards)
  1. In the Bathroom North of the spawn point
  2. On the dining table as you walk towards the original game win location
  3. In the corner of the bedroom south of the hallway where the original game win location was

- Includes pickup sound effect

### Wall & Lock System
- Located left of spawn point
- Requires key collection to unlock
- Unlock sequence:
  1. Plays unlock sound
  2. 0.5 second delay
  3. Four walls descend
  4. Smoke particle effect plays
  5. rumble sound during movement

### Victory
Reach the trophy on the far left after unlocking the walls to win.

### Effects
- Particle effect for wall descent
- Red screen warning
- Sound effects:
  - Key pickup
  - Lock mechanism
  - Wall movement