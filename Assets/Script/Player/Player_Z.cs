using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Z : Move
{
    public static Player_Z instance;
    protected override void Awake()
    {
        base.Awake();
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
    protected override void Update()
    {


    }
    protected override void FixedUpdate()
    {
    }
}
