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
        // ����
        talkList.Add(NpcName.Chonjang, new string[]
        { "�ȳ��ϽŰ� �� ���� ó���� ����ΰԷα�."
        , "����� �䲤�̸����̶�� �Ѵٳ�, �� �� ���� �����ϼ�."
        , "�ڳ� ������� ������ �ѹ� �ٳຸ�Գ�~"});
        talkList.Add(NpcName.Chonjang + QuestName.Accept, new string[]
            {"��..�׷��ͱ� ���ΰ�. ��Ȳ������ �翬�� �ִ� �� �ƴҼ�."
            , "���� �Ʊ� �䳢���� ���� ū ȭ�簡 �־���. ���� �׷��ͱⰡ �ִ� ���� ���� ��� �����̾���"
            , "�츮 ������ ��ġ�� ���� ��° ġ�� ū ȭ��� ���� �� ������ ��� �Ŵ��ߴ� ������ ���� �޾Ƶ��� ��ó�� ������ Ȧ�� Ÿ������ ���°� �������Ǿ���"
            , "�׷��� �͸� ���ƹ��� ������ �Ǿ���. �����̶� �� �� �ƴ����� ���ݱ��� ������ ��Ų �͵� ����~"
            , "���? �� �������� �̾߱�� �ƴϾ����ʳ�? �׷��� ������ �ٽ� ���� ������ �ٸ� �ɼ�. �ڳװ� ���� �� ������ ������ �Ϸ�����~ "
            , "\"�翬�� ��� �� ����� ������ ���� �� ���ٰŸ��� ������.\" "});
        talkList.Add(NpcName.Chonjang + QuestName.Clear, new string[]
            {"������. ������ �ӹ����� ���Գ�~"});
        // �׷��ͱ�
        talkList.Add(NpcName.StumpOfTown, new string[]
            {"�������� �ż����ϴ� ����...���� �׷��ͱ��̴�."
            , "���� � �翬�� �־��淡 ����� �̷��Ը� �����ִ°ɱ�..."
            , "...����Բ� �����?"});
        talkList.Add(NpcName.StumpOfTown + QuestName.Accept, new string[]
            {"����Բ� �׷��ͱ��� �翬�� �����."});
        talkList.Add(NpcName.StumpOfTown + QuestName.Clear, new string[]
            {"�翬�� �˰� �� �׷��ͱ⿡�� ������ �������� ��������."});
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
                        Debug.Log("������ : �ƴϿ�");
                        choice = false;
                    }
                    else
                    {
                        Debug.Log("������ : ��");
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
                    Debug.Log("���� ����Ʈ �Ϸ�");
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
                        Debug.Log("���� ��ȭ ����");
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
