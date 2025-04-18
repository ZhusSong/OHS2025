using UnityEngine;
using Fungus;
using System.Collections.Generic;

public class ItemDialogueHandler : MonoBehaviour
{
    public string[] keyNames = { "key" };

    [Tooltip("点击检测到 Key 时发送给 Fungus 的消息名称")]
    public List<string> Messages1 = new List<string>();


    public Flowchart flowchart;

    private void OnMouseDown()
    {
        bool foundKey = false;
        GameObject bag = GameObject.Find("bag");
        if (bag != null)
        {
            foreach (Transform child in bag.transform)
            {
                foreach (string keyName in keyNames)
                {
                    if (child.name == keyName)
                    {
                        Destroy(child.gameObject);
                        foundKey = true;
                        break;
                    }
                }
                if (foundKey) break;
            }
        }
            

        if (foundKey)
        {
            foreach (string message in Messages1)
            {
                flowchart.SendFungusMessage(message);
                Debug.Log("道具点击检测到 key，发送NoKeyDialogue消息");

            }
        }

        else
        {
            foreach (string message in Messages1)
            {
                flowchart.SendFungusMessage(message);
                Debug.Log("道具点击未检测到 key，发送UnlockedDialogue消息");
            }
         
        }
    }
}
