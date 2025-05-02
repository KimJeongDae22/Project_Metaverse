using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_EventTrigger : Information
{
    private bool isevent = false;
    protected override void Awake()
    {
        base.Awake();
        npcName = NpcName.EventTrigger;
        sprite = GetComponent<SpriteRenderer>().sprite;
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isevent)
            {
                Player_Move.instance.talkObject = this.gameObject;
                Player_Move.instance.talkAble = true;
                TalkManager.instance.GetTalk(npcName, questName, sprite);
                isevent = true;
            }
        }
    }
    protected override void OnTriggerExit2D(Collider2D collision)
    { 
    }
    protected void FixedUpdate()
    {
        if (QuestManager.instance.GetQuestList()[NpcName.EventTrigger].GetClearQuest())
        {
            Player_Move.instance.talkObject = null;
            Player_Move.instance.talkAble = false;
            Destroy(this.gameObject);
        }
    }
}
