using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static MasterInput;

public class Player : MonoBehaviour, IPlayerActions
{
    public MasterInput inputActions;
    public Config cfg;

    Rigidbody2D rb;
    SpriteRenderer sr;
    bool facing = false;// 0 if left 1 if right
    public float range = 1f;
    [SerializeField]
    Vector2 move;
    [SerializeField]
    Vector2 aim;

    InputAction.CallbackContext _ctx;

    GameObject crosshair;
    private void Awake()
    {
        inputActions = new MasterInput();

        inputActions.Player.Movement.performed += OnMovement;
        inputActions.Player.Movement.canceled += OnMovement;

        inputActions.Player.Aim.performed += OnAim;
        inputActions.Player.Aim.canceled += OnAim;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        crosshair = transform.GetChild(0).gameObject;

        cfg = GetComponent<Config>();

        GameManager.Instance.RegisterPlayerControl(this);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    private void Update()
    {
        try
        {
            Aim(_ctx);
        }
        catch (Exception)
        {
        }
    }
    private void FixedUpdate()
    {
        Move(move);
    }
    private void Move(Vector2 move)
    {
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
    }
    public void Aim(InputAction.CallbackContext ctx)
    {
        aim = ctx.ReadValue<Vector2>();

        if (ctx.control.shortDisplayName == "RS")
        {
            crosshair.transform.localPosition = aim * range;
        }
        else
        {
            var screenPoint = Camera.main.ScreenToWorldPoint(aim);
            crosshair.transform.position = new Vector2(screenPoint.x, screenPoint.y);
        }
    }
    #region IPlayerActions
    public void OnMovement(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<Vector2>();
    }
    public void OnAim(InputAction.CallbackContext ctx)
    {
        CheckAndFlip();
        _ctx = ctx;
    }

    private void CheckAndFlip()
    {
        bool nextFacing;
        if (crosshair.transform.localPosition.x < 0) nextFacing = true;
        else { nextFacing = false; }

        if (nextFacing != facing)
        {
            facing = nextFacing;

            GetComponent<Actor>().Flip(nextFacing);
        }
    }

    
    #endregion
}