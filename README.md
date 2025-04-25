# VR 3D Paradox Museum

## Project Description
This is a **VR 3D Paradox Museum** experience, inspired by real-life museums such as **Paradox Museum**, **teamLab Planets**, and **teamLab Borderless**, built entirely from scratch by **Anusheel Soni**. This immersive VR project aims to simulate **visual illusions and surreal interactive spaces**, offering players a mind-bending experience across multiple themed rooms.

## Features

### General
- Built entirely with **OpenXR** and Unity’s XR Interaction Toolkit.
- **Multi-scene room system** for optimized performance and dynamic loading/unloading.
- **All interactions and effects scripted manually** using event listeners.

### Room 1: The Hanging Bulb Room
- **Rope physics** with realistic sway and swing.
- **Interactable bulbs** that turn off (break) when clicked.
- **Customizable rope behavior** via prefabs for reuse.
- **Dynamic lighting effects** and ambient room illumination.

### Room 2: The Floating Cubes Room
- **Glowing cubes** float rapidly toward the player.
- Cube **acceleration and deceleration** depend on player movement.
- **Gloom post-processing** added for an ethereal visual effect.

### Room 3: The Particle Trail Room
- **Particles follow player movement** in real time.
- **Light trail system** activates based on player position:
  - Blue trails **move from room edges to the exit**.
  - Blue light **orbits around player’s floor position**.
- **Custom shader** for dynamic and glowing light trails.
- Light trail systems **destroyed on room exit** for optimization.

## Optimization
- Rooms **activate and deactivate dynamically** based on player's location.
- Environment lighting and exposure **adapt in real-time**.
- All room transitions handled through **scene management** for better performance.

## Unity Version
This project was developed using **Unity 6 (6000.0.42f1)**.

## Project Structure
The repository contains only three folders:
- `Assets`
- `Packages`
- `ProjectSettings`

Anyone can clone this repository and open it directly in Unity 6 to try out the project.

## License
All assets used in this project are licensed under **Creative Commons CC0**.

---
