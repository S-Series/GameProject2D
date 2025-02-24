using UnityEngine;
using UnityEngine.InputSystem;

public struct NamedAction
{
    public string actionName { get; set; }
    public InputAction inputAction { get; set; }
    public NamedAction(string name, InputAction action)
    {
        actionName = name;
        inputAction = action;
    }
}

