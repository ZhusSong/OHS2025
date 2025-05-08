using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Shunou_Drawer_Minigame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DrawerButton_1;
    public GameObject DrawerButton_2;
    public GameObject DrawerButton_3;
    public GameObject DrawerButton_4;


    private TextMeshProUGUI DrawerPassword_1;
    private TextMeshProUGUI DrawerPassword_2;
    private TextMeshProUGUI DrawerPassword_3;
    private TextMeshProUGUI DrawerPassword_4;


    private Exploration02ButtonManager Drawer_Minigame_Ex02Manager;

    private int[] DrawerPassword = { 1, 1, 1,1 };
    void Start()
    {
        Drawer_Minigame_Ex02Manager = this.GetComponent<Exploration02ButtonManager>();
        DrawerButton_1.GetComponent<Button>().onClick.AddListener(() => OnDrawerButton01Click());
        DrawerButton_2.GetComponent<Button>().onClick.AddListener(() => OnDrawerButton02Click());
        DrawerButton_3.GetComponent<Button>().onClick.AddListener(() => OnDrawerButton03Click());
        DrawerButton_4.GetComponent<Button>().onClick.AddListener(() => OnDrawerButton04Click());

        DrawerPassword_1 = DrawerButton_1.GetComponentInChildren<TextMeshProUGUI>();
        DrawerPassword_2 = DrawerButton_2.GetComponentInChildren<TextMeshProUGUI>();
        DrawerPassword_3 = DrawerButton_3.GetComponentInChildren<TextMeshProUGUI>();
        DrawerPassword_4 = DrawerButton_4.GetComponentInChildren<TextMeshProUGUI>();

        DrawerPassword_1.text = DrawerPassword[0].ToString();
        DrawerPassword_2.text = DrawerPassword[1].ToString();
        DrawerPassword_3.text = DrawerPassword[2].ToString();
        DrawerPassword_4.text = DrawerPassword[3].ToString();
    }

   void OnDrawerButton01Click()
    {
        Drawer_Minigame_Ex02Manager.Exploration_AudioManager.Se03Play();

        DrawerPassword[0] = (DrawerPassword[0] == 9) ? 1 : (DrawerPassword[0] + 1);

        DrawerPassword_1.text = DrawerPassword[0].ToString();

        CheckPassword();
    }
    void OnDrawerButton02Click()
    {
        Drawer_Minigame_Ex02Manager.Exploration_AudioManager.Se03Play();
        DrawerPassword[1] = (DrawerPassword[1] == 9) ? 1 : (DrawerPassword[1] + 1);
        DrawerPassword_2.text = DrawerPassword[1].ToString();
        CheckPassword();

    }
    void OnDrawerButton03Click()
    {
        Drawer_Minigame_Ex02Manager.Exploration_AudioManager.Se03Play();
        DrawerPassword[2] = (DrawerPassword[2] == 9) ? 1 : (DrawerPassword[2] + 1);
        DrawerPassword_3.text = DrawerPassword[2].ToString();
        CheckPassword();

    }
    void OnDrawerButton04Click()
    {
        Drawer_Minigame_Ex02Manager.Exploration_AudioManager.Se03Play();
        DrawerPassword[3] = (DrawerPassword[3] == 9) ? 1 : (DrawerPassword[3] + 1);
        DrawerPassword_4.text = DrawerPassword[3].ToString();
        CheckPassword();
    }
    void CheckPassword()
    {
        if (DrawerPassword[0]==1&& DrawerPassword[1]== 3 && 
            DrawerPassword[2] == 2 && DrawerPassword[3] == 7)
        {
            Drawer_Minigame_Ex02Manager.OpenDrawer();
        }
    }
}
