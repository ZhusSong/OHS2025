using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Fungus;
using Unity.Burst.CompilerServices;
using DG.Tweening;
using UnityEngine.UIElements.Experimental;

public class Exploration02ButtonManager : MonoBehaviour
{
    public Camera MainCamera;

    [Header("ChangeButtons")]
    public GameObject ChangeSceneButton_Kyakuma;
    public GameObject ChangeSceneButton_Shunou;
    public GameObject ChangeSceneButton_KyakumaToDefault;
    public GameObject ChangeSceneButton_ShunouToDefault;

    [Header("GamePlayButtons_Kyakuma")]
    public GameObject GamePlayButton_LeftFusuma;
    public GameObject GamePlayButton_RightFusuma;
    private int LeftFusumaClickCount = 0;
    private int RightFusumaClickCount = 0;

    [Header("GamePlayButtons_Shunou")]
    public GameObject GamePlayButton_Desk;
    public GameObject GamePlayButton_Note;
    public GameObject GamePlayButton_Drawer;
    public GameObject GamePlayButton_Drawer_Minigame;
    public GameObject GamePlayButton_Desk_Return;
    public GameObject GamePlayButton_Note_Return;
    public GameObject GamePlayButton_Drawer_Return;
    public GameObject GamePlayButton_Drawer_Minigame_Return;

    [Header("ChangeScene")]
    public GameObject ChangeScene_Kyakuma;
    public GameObject ChangeScene_Shunou;
    public GameObject ChangeScene_Default;


    [Header("GamePlayScene")]
    public GameObject GamePlayScene_Desk;
    public GameObject GamePlayScene_Note;
    public GameObject GamePlayScene_Drawer;
    public GameObject GamePlayScene_Drawer_Minigame;
    public GameObject GamePlayScene_Drawer_Minigame_UI;

    [Header("Items")]
    public GameObject Items_Medal;
    private bool GetMedal = false;
    private bool IsOpenDrawer= false;

    public float MoveSpeed = 2.0f;

    private Vector3 ScenePos_Default;
    private Vector3 ScenePos_Kyakuma;
    private Vector3 ScenePos_Shunou;

    public AudioManager Exploration_AudioManager;


