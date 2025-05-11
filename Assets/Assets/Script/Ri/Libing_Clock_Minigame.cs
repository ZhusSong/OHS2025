using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Libing_Clock_Minigame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ClockButton_1;
    public GameObject ClockButton_2;
    public GameObject ClockButton_3;
    public GameObject ClockButton_4;


    private TextMeshProUGUI ClockPassword_1;
    private TextMeshProUGUI ClockPassword_2;
    private TextMeshProUGUI ClockPassword_3;
    private TextMeshProUGUI ClockPassword_4;


    private Exploration02ButtonManager Clock_Minigame_Ex02Manager;

    private int[] ClockPassword = { 0, 0, 0, 0 };
    void Start()
    {
        Clock_Minigame_Ex02Manager = this.GetComponent<Exploration02ButtonManager>();
        ClockButton_1.GetComponent<Button>().onClick.AddListener(() => OnDrawerButton01Click());
        ClockButton_2.GetComponent<Button>().onClick.AddListener(() => OnDrawerButton02Click());
        ClockButton_3.GetComponent<Button>().onClick.AddListener(() => OnDrawerButton03Click());
        ClockButton_4.GetComponent<Button>().onClick.AddListener(() => OnDrawerButton04Click());

        ClockPassword_1 = ClockButton_1.GetComponentInChildren<TextMeshProUGUI>();
        ClockPassword_2 = ClockButton_2.GetComponentInChildren<TextMeshProUGUI>();
        ClockPassword_3 = ClockButton_3.GetComponentInChildren<TextMeshProUGUI>();
        ClockPassword_4 = ClockButton_4.GetComponentInChildren<TextMeshProUGUI>();

        ClockPassword_1.text = ClockPassword[0].ToString();
        ClockPassword_2.text = ClockPassword[1].ToString();
        ClockPassword_3.text = ClockPassword[2].ToString();
        ClockPassword_4.text = ClockPassword[3].ToString();
    }

    void OnDrawerButton01Click()
    {
        Clock_Minigame_Ex02Manager.Exploration_AudioManager.Se03Play();

        ClockPassword[0] = (ClockPassword[0] == 9) ? 0 : (ClockPassword[0] + 1);

        ClockPassword_1.text = ClockPassword[0].ToString();

        CheckPassword();
    }
    void OnDrawerButton02Click()
    {
        Clock_Minigame_Ex02Manager.Exploration_AudioManager.Se03Play();
        ClockPassword[1] = (ClockPassword[1] == 9) ? 0 : (ClockPassword[1] + 1);
        ClockPassword_2.text = ClockPassword[1].ToString();
        CheckPassword();

    }
    void OnDrawerButton03Click()
    {
        Clock_Minigame_Ex02Manager.Exploration_AudioManager.Se03Play();
        ClockPassword[2] = (ClockPassword[2] == 9) ?0 : (ClockPassword[2] + 1);
        ClockPassword_3.text = ClockPassword[2].ToString();
        CheckPassword();

    }
    void OnDrawerButton04Click()
    {
        Clock_Minigame_Ex02Manager.Exploration_AudioManager.Se03Play();
        ClockPassword[3] = (ClockPassword[3] == 9) ? 0 : (ClockPassword[3] + 1);
        ClockPassword_4.text = ClockPassword[3].ToString();
        CheckPassword();
    }
    void CheckPassword()
    {
        if (ClockPassword[0] == 1 && ClockPassword[1] == 5 &&
           ClockPassword[2] == 3&& ClockPassword[3] == 5)
        { 
            ClockButton_1.SetActive(false);
            ClockButton_2.SetActive(false);
            ClockButton_3.SetActive(false);
            ClockButton_4.SetActive(false);
            Clock_Minigame_Ex02Manager.OpenClock();
        }
    }
}
