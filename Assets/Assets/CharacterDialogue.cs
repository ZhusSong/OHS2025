using UnityEngine;
using Fungus;

public class CharacterStandbyDialogue : MonoBehaviour
{
    //。。
    public Flowchart flowchart;

    private void OnMouseDown()
    {
        flowchart.SendFungusMessage("Standby");
        Debug.Log("角色被点击，发送 StandbyDialogue 消息");
    }
}
