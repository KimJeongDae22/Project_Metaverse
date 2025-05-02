using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private Dictionary<string, Quest> QuestList = new Dictionary<string, Quest>();
    private void Awake()
    {
        InitQuestData();
    }
    private void InitQuestData()
    {
        QuestList.Add(NpcName.EventTrigger, new Quest());
        QuestList.Add(NpcName.Chonjang, new Quest());
    }
    public Dictionary<string, Quest> GetQuestList()
    { return QuestList; }
}
