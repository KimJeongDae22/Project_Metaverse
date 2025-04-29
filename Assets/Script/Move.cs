using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    protected Rigidbody2D rigid2D;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform weaponPivot;

    protected Vector2 moveDirection = Vector2.zero;

    protected Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;
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
    }
    protected virtual void InputKeys()
    {

    }
}
