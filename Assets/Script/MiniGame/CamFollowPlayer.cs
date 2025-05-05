using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private float offsetX;
    void Start()
    {
        if (player == null)
            return;

        offsetX = transform.position.x - player.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        Vector3 position = transform.position;
        position.x = player.position.x + offsetX;
        transform.position = position;
    }
}
