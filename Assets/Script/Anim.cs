using UnityEngine;

public class Anim : MonoBehaviour
{
    protected Animator anim;
    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Anim_Move(Vector2 direction)
    {
        anim.SetBool("IsMove", direction.magnitude != 0); // ¸Å±×´ÏÆ©µå = º¤ÅÍÀÇ Å©±â
    }
    public void Anim_Jumping()
    {
        if (!anim.GetBool("IsJumping"))
            anim.SetBool("IsJumping", true);
        else
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("JumpFall", false);
        }
    }
    public void Anim_JumpFall()
    {
        anim.SetBool("JumpFall", true);
    }
}
