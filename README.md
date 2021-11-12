# Raycast Modification
Example for getting raycast, changing to head raycast, disabling ray and controller model.

## Scripts 

### `BubbleShootControllerRay.cs`
Controls shooting from a ray of controller.

### `BubbleShootHeadRay.cs`
Controls shooting from a ray of controller.</br>
- Method to switch pointer ray to head ray.
```cs
FindObjectOfType<JMRPointerManager>().SwitchPointingSource();
```

### `DisableRay.cs`
Disabling ray and controller after 2 seconds (so that JMRSDK has completed setup).</br>
- Method to disable ray and controller model
```cs
laserPointer = JMRInputManager.Instance.transform.Find("JMRLaserPointer(Clone)").gameObject;
cursorPointer = JMRInputManager.Instance.transform.Find("JMRPointer(Clone)").gameObject;
controller = JMRInputManager.Instance.transform.Find("JioGlassController(Clone)").gameObject;

foreach (Transform item in controller.GetComponentsInChildren<Transform>())
{
    if(item.gameObject.name == "Model")
    {
        item.gameObject.SetActive(false);
        break;
    }
}
laserPointer.SetActive(false);
cursorPointer.SetActive(false);
```

## How to use?
1. Download and unzip this project.
2. Open the project using Unity Hub.
3. Download and import the latest version of JMRSDK package.
4. Open and play the scenes present in the Assets/Scenes folder.
