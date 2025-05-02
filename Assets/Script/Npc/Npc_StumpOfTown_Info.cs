using UnityEngine;

public class Npc_StumpOfTown_Info : Information
{

    protected override void Awake()
    {
        base.Awake();
        npcName = NpcName.StumpOfTown;
        sprite = GetComponent<SpriteRenderer>().sprite;
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_Move.instance.talkObject = this.gameObject;
            Player_Move.instance.talkAble = true;
            GetInteractionWindowToggle();
        }
    }
    protected void FixedUpdate()
    {
        if (QuestManager.instance.GetQuestList()[NpcName.Chonjang].GetAcceptQuest())
            questName = QuestName.Accept;
        if (QuestManager.instance.GetQuestList()[NpcName.Chonjang].GetClearQuest())
            questName = QuestName.Clear;
    }
}
