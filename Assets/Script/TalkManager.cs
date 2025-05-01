using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    private Dictionary<string, string[]> talkList;
    [SerializeField] private Player_Move player;

    [SerializeField] private GameObject talkWindow;
    [SerializeField] private Text talkObjectName;
    [SerializeField] private Image talkProfile;
    [SerializeField] private Text talkText;
    [SerializeField] private int talkIndex = 0;

    [SerializeField] private GameObject InteractionWindow;
    private void Awake()
    {
        talkList = new Dictionary<string, string[]>();
        GetTalkData();
    }
    private void GetTalkData()
    {
        talkList.Add(NpcName.Chonjang, new string[]
        { "안녕하신가 이 곳은 처음인 모양인게로군.",
            "여기는 토깽이마을이라고 한다네, 난 이 곳의 촌장일세." });
    }
    public void GetTalk(string npcName, Sprite npcSprite)
    {

        if (!talkWindow.activeSelf)
        {
            talkWindow.SetActive(true);
            player.GetInteractionWindowToggle();
            player.GetIsTalkingToggle();
            talkIndex = 0;
            talkObjectName.text = "[" + npcName + "]";
            talkProfile.sprite = npcSprite;
            talkText.text = talkList[npcName][talkIndex];
        }
        else
        {
            talkIndex += 1;
            if (talkIndex < talkList[npcName].Length)
            {
                talkText.text = talkList[npcName][talkIndex];
            }
            else
            {
                talkWindow.SetActive(false);
                talkIndex = 0;
                player.GetInteractionWindowToggle();
                player.GetIsTalkingToggle();
            }
        }
    }
    public void InteractionWindowToggle()
    {
        if (!InteractionWindow.activeSelf)
        {
            InteractionWindow.SetActive(true);
            InteractionWindow.transform.position = player.transform.position;
        }
        else
            InteractionWindow.SetActive(false);
    }

    public Dictionary<string, string[]> GetTaklList()
    { return talkList; }
}
