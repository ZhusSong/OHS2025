using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private GameObject gameobject0; // インスペクターで設定するオブジェクト
    [SerializeField] private GameObject gameobject1; // インスペクターで設定するオブジェクト
    [SerializeField] private GameObject gameobject2; // インスペクターで設定するオブジェクト

    void Start()
    {
        HideAllObjects(); // 初期状態で全て非表示
    }

    public void GameObject0()
    {
        HideAllObjects();
        gameobject0.SetActive(true);
    }

    public void GameObject1()
    {
        HideAllObjects();
        gameobject1.SetActive(true);
    }

    public void GameObject2()
    {
        HideAllObjects();
        gameobject2.SetActive(true);
    }

    private void HideAllObjects()
    {
        gameobject0.SetActive(false);
        gameobject1.SetActive(false);
        gameobject2.SetActive(false);
    }
}
