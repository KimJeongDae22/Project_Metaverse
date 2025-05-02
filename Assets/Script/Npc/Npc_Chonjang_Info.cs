using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Chonjang_Info : Information
{
    protected override void Awake()
    {
        npcName = NpcName.Chonjang;
        sprite = GetComponent<SpriteRenderer>().sprite;
        talkIndex = 0;
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.talkObject = this.gameObject;
            player.talkAble = true;
            if (quest.GetQuestList()[NpcName.Chonjang].GetAcceptQuest())
                questName = QuestName.Accept;
            if (quest.GetQuestList()[NpcName.Chonjang].GetClearQuest())
                questName = QuestName.Clear;
            GetInteractionWindowToggle();
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.talkObject = null;
            player.talkAble = false;
            GetInteractionWindowToggle();
        }
    }

}
