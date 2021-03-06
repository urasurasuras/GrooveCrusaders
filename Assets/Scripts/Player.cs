﻿using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static MasterInput;

public class Player : MonoBehaviour, IPlayerActions
{
    public Ray reyyyy;
    public MasterInput inputActions;
    public Config cfg;

    Rigidbody2D rb;
    SpriteRenderer sr;

    bool facing = false;// 0 if left 1 if right
    public float range = 1f;
    [SerializeField]
    Vector2 move;
    [SerializeField]
    public Vector2 aim;

    InputAction.CallbackContext _ctx;

    [SerializeField]GameObject crosshair, weapon, self;
    private void Awake()
    {
        inputActions = new MasterInput();

        inputActions.Player.Movement.performed += OnMovement;
        inputActions.Player.Movement.canceled += OnMovement;

        inputActions.Player.Aim.performed += OnAim;
        inputActions.Player.Aim.canceled += OnAim;

        inputActions.Player.Attack.performed += OnAttack;
        inputActions.Player.Attack.canceled -= OnAttack;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //crosshair = transform.GetChild(0).gameObject;
        //weapon = transform.GetChild(1).gameObject;        

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
            crosshair.GetComponent<Crosshair>().Aim(_ctx);
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
    
    private void CheckAndFlip()
    {
        bool nextFacing;
        if (crosshair.transform.localPosition.x < 0) nextFacing = true;
        else { nextFacing = false; }

        if (nextFacing != facing)
        {
            facing = nextFacing;

            self.GetComponent<Actor>().Flip(nextFacing);

            var wp = weapon.GetComponent<Actor>();
            if (wp)
            {
                wp.Flip(nextFacing);
                wp.ReverseRenderOrder();
            }
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
        CheckAndFlip();
        _ctx = ctx;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        weapon.GetComponent<Weapon>().Attack();
    }

    #endregion
}