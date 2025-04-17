using UnityEngine;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects; // インスペクターに13個セット

    void Start()
    {
        HideAllObjects();
    }

    private void HideAllObjects()
    {
        foreach (var obj in gameObjects)
        {
            obj.SetActive(false);
        }
    }

    public void ShowObject1() { ShowObjectByIndex(0); }
    public void ShowObject2() { ShowObjectByIndex(1); }
    public void ShowObject3() { ShowObjectByIndex(2); }
    public void ShowObject4() { ShowObjectByIndex(3); }
    public void ShowObject5() { ShowObjectByIndex(4); }
    public void ShowObject6() { ShowObjectByIndex(5); }
    public void ShowObject7() { ShowObjectByIndex(6); }
    public void ShowObject8() { ShowObjectByIndex(7); }
    public void ShowObject9() { ShowObjectByIndex(8); }
    public void ShowObject10() { ShowObjectByIndex(9); }
    public void ShowObject11() { ShowObjectByIndex(10); }
    public void ShowObject12() { ShowObjectByIndex(11); }
    public void ShowObject13() { ShowObjectByIndex(12); }
    public void ShowObject14() { ShowObjectByIndex(13); }

    private void ShowObjectByIndex(int index)
    {
        if (index < 0 || index >= gameObjects.Length)
        {
            Debug.LogWarning("Index out of range: " + index);
            return;
        }

        HideAllObjects();
        gameObjects[index].SetActive(true);
    }
}
