using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Chonjang_Info : Information
{
    protected override void Awake()
    {
        npcName = NpcName.Chonjang;
        sprite = GetComponent<SpriteRenderer>().sprite;
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.talkObject = this.gameObject;
            player.talkAble = true;
            player.GetInteractionWindowToggle();
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.talkObject = null;
            player.talkAble = false;
            player.GetInteractionWindowToggle();
        }
    }

}
