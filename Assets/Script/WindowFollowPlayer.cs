using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowFollowPlayer : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position = Player_Move.instance.transform.position;
    }
}
