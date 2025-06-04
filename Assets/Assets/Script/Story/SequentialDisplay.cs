using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialDisplay : MonoBehaviour
{
    [Header("表示するGameObjectリスト（順番に設定）")]
    public List<GameObject> objectsToDisplay;

    [Header("最初の待機時間（秒）")]
    public float delaySeconds = 1.0f;

    [Header("切り替え間隔（秒）")]
    public float intervalSeconds = 1.0f;

    private Coroutine sequenceCoroutine;

    // 外部からこの関数を呼んで開始できる
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
