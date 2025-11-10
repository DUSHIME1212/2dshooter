# Shooting Retry

A 2D top-down shooting game built with Unity, where players control a spaceship to battle waves of enemies, collect power-ups, and achieve high scores.

## Description

"Shooting Retry" is an action-packed 2D shooter game featuring a player-controlled spaceship that must survive against increasingly challenging enemy waves. The game includes various enemy types, power-up systems, and real-time UI updates for an engaging gameplay experience.

## Features

- **Player Movement**: Smooth keyboard-controlled movement with screen boundary constraints.
- **Weapon System**: Upgradable laser weapons with adjustable damage and fire rate.
- **Enemy Variety**: Multiple enemy types including basic, fast, and tank enemies with unique behaviors.
- **Power-Ups**: Collectible items that provide shields, speed boosts, and weapon upgrades.
- **Score System**: Real-time score tracking with UI updates.
- **Health Management**: Player health bar with visual feedback and invulnerability frames.
- **Game States**: Playing, paused, and game over states with restart functionality.
- **Event-Driven Architecture**: Uses custom events for decoupled communication between game components.

## Installation and Setup

### Prerequisites
- Unity 2021.3 or later (recommended)
- Windows 10/11

### Steps
1. Clone or download the project repository.
2. Open the project in Unity by selecting the folder containing `shooting retry.sln`.
3. Ensure all assets are imported correctly.
4. Open the main scene (typically in `Assets/Scenes/`).
5. Press Play to start the game.

## How to Play

- **Objective**: Survive as long as possible, defeat enemies, and achieve the highest score.
- **Survival**: Avoid enemy projectiles and collisions while destroying enemies.
- **Power-Ups**: Collect falling power-ups to gain advantages like health, speed, or weapon upgrades.
- **Game Over**: When player health reaches zero, the game ends. Restart to try again.

## Controls

- **Movement**: Arrow keys or WASD
- **Shooting**: Spacebar (automatic firing)
- **Restart**: Click the restart button on the game over screen

## Project Structure

```
Assets/
├── Scripts/
│   ├── Core/
│   │   ├── GameEvents.cs      # Central event dispatcher
│   │   ├── GameManager.cs     # Manages game state and score
│   │   ├── IDamageable.cs     # Interface for damageable objects
│   │   └── IShootable.cs      # Interface for shootable objects
│   ├── Enemies/
│   │   ├── Enemy.cs           # Base enemy class
│   │   ├── BasicEnemy.cs      # Standard enemy type
│   │   ├── FastEnemy.cs       # Fast-moving enemy
│   │   └── TankEnemy.cs       # High-health enemy
│   ├── Managers/
│   │   ├── UIManager.cs       # Handles UI elements
│   │   ├── SpawnManager.cs    # Manages enemy spawning
│   │   └── EnemyFactory.cs    # Creates enemy instances
│   ├── Player/
│   │   ├── Player.cs          # Player health and interactions
│   │   └── PlayerMovement.cs  # Player movement logic
│   ├── PowerUps/
│   │   ├── PowerUp.cs         # Base power-up class
│   │   ├── ShieldPowerUp.cs   # Health restoration
│   │   ├── SpeedPowerUp.cs    # Temporary speed boost
│   │   └── WeaponPowerUp.cs   # Weapon upgrade
│   └── Weapons/
│       ├── Weapon.cs          # Base weapon class
│       ├── LaserWeapon.cs     # Laser weapon implementation
│       └── Projectile.cs      # Projectile behavior
├── Scenes/                    # Unity scenes
├── Prefabs/                   # Game object prefabs
└── Resources/                 # Game assets
```

## Technologies Used

- **Unity Engine**: Game development framework
- **C#**: Programming language for scripts
- **TextMeshPro**: For UI text rendering
- **Unity Input System**: For player controls

## Architecture Overview

The game uses a component-based architecture with:
- **Singleton Pattern**: For GameManager and GameEvents
- **Factory Pattern**: For enemy creation
- **Observer Pattern**: For event-driven UI updates
- **Interface Segregation**: IDamageable and IShootable interfaces



---

Enjoy playing "Shooting Retry"! May your reflexes be sharp and your score high.