    // Start is called before the first frame update
    void Start()
    {
        Exploration_AudioManager = this.GetComponent<AudioManager>();

        // add all button's event listener
        // Change Scene buttons
        ChangeSceneButton_Kyakuma.GetComponent<Button>().onClick.AddListener(() => OnButtonKyakumaClick());
        ChangeSceneButton_Shunou.GetComponent<Button>().onClick.AddListener(() => OnButtonShunouClick());
        ChangeSceneButton_KyakumaToDefault.GetComponent<Button>().onClick.AddListener(() => OnButtonKyakumaToDefaultClick());
        ChangeSceneButton_ShunouToDefault.GetComponent<Button>().onClick.AddListener(() => OnButtonShunouToDefaultClick());

        // Kyakuma Gameplay buttons
        GamePlayButton_LeftFusuma.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonFusumaClick(true));
        GamePlayButton_RightFusuma.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonFusumaClick(false));

        // Shunou Gameplay buttons
        GamePlayButton_Desk.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDeskClick());
        GamePlayButton_Note.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonNoteClick());
        GamePlayButton_Drawer.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDrawerClick());
        GamePlayButton_Drawer_Minigame.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDrawerMinigameClick());

        GamePlayButton_Desk_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDeskReturnClick());
        GamePlayButton_Note_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonNoteReturnClick());
        GamePlayButton_Drawer_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDrawerReturnClick());
        GamePlayButton_Drawer_Minigame_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDrawerMinigameReturnClick());

        // Move Scene's Position
        ScenePos_Kyakuma = new Vector3(ChangeScene_Kyakuma.GetComponent<Transform>().position.x,
                                      ChangeScene_Kyakuma.GetComponent<Transform>().position.y,
                                      -10.0f);
        ScenePos_Shunou = new Vector3(ChangeScene_Shunou.GetComponent<Transform>().position.x,
                                      ChangeScene_Shunou.GetComponent<Transform>().position.y,
                                      -10.0f);
        ScenePos_Default = new Vector3(ChangeScene_Default.GetComponent<Transform>().position.x,
                                       ChangeScene_Default.GetComponent<Transform>().position.y,
                                      -10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Left Mouse Button Down
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == Items_Medal && Items_Medal.activeSelf)
            {
                Items_Medal.SetActive(false);
                Exploration_AudioManager.Se01Play();
                GetMedal = true;
            }

        }
    }

    public void OnButtonKyakumaClick()
    {
        Exploration_AudioManager.Se02Play();

        ChangeSceneButton_Kyakuma.SetActive(false);
        ChangeSceneButton_Shunou.SetActive(false);
        MainCamera.transform.DOMove(ScenePos_Kyakuma, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_KyakumaToDefault.SetActive(true);
            if (!GetMedal)
            {
                GamePlayButton_LeftFusuma.SetActive(true);
                GamePlayButton_RightFusuma.SetActive(true);
            }
        }); ;
    }


    public void OnButtonShunouClick()
    {
        //Exploration_AudioManager.Se02Play();

        ChangeSceneButton_Kyakuma.SetActive(false);
        ChangeSceneButton_Shunou.SetActive(false);
        MainCamera.transform.DOMove(ScenePos_Shunou, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_ShunouToDefault.SetActive(true);
            GamePlayButton_Desk.SetActive(true);
        }); ;

    }
    public void OnButtonKyakumaToDefaultClick()
    {
        ChangeSceneButton_KyakumaToDefault.SetActive(false);
        GamePlayButton_LeftFusuma.SetActive(false);
        GamePlayButton_RightFusuma.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_Default, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_Kyakuma.SetActive(true);
            ChangeSceneButton_Shunou.SetActive(true);
        });
    }

    public void OnButtonShunouToDefaultClick()
    {
        ChangeSceneButton_ShunouToDefault.SetActive(false);
        GamePlayButton_Desk.SetActive(false);
        MainCamera.transform.DOMove(ScenePos_Default, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_Kyakuma.SetActive(true);
            ChangeSceneButton_Shunou.SetActive(true);
        });
    }

    // true->left
    // false->right
    public void OnGameplayButtonFusumaClick(bool leftOrRight)
    {
        Debug.Log("Fusuma");
        if (leftOrRight)
        {
            LeftFusumaClickCount += 1;
            if (LeftFusumaClickCount >= 4)
            {
                GamePlayButton_LeftFusuma.SetActive(false);
                LeftFusumaClickCount = 4;
            }
        }
        else
        {
            RightFusumaClickCount += 1;
            if (RightFusumaClickCount >= 2)
            {
                RightFusumaClickCount = 2;
                GamePlayButton_RightFusuma.SetActive(false);
            }
        }

        if (LeftFusumaClickCount == 4 && RightFusumaClickCount == 2)
        {
            ChangeScene_Kyakuma.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("RI/Exploration02_Kyakuma_Door_Open");
            Items_Medal.SetActive(true);
        }
    }

    // Desk 
    public void OnGameplayButtonDeskClick()
    {
        GamePlayButton_Desk.SetActive(false);
        ChangeSceneButton_ShunouToDefault.SetActive(false);

        GamePlayScene_Desk.SetActive(true);
        GamePlayButton_Desk_Return.SetActive(true);

        GamePlayButton_Note.SetActive(true);
        GamePlayButton_Drawer.SetActive(true);
    }
    public void OnGameplayButtonDeskReturnClick()
    {
        GamePlayButton_Desk.SetActive(true);
        ChangeSceneButton_ShunouToDefault.SetActive(true);

        GamePlayScene_Desk.SetActive(false);
        GamePlayButton_Desk_Return.SetActive(false);
        GamePlayButton_Note.SetActive(false);
        GamePlayButton_Drawer.SetActive(false);
    }
    // Note
    public void OnGameplayButtonNoteClick()
    {
        GamePlayScene_Note.SetActive(true);
        GamePlayButton_Note_Return.SetActive(true);

        GamePlayButton_Note.SetActive(false);
        GamePlayButton_Desk_Return.SetActive(false);

        GamePlayButton_Drawer.SetActive(false);
    }
        public void OnGameplayButtonNoteReturnClick()
    {
        GamePlayButton_Desk_Return.SetActive(true);
        GamePlayButton_Note.SetActive(true);
        GamePlayButton_Drawer.SetActive(true);

        GamePlayScene_Note.SetActive(false);
        GamePlayButton_Note_Return.SetActive(false);
    }

    // Drawer
    public void OnGameplayButtonDrawerClick()
    {
        GamePlayScene_Drawer.SetActive(true);
        GamePlayButton_Drawer_Return.SetActive(true);
        if (!IsOpenDrawer)
        {
            GamePlayButton_Drawer_Minigame.SetActive(true);
        }

        GamePlayButton_Drawer.SetActive(false);
        GamePlayButton_Desk_Return.SetActive(false);

        GamePlayButton_Note.SetActive(false);
    }
    public void OnGameplayButtonDrawerReturnClick()
    {
        GamePlayButton_Desk_Return.SetActive(true);
        GamePlayButton_Drawer.SetActive(true);
        GamePlayButton_Note.SetActive(true);

        GamePlayScene_Drawer.SetActive(false);
        GamePlayButton_Drawer_Return.SetActive(false);
        GamePlayButton_Drawer_Minigame.SetActive(false);
    }
    public void OnGameplayButtonDrawerMinigameClick()
    {
            GamePlayScene_Drawer_Minigame.SetActive(true);
            GamePlayScene_Drawer_Minigame_UI.SetActive(true);
            GamePlayButton_Drawer_Minigame_Return.SetActive(true);

            GamePlayButton_Drawer_Minigame.SetActive(false);
            GamePlayButton_Drawer_Return.SetActive(false);
    }
    public void OnGameplayButtonDrawerMinigameReturnClick()
    {
        GamePlayScene_Drawer_Minigame.SetActive(false);
        GamePlayScene_Drawer_Minigame_UI.SetActive(false);
        GamePlayButton_Drawer_Minigame_Return.SetActive(false);

        if (!IsOpenDrawer)
        {
            GamePlayButton_Drawer_Minigame.SetActive(true);
        }
        GamePlayButton_Drawer_Return.SetActive(true);
    }
    public void OpenDrawer()
    {
       GamePlayScene_Drawer.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_Shunou_drawer_open");
       IsOpenDrawer = true;
    }
}
