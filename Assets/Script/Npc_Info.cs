using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class Npc_Info : MonoBehaviour
{
    [SerializeField] protected string npcName;
    [SerializeField] protected string questName;
    [SerializeField] protected Sprite sprite;
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
        TalkManager.instance.InteractionWindowToggle();
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_Move.instance.talkObject = this.gameObject;
            Player_Move.instance.talkAble = true;
            GetInteractionWindowToggle();
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_Move.instance.talkObject = null;
            Player_Move.instance.talkAble = false;
            GetInteractionWindowToggle();
        }
    }
}
