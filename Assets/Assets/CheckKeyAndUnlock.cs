using UnityEngine;

public class ItemClickHide : MonoBehaviour
{
    public string[] keyNames = { "key" };
    public CharacterDialogue characterDialogue;

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
            if (characterDialogue != null)
            {
                //キャラクターの状態を設定
                characterDialogue.currentState = DialogueState.Unlocked;
                characterDialogue.ShowDialogue();
            }
            //Destroy(this.gameObject);  道具を解けた後の処理
        }
        else
        {
            if (characterDialogue != null)
            {
                //キャラクターの状態を設定
                characterDialogue.currentState = DialogueState.NoKey;
                characterDialogue.ShowDialogue();
            }
            Debug.Log("未检测到 key 道具！");
        }
    }
}
