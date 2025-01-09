using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerInput playerInput;
    private void Awake()
    {
        TryGetComponent<PlayerInput>(out PlayerInput playerInput);
        if (playerInput == null) { throw new System.Exception(""); }
    }
    private void Start()
    {
        playerInput.actions["Move"].performed += T => ScrollAction();
    }

    private void ScrollAction()
    {
        Vector2 vec;
        vec = playerInput.actions["Move"].ReadValue<Vector2>();
    }
}
