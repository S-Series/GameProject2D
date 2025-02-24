using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using Unity.VisualScripting;

public class InputManager : MonoBehaviour
{
    private static PlayerInput playerInput;

    private bool isRunning = false;

    public float moveSpeed = 5f;
    public float runMultiplier = 1.75f;
    public float smoothTime = 0.1f;
    public float[] stamina = new float[2] { 100f, 100f };
    private float staminaCooldown = 0f;

    public Vector2 windForce = Vector2.zero;
    private Vector2 velocity = Vector2.zero;
    private Vector2 moveInput = Vector2.zero;

    private Rigidbody2D rb;
    private Slider staminaGuage;
    private InputAction moveAction;

    private void Awake()
    {
        TryGetComponent<PlayerInput>(out PlayerInput pi);
        if (pi == null) { throw new System.Exception(""); }
        else { playerInput = pi; }
        moveAction = playerInput.actions["Move"];
    }

    private void OnEnable()
    {
        playerInput.ActivateInput();
    }

    private void OnDisable()
    { 
        playerInput.DeactivateInput();
    }

    private void Start()
    {
        staminaGuage = GameManager.s_Player.GetComponentInChildren<Slider>();
        rb = GameManager.s_Player.GetComponent<Rigidbody2D>();
    } 

    private void Update()
    {
        moveInput = moveSpeed * moveAction.ReadValue<Vector2>();
        CharacterMove(moveInput);
    }

    private void CharacterMove(Vector2 targetVelocity)
    {
        rb.linearVelocity = Vector2.SmoothDamp(
            rb.linearVelocity,
            targetVelocity + windForce,
            ref velocity,
            smoothTime
        );
    }
    private void CharacterAttack()
    {

    }
    private void CharacterSkill()
    {

    }
    private void CharacterUltimate()
    {

    }
    private void CharacterForceEscape()
    {

    }

    public void RebindAction(string name)
    {
        var action = GetActionByName(name);
        if (action == null) { throw new System.Exception(""); }

        action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Mouse>")
            .WithControlsExcluding("<Keyboard>/esc")
            .OnComplete(operation =>
            {
                operation.Dispose();
            })
            .OnCancel(operation =>{
                operation.Dispose();
            })
            .Start();
    }

    public InputAction GetActionByName(string name)
    {
        InputAction ret;

        if (playerInput == null) { return null; }
        ret = playerInput.actions.FindAction(name);

        return ret;
    }


    /*private void InvokeMethod(string methodName)
    {
        var methodd = GetType().GetMethod(
            methodName,
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance
        );
        if (methodd == null) { methodd.Invoke(this, null); }
    }*/
}
