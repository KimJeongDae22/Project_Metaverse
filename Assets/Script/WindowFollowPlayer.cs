using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowFollowPlayer : MonoBehaviour
{
    private RectTransform rectTransform;
    [SerializeField] private Transform player;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    private void LateUpdate()
    {
        this.transform.position = player.transform.position;
    }
}
