using UnityEngine;

public class Player_Move : Move
{
    [SerializeField] private Player_Z player_Z;
    protected override void Awake()
    {
        base.Awake();
        player_Z = GetComponentInChildren<Player_Z>();
    }
    protected override void InputKeys()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(horizontal, vertical).normalized;

        if (isJumping == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                jumpY = jumpPower;
                anim.Anim_Jumping();
            }
        }
    }
    protected override void Jumping()
    {

        if (jumpY > -jumpPower)
            player_Z.transform.position += new Vector3(0, jumpY);
        else
            player_Z.transform.localPosition = Vector3.zero;
        base.Jumping();

    }
    protected void LateUpdate()
    {
        player_Z.GetSprite().sprite = spriteRenderer.sprite;
        player_Z.GetSprite().flipX = spriteRenderer.flipX;
    }
    public bool GetIsJump()
    { return isJumping; }
}
