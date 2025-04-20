using UnityEngine;

public class UIController : MonoBehaviour
{
    // インスペクターで設定するUIオブジェクト
    [SerializeField] private GameObject targetUI;

    // UIを表示する
    public void ShowUI()
    {
        if (targetUI != null)
        {
            targetUI.SetActive(true);
        }
    }

    // UIを非表示にする
    public void HideUI()
    {
        if (targetUI != null)
        {
            targetUI.SetActive(false);
        }
    }

    // UIの表示/非表示を切り替える
    public void ToggleUI()
    {
        if (targetUI != null)
        {
            targetUI.SetActive(!targetUI.activeSelf);
        }
    }
}
