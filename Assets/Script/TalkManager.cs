using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    private Dictionary<string, string[]> talkList;
    [SerializeField] private Player_Move player;
    [SerializeField] private QuestManager questManager;
    [SerializeField] private GameObject talkWindow;

    [SerializeField] private GameObject YesOrNo;
    [SerializeField] private GameObject Yes;
    [SerializeField] private GameObject No;
    [SerializeField] private GameObject currentChoice;

    [SerializeField] private Text talkObjectName;
    [SerializeField] private Image talkProfile;
    [SerializeField] private Text talkText;
    [SerializeField] private int talkIndex = 0;
    [SerializeField] private bool IsYesOrNo = false;

    [SerializeField] private GameObject InteractionWindow;
    private void Awake()
    {
        talkList = new Dictionary<string, string[]>();
        InitTalkData();
    }
    private void InitTalkData()
    {
        // 촌장
        talkList.Add(NpcName.Chonjang, new string[]
        { "안녕하신가 이 곳은 처음인 모양인게로군."
        , "여기는 토깽이마을이라고 한다네, 난 이 곳의 촌장일세."
        , "자네 마음대로 마을을 한번 다녀보게나~"});
        talkList.Add(NpcName.Chonjang + QuestName.Accept, new string[]
            {"아..그루터기 말인가. 휘황찬란한 사연이 있는 건 아닐세."
            , "내가 아기 토끼였던 시절 큰 화재가 있었네. 현재 그루터기가 있는 곳이 내가 살던 터전이었지"
            , "우리 가족이 다치는 것은 둘째 치고 큰 화재로 번질 뻔 했지만 당시 거대했던 나무가 불을 받아들인 것처럼 나무만 홀랑 타버리고 사태가 마무리되었네"
            , "그렇게 터만 남아버린 나무가 되었지. 보답이라 할 건 아니지만 지금까지 마을을 지킨 것도 있지~"
            , "어떤가? 막 감동스런 이야기는 아니었지않나? 그래도 마을을 다시 보면 느낌이 다를 걸세. 자네가 편할 때 언제든 오고가고 하려무나~ "
            , "\"사연을 듣고 난 당신은 은은한 마음 속 포근거림을 느꼈다.\" "});
        talkList.Add(NpcName.Chonjang + QuestName.Clear, new string[]
            {"허허허. 언제든 머물렀다 가게나~"});
        // 그루터기
        talkList.Add(NpcName.StumpOfTown, new string[]
            {"마을에서 신성시하는 나무...였던 그루터기이다."
            , "과연 어떤 사연이 있었길래 현재는 이렇게만 남아있는걸까..."
            , "...촌장님께 물어볼까?"});
        talkList.Add(NpcName.StumpOfTown + QuestName.Accept, new string[]
            {"촌장님께 그루터기의 사연을 물어보자."});
        talkList.Add(NpcName.StumpOfTown + QuestName.Clear, new string[]
            {"사연을 알게 된 그루터기에서 마음의 포근함이 느껴진다."});
    }
    public void GetTalk(string npcName, string quest, Sprite npcSprite)
    {

        if (!talkWindow.activeSelf)
        {
            talkWindow.SetActive(true);
            YesOrNoActive(npcName, talkIndex);
            InteractionWindowToggle();
            player.GetIsTalkingToggle();
            InitYesOrNo();
            talkObjectName.text = "[" + npcName + "]";
            talkProfile.sprite = npcSprite;
            talkText.text = talkList[npcName + quest][talkIndex];
        }
        else
        {
            talkIndex += 1;
            if (talkIndex < talkList[npcName + quest].Length)
            {
                YesOrNoActive(npcName + quest, talkIndex);
                talkText.text = talkList[npcName + quest][talkIndex];
                InitYesOrNo();
            }
            else
            {
                talkWindow.SetActive(false);
                bool choice = false;
                if (IsYesOrNo)
                {
                    if (currentChoice == No)
                    {
                        Debug.Log("선택지 : 아니오");
                        choice = false;
                    }
                    else
                    {
                        Debug.Log("선택지 : 네");
                        choice = true;
                    }
                    IsYesOrNo = false;
                }
                QuestActive(npcName, talkIndex, choice);
                talkIndex = 0;
                InteractionWindowToggle();
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
    public bool GetIsYesOrNo()
    { return IsYesOrNo; }
    private void InitYesOrNo()
    {
        if (IsYesOrNo)
            YesOrNo.SetActive(true);
        else
            YesOrNo.SetActive(false);
        currentChoice = Yes;
        YesOrNoToggle();
    }
    public void YesOrNoToggle()
    {
        if (currentChoice == No)
        {
            Yes.GetComponentInChildren<Text>().color = Color.black;
            No.GetComponentInChildren<Text>().color = Color.white;
            currentChoice = Yes;
        }
        else
        {
            Yes.GetComponentInChildren<Text>().color = Color.white;
            No.GetComponentInChildren<Text>().color = Color.black;
            currentChoice = No;
        }
    }
    private void YesOrNoActive(string npcName, int index)
    {
        if (npcName == NpcName.StumpOfTown)
        {
            switch (index)
            {
                case 2:
                    IsYesOrNo = true;
                    break;
                default:
                    IsYesOrNo = false;
                    break;
            }
        }
    }
    private void QuestActive(string npcName, int index, bool choice)
    {
        if (npcName == NpcName.Chonjang)
        {
            switch (index - 1)
            {
                case 5:
                    Debug.Log("촌장 퀘스트 완료");
                    questManager.GetQuestList()[NpcName.Chonjang].QuestClear();
                    break;
                default:
                    break;
            }
        }
        if (npcName == NpcName.StumpOfTown)
        {
            switch (index - 1)
            {
                case 2:
                    if (choice)
                    {
                        Debug.Log("촌장 대화 변경");
                        questManager.GetQuestList()[NpcName.Chonjang].QuestAccept();
                    }
                    break;
                default:
                    break;
            }
        }
    }
    public Dictionary<string, string[]> GetTaklList()
    { return talkList; }
}
