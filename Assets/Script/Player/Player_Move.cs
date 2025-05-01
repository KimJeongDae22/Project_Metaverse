using UnityEngine;

public class Player_Move : Move
{
    [SerializeField] private Player_Z player_Z;
    [SerializeField] private TalkManager talkManager;

    [SerializeField] protected bool isTalking;
    public bool talkAble;
    public GameObject talkObject;
    protected override void Awake()
    {
        base.Awake();
        player_Z = GetComponentInChildren<Player_Z>();
    }
    protected override void FixedUpdate()
    {
        Movement(moveDirection);
        Jumping();
        if (knockbackDuration > 0.0f)
            knockbackDuration -= Time.deltaTime;
    }
    protected override void InputKeys()
    {
        if (!isTalking)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            moveDirection = new Vector2(horizontal, vertical).normalized;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isJumping == false)
                {
                    isJumping = true;
                    jumpY = jumpPower / 10;
                    anim.Anim_Jumping();
                }
            }
        }
        else
            moveDirection = Vector2.zero;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (talkAble)
            {
                string name = talkObject.GetComponent<Information>().GetNPCName();
                Sprite sprite = talkObject.GetComponent<Information>().GetSprite();
                talkManager.GetTalk(name, sprite);
            }
        }
    }
    protected override void Jumping()
    {
        base.Jumping();
        if (isJumping && player_Z.transform.localPosition.y >= 0)
        {
            player_Z.transform.position += new Vector3(0, jumpY);
            if (player_Z.transform.localPosition.y < 0)
                player_Z.transform.localPosition = Vector3.zero;
        }
        else
            player_Z.transform.localPosition = Vector3.zero;
    }
    protected void LateUpdate()
    {
        player_Z.GetSprite().sprite = spriteRenderer.sprite;
        player_Z.GetSprite().flipX = spriteRenderer.flipX;
    }
    public bool GetIsJump()
    { return isJumping; }
    public void GetIsTalkingToggle()
    {
        isTalking = !isTalking;
    }
    public void GetInteractionWindowToggle()
    {
        talkManager.InteractionWindowToggle();
    }
}
