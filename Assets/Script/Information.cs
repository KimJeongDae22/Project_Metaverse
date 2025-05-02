using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    [SerializeField] protected string npcName;
    [SerializeField] protected string questName;
    [SerializeField] protected Sprite sprite;
    [SerializeField] protected Player_Move player;
    [SerializeField] protected TalkManager talkManager;

    [SerializeField] protected QuestManager quest;
    protected virtual void Awake()
    {
    }
    public Sprite GetSprite()
        { return sprite; }
    public string GetNPCName() 
        { return npcName; }
    public string GetQuestName()
        { return questName; }
    public void GetInteractionWindowToggle()
    {
        talkManager.InteractionWindowToggle();
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.talkObject = this.gameObject;
            player.talkAble = true;
            GetInteractionWindowToggle();
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.talkObject = null;
            player.talkAble = false;
            GetInteractionWindowToggle();
        }
    }
}
