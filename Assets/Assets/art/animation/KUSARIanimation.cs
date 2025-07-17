using UnityEngine;
using UnityEngine.Video;

public class KUSARIanimation : MonoBehaviour
{
    public GameObject targetObject;

    public void ActivateVideoObject()
    {
        if (targetObject == null)
        {
            Debug.LogWarning("ターゲットのオブジェクトが設定されていません");
            return;
        }

        targetObject.SetActive(true);

        VideoPlayer vp = targetObject.GetComponent<VideoPlayer>();
        if (vp != null)
        {
            vp.enabled = true;
            vp.Play();

            // 再生終了時に非表示にするイベントを追加
            vp.loopPointReached += OnVideoFinished;
        }
        else
        {
            Debug.LogWarning("VideoPlayer コンポーネントが見つかりません");
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        // 対象オブジェクトを非表示にする
        if (targetObject != null)
        {
            targetObject.SetActive(false);
            Debug.Log("動画の再生が終了したため、オブジェクトを非表示にしました");
        }
    }
}
