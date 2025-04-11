using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum DialogueState
{
    Standby,
    NoKey,
    Prompt2,
    Unlocked
}

public class CharacterDialogue : MonoBehaviour
{
    public Text dialogueText;

    public string[] standbyDialogue;
    public string[] noKeyDialogue;
    public string[] prompt2Dialogue;
    public string[] unlockedDialogue;

    private int currentLine = 0;
    public float displayTime = 3f;

    public DialogueState currentState = DialogueState.Standby;

    private string[] GetDialogueLinesForState(DialogueState state)
    {
        switch (state)
        {
            case DialogueState.NoKey:
                return noKeyDialogue;
            case DialogueState.Prompt2:
                return prompt2Dialogue;
            case DialogueState.Unlocked:
                return unlockedDialogue;
            case DialogueState.Standby:
            default:
                return standbyDialogue;
        }
    }

    private void OnMouseDown()
    {
        ShowDialogue();
        Debug.Log("角色被点击, 当前状态: " + currentState.ToString());
    }

    public void ShowDialogue()
    {
        string[] dialogueLines = GetDialogueLinesForState(currentState);
        if (dialogueLines != null && dialogueLines.Length > 0)
        {
            dialogueText.text = dialogueLines[currentLine];
            currentLine = (currentLine + 1) % dialogueLines.Length;

            StartCoroutine(HideDialogueAfterSeconds(displayTime));

            currentState = DialogueState.Standby;
        }
    }

    private IEnumerator HideDialogueAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dialogueText.text = "";
    }
}
