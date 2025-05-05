using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 10f;
    public float holeSizeMax = 20f;

    public Transform topObs;
    public Transform bottomObs;

    public float ObsGenCycle = 4f;

    public Vector3 SetRandomPlace(Vector3 lastposition, int obsCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObs.localPosition = new Vector2(0, halfHoleSize);
        bottomObs.localPosition = new Vector2(0, -halfHoleSize);

        Vector3 placePosition = lastposition + new Vector3(ObsGenCycle, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }
}
