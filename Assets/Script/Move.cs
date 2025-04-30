using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    protected Rigidbody2D rigid2D;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform weaponPivot;

    protected Vector2 moveDirection = Vector2.zero;

    protected Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;
    [SerializeField] protected float jumpPower = 5.0f;
    [SerializeField] protected float jumpY = 0.0f;
    [SerializeField] protected float Gravity = 0.5f;
    [SerializeField] protected bool isJumping = false;
    protected virtual void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }
    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        InputKeys();
    }
    protected virtual void FixedUpdate()
    {
        Movement(moveDirection);
        Jumping();
        if (knockbackDuration > 0.0f)
            knockbackDuration -= Time.deltaTime;
    }
    private void Movement(Vector2 direction)
    {
        direction = direction * 5;
        if (knockbackDuration > 0.0f)
        {
            direction *= 0.2f;
            direction += knockback;
        }
        rigid2D.velocity = direction;
        if (direction.x != 0)
        spriteRenderer.flipX = direction.x < 0;
    }
    private void Jumping()
    {
        if (isJumping)
        {
            if (jumpY > -jumpPower)
            {
                rigid2D.velocity += new Vector2 (0, jumpY);
                jumpY -= 0.02f * Gravity;
            }
            else
            {
                jumpY = 0;
                isJumping = false;
            }
        }

    }
    protected virtual void InputKeys()
    {

    }
}
