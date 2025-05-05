using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loofer : MonoBehaviour
{
    public BaeKyeong[] baeKyeongs;
    public Obstacle[] obstacles;

    public Vector3 lastPosition;
    void Start()
    {
        baeKyeongs = GameObject.FindObjectsOfType<BaeKyeong>();
        obstacles = GameObject.FindObjectsOfType<Obstacle>();
        lastPosition = obstacles[0].transform.position;

        for (int i = 0; i < obstacles.Length; i++)
        {
            lastPosition = obstacles[i].SetRandomPlace(lastPosition, obstacles.Length);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BaeKyeong baeKyeong = collision.GetComponent<BaeKyeong>();
        Obstacle obstacle = collision.GetComponent<Obstacle>();

        if (obstacle != null )
        {
            lastPosition = obstacle.SetRandomPlace(lastPosition, obstacles.Length);
        }

        if (baeKyeong != null)
        {
            baeKyeong.transform.position += new Vector3(35.5f, 0);
        }
    }
}
