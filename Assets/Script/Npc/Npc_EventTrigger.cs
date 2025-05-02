using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_EventTrigger : Information
{
    private bool isevent = false;
    protected override void Awake()
    {
        npcName = NpcName.EventTrigger;
        sprite = GetComponent<SpriteRenderer>().sprite;
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isevent)
            {
                player.talkObject = this.gameObject;
                player.talkAble = true;
                talkManager.GetTalk(npcName, questName, sprite);
                isevent = true;
            }
        }
    }
    protected override void OnTriggerExit2D(Collider2D collision)
    {

    }
    protected void FixedUpdate()
    {
        if (quest.GetQuestList()[NpcName.EventTrigger].GetClearQuest())
        {
            player.talkObject = null;
            player.talkAble = false;
            Destroy(this.gameObject);
        }
    }
}
