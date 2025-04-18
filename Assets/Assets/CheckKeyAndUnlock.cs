using UnityEngine;
using Fungus;

public class ItemDialogueHandler : MonoBehaviour
{
    public string[] keyNames = { "key" };

    public Flowchart flowchart;

    private void OnMouseDown()
    {
        bool foundKey = false;

        foreach (Transform child in transform)
        {
            foreach (string keyName in keyNames)
            {
                if (child.name == keyName)
                {
                    Destroy(child.gameObject);
                    foundKey = true;
                }
            }
        }

        if (foundKey)
        {
            flowchart.SendFungusMessage("Unlocked"); 
            Debug.Log("道具点击检测到 key，发送NoKeyDialogue消息");
        }

        else
        {
            flowchart.SendFungusMessage("NoKey");
            Debug.Log("道具点击未检测到 key，发送UnlockedDialogue消息");
        }
    }
}
