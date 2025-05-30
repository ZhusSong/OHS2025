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
        menuWindow.SetActive(false); // 最初は非表示

        openMenuButton.onClick.AddListener(() => menuWindow.SetActive(true));
        selectSceneButton.onClick.AddListener(() => SceneManager.LoadScene("SelectScene"));
        saveButton.onClick.AddListener(() => Debug.Log("セーブ機能はまだ未実装です"));
        backButton.onClick.AddListener(() => menuWindow.SetActive(false));
    }
}

