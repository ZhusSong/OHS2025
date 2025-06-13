using UnityEngine;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects; // インスペクターに19個セット

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
    public void ShowObject15() { ShowObjectByIndex(14); }
    public void ShowObject16() { ShowObjectByIndex(15); }
    public void ShowObject17() { ShowObjectByIndex(16); }
    public void ShowObject18() { ShowObjectByIndex(17); }
    public void ShowObject19() { ShowObjectByIndex(18); }
    public void ShowObject20() { ShowObjectByIndex(19); }
    public void ShowObject21() { ShowObjectByIndex(20); }
    public void ShowObject22() { ShowObjectByIndex(21); }
    public void ShowObject23() { ShowObjectByIndex(22); }
    public void ShowObject24() { ShowObjectByIndex(23); }
    public void ShowObject25() { ShowObjectByIndex(24); }
    public void ShowObject26() { ShowObjectByIndex(25); }

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
