# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

**Order for categories:**
- Security
- Added
- Changed
- Fixed
- Removed
- Dependencies

## [0.4.0] - 2023-07-15
### Fixed
- Fixed netcode for gameobjects reference missing in assembly file

### Dependencies
- Make Unity.Mathematics a real dependency (was missing in package.json file)
- Automatically detect if netcode for gameobjects is installed

## [0.3.0] - 2023-07-13
### Changed
- `Noise` Replace perlin noise with simplex noise
- `Noise` Add preview options (seed & offset) to the scriptable object

### Dependencies
- Add dependency to Unity.Mathematics

## [0.2.0] - 2023-07-09
### Added
- `Noise` Added Noise Scriptable object with preview window

## [0.1.1] - 2023-07-09
### Fixed
- `Noise` Fixed issue with wrong offset calculation

## 0.1.0 - 2023-07-08
### Added
- `Helper` Added component to simply remove all children. It can be triggered in the inspector or by calling the public method.
- `Helper` Added an extension to dictionaries to get a random key-value pair
- `Helper` Added a helper class to get the world-position of the mouse using a raycast
- `Helper` Added a vector helper class which contains a few useful methods:
   - `GetClosestTarget` returns the closest target from a list of targets to a given position
   - `GetDirectionVectorFromTargetToMouse` returns the direction vector from a given target to the mouse position
   - `GetDirectionVectorBetweenPoints` returns the normalized direction vector between two given points
- `Interaction` Added a simple event-based interaction component system
- `LoadingScreen` Added simple loading screen components and services
- `Network` Added a ClientNetworkAnimator component
- `Noise` Added a simple perlin noise generator, supporting multiple octaves, etc.
- `Popup` Added a popup system to show popups from anywhere
- `SceneManagement` Added a scene loading manager to load scenes with a nice fade effect
- `Types` Added a referencable and serializable type field to select a C# class

[0.3.0]: https://github.com/TheRealIronDuck/UnityUtils/compare/0.2.0...0.3.0
[0.2.0]: https://github.com/TheRealIronDuck/UnityUtils/compare/0.1.1...0.2.0
[0.1.1]: https://github.com/TheRealIronDuck/UnityUtils/compare/0.1.0...0.1.1