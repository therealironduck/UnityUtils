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

## [0.11.0] - 2023-10-25
### Added
- `Helper` Added method to get the hit target using a raycast to the CameraHelper

## [0.10.0] - 2023-10-14
### Added
- `Noise` Added option to configure falloff values for noises 

## [0.9.0] - 2023-10-13
### Added
- `Noise` Added static method to generate a single noise value `NoiseGenerator.GenerateNoiseValue`

### Changed
- Install the signal bus in the RealIronDuckInstaller 
- ScreenshotCamera prefab now has no audio listener by default

### Dependencies
- This package now requires [UniDi Signals](https://github.com/UniDi/UniDi-Signals.git)

## [0.8.0] - 2023-08-27
### Added
- `Screenshot` Added component and prefab to take transparent screenshots
- `Helper` Added ticker system to allow any class to run logic on every frame or every second

## [0.7.1] - 2023-08-20
### Fixed
- Fixed issue with editor assembly (only load the assembly in editor and not builds)

## [0.7.0] - 2023-08-19
### Added
- `Helper` Added a rotate component

## [0.6.0] - 2023-08-18
### Added
- `Network` Added a ClientNetworkTransform component

## [0.5.0] - 2023-07-16
### Dependencies
- Switch from extenject to UniDi

## [0.4.1] - 2023-07-15
### Fixed
- Fixed wrong dependency version constraint in package.json

## [0.4.0] - 2023-07-15
### Added
- `Helper` Add support for new input system to camera helper 

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

[0.10.0]: https://github.com/TheRealIronDuck/UnityUtils/compare/0.9.0...0.10.0
[0.9.0]: https://github.com/TheRealIronDuck/UnityUtils/compare/0.8.0...0.9.0
[0.8.0]: https://github.com/TheRealIronDuck/UnityUtils/compare/0.7.1...0.8.0
[0.7.1]: https://github.com/TheRealIronDuck/UnityUtils/compare/0.7.0...0.7.1
[0.7.0]: https://github.com/TheRealIronDuck/UnityUtils/compare/0.6.0...0.7.0
[0.6.0]: https://github.com/TheRealIronDuck/UnityUtils/compare/0.5.0...0.6.0
[0.5.0]: https://github.com/TheRealIronDuck/UnityUtils/compare/0.4.1...0.5.0
[0.4.1]: https://github.com/TheRealIronDuck/UnityUtils/compare/0.4.0...0.4.1
[0.4.0]: https://github.com/TheRealIronDuck/UnityUtils/compare/0.3.0...0.4.0
[0.3.0]: https://github.com/TheRealIronDuck/UnityUtils/compare/0.2.0...0.3.0
[0.2.0]: https://github.com/TheRealIronDuck/UnityUtils/compare/0.1.1...0.2.0
[0.1.1]: https://github.com/TheRealIronDuck/UnityUtils/compare/0.1.0...0.1.1