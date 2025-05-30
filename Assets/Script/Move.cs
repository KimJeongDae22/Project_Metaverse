using UnityEngine;

public class Move : MonoBehaviour
{
    protected Rigidbody2D rigid2D;

    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] private Transform weaponPivot;


    protected Vector2 moveDirection = Vector2.zero;

    protected Vector2 knockback = Vector2.zero;
    protected float knockbackDuration = 0.0f;
    [SerializeField] protected float jumpPower = 5.0f;
    [SerializeField] protected float jumpY = 0.0f;
    [SerializeField] protected float Gravity = 0.5f;
    [SerializeField] protected bool isJumping = false;

    [SerializeField] protected bool isMove = false;
    protected Anim anim;
    protected virtual void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Anim>();
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
    protected void Movement(Vector2 direction)
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
        anim.Anim_Move(direction);
    }
    protected virtual void Jumping()
    {
        if (isJumping)
        {
            if (jumpY > -jumpPower / 10)
            {
                //transform.position += new Vector3(0, jumpY);
                jumpY -= 0.02f * Gravity / 10;
                if (jumpY < 0)
                    anim.Anim_JumpFall();
            }
            else
            {
                jumpY = 0;
                isJumping = false;
                anim.Anim_Jumping();
            }

        }
    }
    public float GetJumpY()
    {
        return jumpY;
    }
    public SpriteRenderer GetSprite()
    { return spriteRenderer; }
    protected virtual void InputKeys()
    {

    }
}
