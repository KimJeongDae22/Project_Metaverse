using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    [SerializeField] private float smoothing = 0.2f;
    [SerializeField] private Vector2 minCameraPos;
    [SerializeField] private Vector2 maxCameraPos;

    public static CameraPos instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (Player_Move.instance != null)
        {
            Vector3 targetPos = new Vector3(Player_Move.instance.transform.position.x, Player_Move.instance.transform.position.y, this.transform.position.z);

            targetPos.x = Mathf.Clamp(targetPos.x, minCameraPos.x, maxCameraPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minCameraPos.y, maxCameraPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
    }
}
