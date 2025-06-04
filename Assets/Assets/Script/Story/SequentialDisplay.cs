using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialDisplay : MonoBehaviour
{
    [Header("�\������GameObject���X�g�i���Ԃɐݒ�j")]
    public List<GameObject> objectsToDisplay;

    [Header("�ŏ��̑ҋ@���ԁi�b�j")]
    public float delaySeconds = 1.0f;

    [Header("�؂�ւ��Ԋu�i�b�j")]
    public float intervalSeconds = 1.0f;

    private Coroutine sequenceCoroutine;

    // �O�����炱�̊֐����Ă�ŊJ�n�ł���
    public void StartSequence()
    {
        if (sequenceCoroutine != null)
        {
            StopCoroutine(sequenceCoroutine);
        }

        HideAll();

        if (objectsToDisplay.Count > 0)
        {
            sequenceCoroutine = StartCoroutine(DisplaySequence());
        }
    }

    private IEnumerator DisplaySequence()
    {
        yield return new WaitForSeconds(delaySeconds);

        for (int i = 0; i < objectsToDisplay.Count; i++)
        {
            HideAll();

            if (objectsToDisplay[i] != null)
            {
                objectsToDisplay[i].SetActive(true);
            }

            if (i < objectsToDisplay.Count - 1)
            {
                yield return new WaitForSeconds(intervalSeconds);
            }
            else
            {
                yield return new WaitForSeconds(intervalSeconds);
                HideAll();
            }
        }

        sequenceCoroutine = null;
    }

    private void HideAll()
    {
        foreach (GameObject obj in objectsToDisplay)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }
}
