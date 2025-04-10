using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterDialogue : MonoBehaviour
{
    public Text dialogueText;
    public string[] dialogueLines;
    private int currentLine = 0;
    public float displayTime = 3f;

    private void OnMouseDown()
    {
        ShowDialogue();
        Debug.Log("角色被点击");
    }

    public void ShowDialogue()
    {
        if (dialogueLines.Length > 0)
        {
            dialogueText.text = dialogueLines[currentLine];
            currentLine = (currentLine + 1) % dialogueLines.Length;

            StartCoroutine(HideDialogueAfterSeconds(displayTime));
        }
    }

    private IEnumerator HideDialogueAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dialogueText.text = "";
    }
}
