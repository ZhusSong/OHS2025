using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FadeAllObjectsAndPlayVideo : MonoBehaviour
{
    [Header("順番にフェードする GameObjects（Renderer 必須）")]
    public List<GameObject> objectsToFade;

    [Header("1ステップのフェード時間（秒）")]
    public float fadeDuration = 1f;

    [Header("ステップ間の待機時間（秒）")]
    public float waitTime = 0.5f;

    [Header("動画再生前の待機時間（秒）")]
    public float videoWaitTime = 2f;

    [Header("動画を含む GameObject（VideoPlayer 必須）")]
    public GameObject videoContainer;

    private VideoPlayer videoPlayer;

    void Awake()
    {
        // videoContainer から VideoPlayer を取得
        if (videoContainer != null)
        {
            videoPlayer = videoContainer.GetComponent<VideoPlayer>();
            videoContainer.SetActive(false);
        }

        if (videoPlayer != null)
        {
            videoPlayer.Stop();
        }

        // フェード対象を初期化（非表示＆透明）
        foreach (var obj in objectsToFade)
        {
            if (obj != null)
            {
                obj.SetActive(false);
                SetAlpha(obj, 0f);
            }
        }
    }

    // この関数を呼ぶと処理が始まる
    public void StartFadeAndPlayVideo()
    {
        StartCoroutine(PlaySequenceForAll());
    }

    IEnumerator PlaySequenceForAll()
    {
        foreach (GameObject obj in objectsToFade)
        {
            if (obj == null) continue;

            obj.SetActive(true);
            SetAlpha(obj, 0f);

            yield return StartCoroutine(FadeObject(obj, 0f, 0.5f));
            yield return new WaitForSeconds(waitTime);

            yield return StartCoroutine(FadeObject(obj, 0.5f, 1f));
            yield return new WaitForSeconds(waitTime);

            yield return StartCoroutine(FadeObject(obj, 1f, 0.5f));
            yield return new WaitForSeconds(waitTime);

            yield return StartCoroutine(FadeObject(obj, 0.5f, 0f));
            obj.SetActive(false);
            yield return new WaitForSeconds(waitTime);
        }

        if (videoContainer != null && videoPlayer != null)
        {
            videoContainer.SetActive(true);
            videoPlayer.Play();

            yield return new WaitForSeconds(videoWaitTime);

            videoContainer.SetActive(false);
        }
    }

    IEnumerator FadeObject(GameObject obj, float fromAlpha, float toAlpha)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer == null) yield break;

        Material mat = renderer.material;
        float time = 0f;

        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(fromAlpha, toAlpha, time / fadeDuration);
            SetAlpha(mat, alpha);
            time += Time.deltaTime;
            yield return null;
        }

        SetAlpha(mat, toAlpha);
    }

    void SetAlpha(GameObject obj, float alpha)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer == null) return;

        Material mat = renderer.material;
        SetAlpha(mat, alpha);
    }

    void SetAlpha(Material mat, float alpha)
    {
        if (mat.HasProperty("_Color"))
        {
            Color color = mat.color;
            color.a = alpha;
            mat.color = color;
        }
    }
}
