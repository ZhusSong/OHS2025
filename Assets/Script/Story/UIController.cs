using UnityEngine;

public class UIController : MonoBehaviour
{
    // �C���X�y�N�^�[�Őݒ肷��UI�I�u�W�F�N�g
    [SerializeField] private GameObject targetUI;

    // UI��\������
    public void ShowUI()
    {
        if (targetUI != null)
        {
            targetUI.SetActive(true);
        }
    }

    // UI���\���ɂ���
    public void HideUI()
    {
        if (targetUI != null)
        {
            targetUI.SetActive(false);
        }
    }

    // UI�̕\��/��\����؂�ւ���
    public void ToggleUI()
    {
        if (targetUI != null)
        {
            targetUI.SetActive(!targetUI.activeSelf);
        }
    }
}
