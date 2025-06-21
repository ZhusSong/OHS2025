using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(BoxCollider))]
public class ClickToBag : MonoBehaviour
{
    [Tooltip("将被当作父物体的 Bag（背包）对象")]
    public Transform bagTransform;

    [Tooltip("场景中挂有 BagManager 的对象")]
    public BagManager bagManager;

    [Tooltip("点击后缩放到的大小")]
    public Vector3 targetScale = new Vector3(0.2f, 0.25f, 1f);  // ← 可调节缩放数值

    private RectTransform _rectTransform;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        if (_rectTransform == null)
            Debug.LogError("ClickToBag 脚本需要挂载在带有 RectTransform 的 UI 物体上！");
    }

    void OnMouseDown()
    {
        transform.localScale = targetScale;  // ← 使用 Inspector 可调的值

        if (bagTransform == null || bagManager == null)
        {
            Debug.LogError("请确保 BagTransform 和 BagManager 已在 Inspector 中正确设置！");
            return;
        }

        transform.SetParent(bagTransform, false);

        Vector2 slotPos = _rectTransform.anchoredPosition;

       
    }
}
