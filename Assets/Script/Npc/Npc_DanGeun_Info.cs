using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_DanGeun_Info : Npc_Info
{
    protected override void Awake()
    {
        base.Awake();
        npcName = NpcName.DanGeun;
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
}
