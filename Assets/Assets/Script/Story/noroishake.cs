using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class noroishake : MonoBehaviour
{
    [SerializeField] private Canvas canvas;  // インスペクターで設定
    [SerializeField] private float duration = 0.5f;  // 揺れの時間（デフォルト 0.5秒）
    [SerializeField] private float magnitude = 10f; // 揺れの大きさ（デフォルト 10）
    [SerializeField] private float darkenAmount = 0.5f; // 暗くする強度（0.0〜1.0）
    [SerializeField] private char charamoji;

    private Transform characterHolder; // CharacterA holder の Transform
    private Image characterImage;
    private Color originalColor;

    // 一定時間キャラクターを揺らす
    public void Shake()
    {
        // characterHolder が未取得の場合のみ取得処理を実行
        if (characterHolder == null)
        {
            FindCharacterHolder();
        }

        if (characterHolder != null)
        {
            StartCoroutine(ShakeCoroutine(duration, magnitude));
        }
    }
    public void DarkenImage()
    {
        if (characterImage == null)
        {
            FindCharacterHolder();
        }

        if (characterImage != null)
        {
            Color darkenedColor = characterImage.color;
            darkenedColor.r *= (1 - darkenAmount);
            darkenedColor.g *= (1 - darkenAmount);
            darkenedColor.b *= (1 - darkenAmount);
            // Alpha(透明度)は変更しない
            characterImage.color = darkenedColor;
        }
    }

    public void ResetImageColor()
    {
        if (characterImage != null)
        {
            characterImage.color = originalColor;
        }
    }

    // CharacterA holder を探す（最初の一回だけ実行）
    private void FindCharacterHolder()
    {
        if (canvas != null)
        {
            Transform holder = canvas.transform.Find("呪怨獣 holder");
            if (holder != null)
            {
                characterHolder = holder;

                // キャラクターのImageコンポーネントを取得
                characterImage = holder.GetComponentInChildren<Image>();
                if (characterImage != null)
                {
                    originalColor = characterImage.color;
                }
                else
                {
                    Debug.LogError("CharacterA holder に Image コンポーネントがありません！");
                }
            }
            else
            {
                Debug.LogError("CharacterA holder が見つかりません！");
            }
        }
        else
        {
            Debug.LogError("Canvas が設定されていません！");
        }
    }

    // 揺れ処理
    private IEnumerator ShakeCoroutine(float shakeDuration, float shakeMagnitude)
    {
        Vector3 originalPosition = characterHolder.localPosition;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-shakeMagnitude, shakeMagnitude);
            float y = Random.Range(-shakeMagnitude, shakeMagnitude);
            characterHolder.localPosition = originalPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // 元の位置に戻す
        characterHolder.localPosition = originalPosition;
    }
}
