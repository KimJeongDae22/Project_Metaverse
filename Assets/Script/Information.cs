using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    [SerializeField] protected string npcName;
    [SerializeField] protected Sprite sprite;
    [SerializeField] protected Player_Move player;
    [SerializeField] protected TalkManager talkManager;
    [SerializeField] protected int talkIndex;


    protected virtual void Awake()
    {
    }
    public Sprite GetSprite()
        { return sprite; }
    public string GetNPCName() 
        { return npcName; }
    public void GetInteractionWindowToggle()
    {
        talkManager.InteractionWindowToggle();
    }
    public int GetTalkIndex()
        { return talkIndex; }
}
