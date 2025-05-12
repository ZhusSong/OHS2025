using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ParentsRoom_Minigame : MonoBehaviour
{
    public GameObject ClosetButton_1;
    public GameObject ClosetButton_2;
    public GameObject ClosetButton_3;
    public GameObject ClosetButton_4;

    private Exploration02ButtonManager Closet_Minigame_Ex02Manager;

    private int[] ClosetPassword = { 0, 0, 0, 0 };
    // Start is called before the first frame update
    void Start()
    {
        Closet_Minigame_Ex02Manager = this.GetComponent<Exploration02ButtonManager>();

        ClosetButton_1.GetComponent<Button>().onClick.AddListener(() => OnClosetButton01Click());
        ClosetButton_2.GetComponent<Button>().onClick.AddListener(() => OnClosetButton02Click());
        ClosetButton_3.GetComponent<Button>().onClick.AddListener(() => OnClosetButton03Click());
        ClosetButton_4.GetComponent<Button>().onClick.AddListener(() => OnClosetButton04Click());

    }

    void OnClosetButton01Click()
    {
        Closet_Minigame_Ex02Manager.Exploration_AudioManager.Se03Play();
        ClosetPassword[0] = (ClosetPassword[0] == 3) ? 0 : (ClosetPassword[0] + 1);
        switch (ClosetPassword[0])
        {
            case 0:
                ClosetButton_1.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_ParentsRoom_Closet_square");

                break;
            case 1:
                ClosetButton_1.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_ParentsRoom_closet_X");

                break;
            case 2:
                ClosetButton_1.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_ParentsRoom_closet_circle");

                break;
            case 3:
                ClosetButton_1.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_ParentsRoom_closet_triangle");

                break;
        }

        CheckPassword();
    }
    void OnClosetButton02Click()
    {
        Closet_Minigame_Ex02Manager.Exploration_AudioManager.Se03Play();
        ClosetPassword[1] = (ClosetPassword[1] == 3) ? 0 : (ClosetPassword[1] + 1);
        switch (ClosetPassword[1])
        {
            case 0:
                ClosetButton_2.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_ParentsRoom_Closet_square");

                break;
            case 1:
                ClosetButton_2.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_ParentsRoom_closet_X");

                break;
            case 2:
                ClosetButton_2.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_ParentsRoom_closet_circle");

                break;
            case 3:
                ClosetButton_2.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_ParentsRoom_closet_triangle");

                break;
        }
        CheckPassword();

    }
    void OnClosetButton03Click()
    {
        Closet_Minigame_Ex02Manager.Exploration_AudioManager.Se03Play();
        ClosetPassword[2] = (ClosetPassword[2] == 3) ? 0 : (ClosetPassword[2] + 1);
        switch (ClosetPassword[2])
        {
            case 0:
                ClosetButton_3.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_ParentsRoom_Closet_square");

                break;
            case 1:
                ClosetButton_3.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_ParentsRoom_closet_X");

                break;
            case 2:
                ClosetButton_3.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_ParentsRoom_closet_circle");

                break;
            case 3:
                ClosetButton_3.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_ParentsRoom_closet_triangle");

                break;
        }
        CheckPassword();

    }
    void OnClosetButton04Click()
    {
        Closet_Minigame_Ex02Manager.Exploration_AudioManager.Se03Play();
        ClosetPassword[3] = (ClosetPassword[3] == 3) ? 0 : (ClosetPassword[3] + 1);
        switch (ClosetPassword[3])
        {
            case 0:
                ClosetButton_4.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_ParentsRoom_Closet_square");

                break;
            case 1:
                ClosetButton_4.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_ParentsRoom_closet_X");

                break;
            case 2:
                ClosetButton_4.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_ParentsRoom_closet_circle");

                break;
            case 3:
                ClosetButton_4.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_ParentsRoom_closet_triangle");

                break;
        }
        CheckPassword();
    }
    void CheckPassword()
    {
        if (ClosetPassword[0] == 3 && ClosetPassword[1] == 1 &&
          ClosetPassword[2] == 2 && ClosetPassword[3] ==3)
        {
            ClosetButton_1.SetActive(false);
            ClosetButton_2.SetActive(false);
            ClosetButton_3.SetActive(false);
            ClosetButton_4.SetActive(false);
            Closet_Minigame_Ex02Manager.OpenCloset();
        }
    }
}
