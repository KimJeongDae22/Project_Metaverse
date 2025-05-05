using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid2D;

    [SerializeField] private float jumpPower = 5.0f;
    [SerializeField] private float fowardPower = 3.0f;
    [SerializeField] private bool isDead = false;
    private float ScoreDelay = 0.0f;

    bool isJump = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isJump = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) { return; }

        Vector3 velocity = rigid2D.velocity;
        velocity.x = fowardPower;

        if (isJump)
        {
            velocity.y += jumpPower;
            isJump = false;
        }
        rigid2D.velocity = velocity;
    }
    private void LateUpdate()
    {
        animator.SetBool("JumpFall", rigid2D.velocity.y < 0 ? true : false);
        animator.SetBool("isDead", isDead);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) { return; }

        isDead = true;
        GameManager.instance.Getgameover();
        ScoreDelay = 1f;
    }
}
