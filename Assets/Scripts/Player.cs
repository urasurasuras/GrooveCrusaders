using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static MasterInput;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IPlayerActions
{
    public Ray reyyyy;
    public MasterInput inputActions;
    public Config cfg;

    Rigidbody2D _rb;

    bool facing = false;// 0 if left 1 if right
    public float range = 1f;
    [SerializeField] Vector2 move;
    [SerializeField] public Vector2 aim;

    [SerializeField] Weapon _weapon;
    [SerializeField] ActorController _actorController;

    InputAction.CallbackContext _ctx;

    [SerializeField] GameObject crosshair;
    private void Awake()
    {
        inputActions = new MasterInput();

        inputActions.Player.Movement.performed += OnMovement;
        inputActions.Player.Movement.canceled += OnMovement;

        inputActions.Player.Aim.performed += OnAim;
        inputActions.Player.Aim.canceled += OnAim;

        inputActions.Player.Attack.performed += OnAttack;
        //inputActions.Player.Attack.canceled += OnAttack;
    }

    private void Start()
    {
        if (!_rb)
            _rb = GetComponent<Rigidbody2D>();
        // if (!sr)
        //     sr = GetComponent<SpriteRenderer>();
        if (!crosshair)
            crosshair = transform.Find("Crosshair").gameObject;

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
        crosshair.GetComponent<Crosshair>().Aim(_ctx);
    }
    private void FixedUpdate()
    {
        Move(move);
        CheckAndFlip();
    }
    private void Move(Vector2 move)
    {
        _rb.MovePosition(_rb.position + move * Time.fixedDeltaTime);
    }

    private void CheckAndFlip()
    {
        bool nextFacing;
        if (crosshair.transform.localPosition.x < 0) nextFacing = true;
        else { nextFacing = false; }

        if (nextFacing != facing)
        {
            facing = nextFacing;


            _actorController.FlipAndReverseActorsSprites(facing);
            //_spriteActor.Flip(nextFacing);

            //_weapon.WeaponFlipSprite(nextFacing);
            // var wp = weapon.sprite.GetComponent<Actor>();
            // if (wp)
            // {
            //     wp.Flip(nextFacing);
            //     wp.ReverseRenderOrder();
            // }
        }
    }

    #region GUI

    void OnGui()
    {
    }

    //void OnDrawGizmos()
    //{
    //    // Draws a 5 unit long red line in front of the object
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(Camera.main.transform.position, reyyyy.direction);
    //    print(reyyyy.direction.ToString());
    //}

    #endregion
    #region IPlayerActions
    public void OnMovement(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<Vector2>();
    }
    public void OnAim(InputAction.CallbackContext ctx)
    {
        _ctx = ctx;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        _weapon.Attack();
    }

    #endregion
}