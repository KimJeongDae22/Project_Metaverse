using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    private Dictionary<string, string[]> talkList;
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
    [SerializeField] private bool isEventTrigger = false;

    public static TalkManager instance;
    private void Awake()
    {
        talkList = new Dictionary<string, string[]>();
        InitTalkData();
        if (instance == null)

        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
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
        // �̺�Ʈ Ʈ����
        talkList.Add(NpcName.EventTrigger, new string[]
            {"���� ���� Ư���� ���̴� �׷��ͱⰡ �ִ�. �ѹ� ���캼��?"});
        talkList.Add(NpcName.DanGeun, new string[]
            {"��� �ʸӷ�! �̴� ������ �����Ͻðڽ��ϱ�?"});
    }
    public void GetTalk(string npcName, string quest, Sprite npcSprite)
    {

        if (!talkWindow.activeSelf)             // ��ȭâ�� Ȱ��ȭ�Ǿ����� ���� ��(ù ��ȭ)
        {
            talkWindow.SetActive(true);
            YesOrNoActive(npcName, talkIndex);  // �������� �ִ� ��ȭ���� �Ǻ�
            if (GetInteractionWindow())         
                InteractionWindowToggle();
            else
                isEventTrigger = true;          // �̺�Ʈ Ʈ���� ���� �ڵ�
            Player_Move.instance.GetIsTalkingToggle();
            InitYesOrNo();                      // ������ �Ǻ��� ���� ������ ������Ʈ Ȱ��ȭ
            talkObjectName.text = "[" + npcName + "]";
            talkProfile.sprite = npcSprite;
            talkText.text = talkList[npcName + quest][talkIndex];
        }
        else                                    // ù ��ȭ ���� 
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
                talkWindow.SetActive(false);    // ��ȭ�� ����ǰ� ���� �ڵ带�� ����
                bool choice = false;
                if (IsYesOrNo)                  // �������� �ִ� ��ȭâ�̾��� ���
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
                if (!GetInteractionWindow() && !isEventTrigger)
                    InteractionWindowToggle();
                Player_Move.instance.GetIsTalkingToggle();
                isEventTrigger = false;
                QuestActive(npcName, talkIndex, choice);    // �������� ���ο� ���� ������ ��� ����
                talkIndex = 0;
            }
        }
    }
    public void InteractionWindowToggle()
    {
        if (!InteractionWindow.activeSelf)
        {
            InteractionWindow.SetActive(true);
            InteractionWindow.transform.position = Player_Move.instance.transform.position;
        }
        else
            InteractionWindow.SetActive(false);
    }
    public bool GetInteractionWindow()
    { return InteractionWindow.activeSelf; }
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
        if (npcName == NpcName.DanGeun)
        {
            switch (index)
            {
                case 0:
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
        if (npcName == NpcName.EventTrigger)
        {
            switch (index - 1)
            {
                case 0:
                    Debug.Log("�̺�Ʈ Ʈ���� ���� �Ϸ�");
                    QuestManager.instance.GetQuestList()[NpcName.EventTrigger].QuestAccept();
                    QuestManager.instance.GetQuestList()[NpcName.EventTrigger].QuestClear();
                    break;
                default:
                    break;
            }
        }
        if (npcName == NpcName.Chonjang)
        {
            switch (index - 1)
            {
                case 5:
                    Debug.Log("���� ����Ʈ �Ϸ�");
                    QuestManager.instance.GetQuestList()[NpcName.Chonjang].QuestClear();
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
                        QuestManager.instance.GetQuestList()[NpcName.Chonjang].QuestAccept();
                    }
                    break;
                default:
                    break;
            }
        }
        if (npcName == NpcName.DanGeun)
        {
            switch (index - 1)
            {
                case 0:
                    if (choice)
                    {
                        SceneChanger.instance.ChangeScene_MiniGame();
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
