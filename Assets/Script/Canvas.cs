using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    public static Canvas instance;

    [SerializeField] private Text bestscore;
    void Awake()
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

    // Update is called once per frame
    void FixedUpdate()
    {
        bestscore.text = "최고 점수 : " + PlayerPrefs.GetFloat("BestScore").ToString("N2");
    }
}
