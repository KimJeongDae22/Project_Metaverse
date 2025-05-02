using UnityEngine;

public class Npc_StumpOfTown_Info : Information
{

    protected override void Awake()
    {
        npcName = NpcName.StumpOfTown;
        sprite = GetComponent<SpriteRenderer>().sprite;
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.talkObject = this.gameObject;
            player.talkAble = true;
            GetInteractionWindowToggle();
        }
    }
    protected void FixedUpdate()
    {
        if (quest.GetQuestList()[NpcName.Chonjang].GetAcceptQuest())
            questName = QuestName.Accept;
        if (quest.GetQuestList()[NpcName.Chonjang].GetClearQuest())
            questName = QuestName.Clear;
    }
}
