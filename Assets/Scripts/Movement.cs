using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] Slider staminaGuage;

    public float moveSpeed = 5f;
    public float runMultiplier = 1.75f;
    public float smoothTime = 0.1f;
    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb;

    public float[] stamina = new float[2] { 100f, 100f };
    private float staminaCooldown = 0f;

    public Vector2 windForce = Vector2.zero;

    private PlayerInputActions inputActions;
    private bool isRunning = false;
    private Vector2 moveInput = Vector2.zero;


    void Awake() { inputActions = new PlayerInputActions(); }

    void OnEnable() { inputActions.Enable(); }

    void OnDisable() { inputActions.Disable(); }

    void Start() { rb = GetComponent<Rigidbody2D>(); }

    void Update()
    {
        isRunning = inputActions.Player.Run.ReadValue<float>() > .5f && stamina[0] > 0;
        moveInput = inputActions.Player.Move.ReadValue<Vector2>();

        if (isRunning)
        {
            stamina[0] -= 20f * Time.deltaTime;
            staminaCooldown = 0f;
        }
        else
        {
            staminaCooldown += Time.deltaTime;
            if (staminaCooldown >= 2.5f) { stamina[0] += 10f * Time.deltaTime; }
        }
        stamina[0] = Mathf.Clamp(stamina[0], 0f, stamina[1]);
        staminaGuage.value = stamina[0] / stamina[1];

        MoveCharacter(moveInput.normalized * moveSpeed * (isRunning ? runMultiplier : 1));
    }

    public void MoveCharacter(Vector2 targetVelocity)
    {
        rb.linearVelocity = Vector2.SmoothDamp(
            rb.linearVelocity,
            targetVelocity + windForce,
            ref velocity,
            smoothTime
        );
    }

    public void RebindAction()
    {

    }
}