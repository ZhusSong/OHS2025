using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject menuWindow;
    public Button openMenuButton;
    public Button selectSceneButton;
    public Button saveButton;
    public Button backButton;

    void Start()
    {
        menuWindow.SetActive(false); // �ŏ��͔�\��

        openMenuButton.onClick.AddListener(() => menuWindow.SetActive(true));
        selectSceneButton.onClick.AddListener(() => SceneManager.LoadScene("SelectScene"));
        saveButton.onClick.AddListener(() => Debug.Log("�Z�[�u�@�\�͂܂��������ł�"));
        backButton.onClick.AddListener(() => menuWindow.SetActive(false));
    }
}

