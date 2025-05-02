using UnityEngine;

public class Quest : MonoBehaviour
{
    private bool acceptQuest = false;
    private bool clearQuest = false;
    public bool GetAcceptQuest()
    { return acceptQuest; }
    public void QuestAccept()
    { acceptQuest = true; }
    public bool GetClearQuest()
    { return clearQuest; }
    public void QuestClear()
    { clearQuest = true; }
}
