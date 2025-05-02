using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Move : Move
{
    [SerializeField] private Player_Z player_Z;
    private Vector2 playerZvec = new Vector2(0, 0.5f);

    [SerializeField] private TalkManager talkManager;
    [SerializeField] protected bool isTalking;
    public bool talkAble;
    public GameObject talkObject;

    public static Player_Move instance;
    protected override void Awake()
    {
        base.Awake();
        player_Z = GetComponentInChildren<Player_Z>();
                if (instance == null )
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public Player_Move GetPlayer()
    {
        if (instance == null)
            return instance = new Player_Move();
        else
            return instance;
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
        {
            moveDirection = Vector2.zero;
            if (talkManager.GetIsYesOrNo())
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    talkManager.YesOrNoToggle();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (talkAble)
            {
                string name = talkObject.GetComponent<Information>().GetNPCName();
                string quest = talkObject.GetComponent<Information>().GetQuestName();
                Sprite sprite = talkObject.GetComponent<Information>().GetSprite();
                talkManager.GetTalk(name, quest, sprite);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(SceneName.Main);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SceneManager.LoadScene(SceneName.MiniGame);
    }
    protected override void Jumping()
    {
        base.Jumping();
        if (isJumping && playerZvec.y >= 0.5f)
        {
            player_Z.transform.position += new Vector3(0, jumpY);
            if (player_Z.transform.localPosition.y < 0)
                player_Z.transform.localPosition = playerZvec;
        }
        else
            player_Z.transform.localPosition = playerZvec;
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

}
