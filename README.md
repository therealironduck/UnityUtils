
# The Real Iron Duck Unity Utils

This unity package contains a lot of utility methods, helper and classes which I often use in my games.


## Installation

> **Caution: This package requires [UniDi](https://github.com/UniDi/UniDi)!**

You can install this package using the unity package manager by added it as a git repository.

In unity:
- Navigate to `Window -> Package Manager`
- Choose `Add package from git URL...`
- Enter `git@github.com:therealironduck/UnityUtils.git`
- Press enter!

Afterwards you should add the `TheRealIronDuckInstaller` to your extenject project context. Please consult the [UniDi Documentation](https://github.com/UniDi/unidi.github.io/blob/master/docs/index.md) for further information.
## Features

### Helper
This library provides a bunch of helper classes and methods.

#### RemoveAllChildren
A simple component which does excatly as it is called. It has a public method `RemoveAll` to delete all children of a transform. In addition a button in the inspector is drawn to delete all children. Works both in game, aswell as in the editor.

```csharp
gameObject.GetComponent<RemoveAllChildren>().RemoveAll();
```


#### DictionaryExtensions
A simple dictionary extension to get a random key-value-pair.

```csharp
var randomKeyValuePair = myDictionary.RandomItem();

Debug.Log(randomKeyValuePair.key, randomKeyValuePair.value);
```


#### CameraHelper
This static class has a simple method to get the world-position of the mouse using a raycast from a given camera.

```csharp
var position = CameraHelper.RayFromMouseToGround(myCamera, myGroundLayerMask);
```


#### VectorHelper
The static VectorHelper class has a few methods to work with vectors:

**GetClosetTarget**  
When given an array of components and a position it will return the closest to the position.

```csharp
var closest = VectorHelper.GetClosetTarget(myTransforms, Vector3.one);
```

**GetDirectionVectorFromTargetToMouse**    
Given a position and a camera it will calculate the direction vector starting from the given position towards the mouse. If no camera is given, it will use the main camera.

```csharp
var direction = VectorHelper.GetDirectionVectorFromTargetToMouse(Vector3.one);
```

**GetDirectionVectorBetweenPoints**   
It returns the normalized direction vector between two given points.

```csharp
var direction = VectorHelper.GetDirectionVectorBetweenPoints(Vector3.one, Vector3.zero);
```


### Interaction
A simple interaction handler is integrated into this package. Yoz can given any gameobject with a Trigger collider the `Interactable` component. The player requires the `Interactor` component.

The interactable component throws events based on if the interaction status.

```csharp

var interactable = GetComponent<Interactable>();

interactable.OnInteract.AddListener(OnInteract);
interactable.OnInteractEnter.AddListener(OnInteractEnter);
interactable.OnInteractExit.AddListener(OnInteractExit);

```

### ToDo for documentation
- LoadingScreen
- Network
- Noise
- Popup
- SceneManagement
- Types

## License

[MIT](https://choosealicense.com/licenses/mit/)


## Authors

- [@jkniest](https://www.github.com/jkniest)

