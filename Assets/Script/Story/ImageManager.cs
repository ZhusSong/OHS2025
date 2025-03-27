using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private GameObject gameobject0; // �C���X�y�N�^�[�Őݒ肷��I�u�W�F�N�g
    [SerializeField] private GameObject gameobject1; // �C���X�y�N�^�[�Őݒ肷��I�u�W�F�N�g
    [SerializeField] private GameObject gameobject2; // �C���X�y�N�^�[�Őݒ肷��I�u�W�F�N�g

    void Start()
    {
        HideAllObjects(); // ������ԂőS�Ĕ�\��
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
