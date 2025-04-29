using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : Move
{
    protected override void InputKeys()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(horizontal, vertical).normalized;
    }
}
