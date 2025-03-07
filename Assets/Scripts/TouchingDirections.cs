using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;
    CapsuleCollider2D touchingCol;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    Animator animator;
    private bool _isGround = true;

    public bool IsGround
    {
        get
        {
            return _isGround;
        }
        private set
        {
            _isGround = value;
            animator.SetBool("IsGround", value);
        }
    }

    private void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>(); // Ensure animator is initialized
    }

    void FixedUpdate()
    {
        IsGround = touchingCol.Cast(Vector2.down, castFilter, groundHits, 0.05f) > 0;
    }
}
