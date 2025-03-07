using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    private bool _isMoving = false;
    TouchingDirections touchingCol;
    public float jumpImpulse = 10f;
    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            anim.SetBool("IsMoving", value);
        }
    }
    public bool _isFacingRight = true;
    public bool IsFacingRight
    {
        get
        {
            return _isFacingRight;
        }
        private set
        {
            if (_isFacingRight != value)
            {
                _isFacingRight = value;
                transform.localScale *= new Vector2(-1, 1);
            }
        }
    }
    Rigidbody2D rb;
    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        touchingCol = GetComponent<TouchingDirections>();
    }
    public float walkSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 direction)
    {
        if (moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if (context.started && touchingCol.IsGround)
        {
            anim.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }
}
