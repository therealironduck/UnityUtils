
# The Real Iron Duck Unity Utils

This unity package contains a lot of utility methods, helper and classes which I often use in my games.


## Installation

You can install this package using the unity package manager by added it as a git repository.

In unity:
- Navigate to `Window -> Package Manager`
- Choose `Add package from git URL...`
- Enter `git@github.com:therealironduck/UnityUtils.git`
- Press enter!

## Features

### Helper
This library provides a bunch of helper classes and methods.

#### RemoveAllChildren
A simple component which does excatly as it is called. It has a public method `RemoveAll` to delete all children of a transform. In addition a button in the inspector is drawn to delete all children. Works both in game, aswell as in the editor.

```csharp
gameObject.GetComponent<RemoveAllChildren>().RemoveAll();
```

#### Rotate
A simple component which rotates a transform around a given axis with a given speed.

#### DictionaryExtensions
A simple dictionary extension to get a random key-value-pair.

```csharp
var randomKeyValuePair = myDictionary.RandomItem();

Debug.Log(randomKeyValuePair.key, randomKeyValuePair.value);
```

#### CameraHelper
This static class has two simple methods to get the world-position or object of the mouse using a raycast from a given camera.

```csharp
var position = CameraHelper.RayFromMouseToGround(myCamera, myGroundLayerMask);

var target = CameraHelper.RayFromMouseToTarget(myCamera, myGroundLayerMask);
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

### Screenshot
This package contains a simple screenshot taker. It can be used to take screenshots and store them in the assets directory.
Main use would be to generate transparent icons for your 3d models.

The package comes with a camera prefab attaches, so you can directly start using it. If you don't want to use the included
camera, you can use your one. Just make sure that the Environment background is set to "Solid color" and alpha is at 0.

Just attach the component `ScreenshotTaker` to any game object and you can create screenshots
directly from within the inspector.

Otherwise this is how you can manually trigger a screenshot:

```csharp
var screenshotTaker = GetComponent<ScreenshotTaker>();

screenshotTaker.Capture();
```

### Custom Odin Validator Attributes

> This requires the [Odin Validator](https://odininspector.com/odin-validator) package to be installed.

#### HasComponent
The `HasComponent` attribute can be used to validate if a component is attached to a game object. It can be used on fields, properties and methods.

```csharp
public class MyComponent : MonoBehaviour
{
    [HasComponent(typeof(Rigidbody))]
    public GameObject someObjectThatMustHaveARigidbody;
}
```

#### NotEmpty
The `NotEmpty` attribute can be used to validate if a collection/array is not empty. It can be used on fields.

```csharp
public class MyComponent : MonoBehaviour
{
    [NotEmpty]
    public GameObject[] gameObjects;
}
```


### ToDo for documentation
- Noise
- Types

## License

[MIT](https://choosealicense.com/licenses/mit/)


## Authors

- [@jkniest](https://www.github.com/jkniest)

