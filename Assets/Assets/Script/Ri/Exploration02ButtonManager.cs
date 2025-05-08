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
    // To Kyakuma Button
    public GameObject ChangeSceneButton_Kyakuma;
    // To Corridor Button
    public GameObject ChangeSceneButton_Corridor;
    // KyakumaToDefault Button
    public GameObject ChangeSceneButton_KyakumaToDefault;
    // CorridorToDefault Button
    public GameObject ChangeSceneButton_CorridorToDefault;
    // To Shunou Button
    public GameObject ChangeSceneButton_Shunou;
    // ShunouToCorridor Button
    public GameObject ChangeSceneButton_ShunouToCorridor;
    // To ParentsRoom Button
    public GameObject ChangeSceneButton_ParentsRoom;
    // ParentsRoomToCorridor Button
    public GameObject ChangeSceneButton_ParentsRoomToCorridor;

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

    [Header("GamePlayButtons_Corridor")]
    public GameObject GamePlayButton_GirlRoomPlate;
    public GameObject GamePlayButton_GirlRoomPlate_Return;

    [Header("ChangeScene")]
    public GameObject MoveScene_Kyakuma;
    public GameObject MoveScene_Corridor;
    public GameObject MoveScene_Default;
    public GameObject MoveScene_Shunou;
    public GameObject MoveScene_ParentsRoom;


    [Header("GamePlayScene_Shunou")]
    public GameObject GamePlayScene_Desk;
    public GameObject GamePlayScene_Note;
    public GameObject GamePlayScene_Drawer;
    public GameObject GamePlayScene_Drawer_Minigame;
    public GameObject GamePlayScene_Drawer_Minigame_UI;


    [Header("GamePlayScene_Corridor")]
    public GameObject GamePlayScene_GirlRoomPlate;

    [Header("Items_Kyakuma")]
    public GameObject Items_Medal;
    private bool GetMedal = false;


    [Header("Items_Shunou")]
    private bool IsOpenDrawer = false;

    public float MoveSpeed = 2.0f;

    private Vector3 ScenePos_Default;
    private Vector3 ScenePos_Kyakuma;
    private Vector3 ScenePos_Corridor;
    private Vector3 ScenePos_Shunou;
    private Vector3 ScenePos_ParentsRoom;

    public AudioManager Exploration_AudioManager;


    // Start is called before the first frame update
    void Start()
    {
        Exploration_AudioManager = this.GetComponent<AudioManager>();

        // add all button's event listener
        // Change Scene buttons
        ChangeSceneButton_Kyakuma.GetComponent<Button>().onClick.AddListener(() => OnButtonKyakumaClick());
        ChangeSceneButton_Corridor.GetComponent<Button>().onClick.AddListener(() => OnButtonCorridorClick());
        ChangeSceneButton_KyakumaToDefault.GetComponent<Button>().onClick.AddListener(() => OnButtonKyakumaToDefaultClick());
        ChangeSceneButton_CorridorToDefault.GetComponent<Button>().onClick.AddListener(() => OnButtonCorridorToDefaultClick());
        ChangeSceneButton_Shunou.GetComponent<Button>().onClick.AddListener(() => OnButtonShunouClick());
        ChangeSceneButton_ShunouToCorridor.GetComponent<Button>().onClick.AddListener(() => OnButtonShunouToCorridorClick());
        ChangeSceneButton_ParentsRoom.GetComponent<Button>().onClick.AddListener(() => OnButtonParentsRoomClick());
        ChangeSceneButton_ParentsRoomToCorridor.GetComponent<Button>().onClick.AddListener(() => OnButtonParentsRoomToCorridorClick());

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

        // Corridor Gameplay buttons
        GamePlayButton_GirlRoomPlate.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonGirlRoomPlateClick());
        GamePlayButton_GirlRoomPlate_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonGirlRoomPlateReturnClick());

        // Move Scene's Position
        ScenePos_Kyakuma = new Vector3(MoveScene_Kyakuma.GetComponent<Transform>().position.x,
                                      MoveScene_Kyakuma.GetComponent<Transform>().position.y,
                                      -10.0f);
        ScenePos_Corridor = new Vector3(MoveScene_Corridor.GetComponent<Transform>().position.x,
                                      MoveScene_Corridor.GetComponent<Transform>().position.y,
                                      -10.0f);
        ScenePos_Default = new Vector3(MoveScene_Default.GetComponent<Transform>().position.x,
                                       MoveScene_Default.GetComponent<Transform>().position.y,
                                      -10.0f);
        ScenePos_Shunou = new Vector3(MoveScene_Shunou.GetComponent<Transform>().position.x,
                                      MoveScene_Shunou.GetComponent<Transform>().position.y,
                                     -10.0f);
        ScenePos_ParentsRoom = new Vector3(MoveScene_ParentsRoom.GetComponent<Transform>().position.x,
                                      MoveScene_ParentsRoom.GetComponent<Transform>().position.y,
                                     -10.0f);
    }


    // e per frame
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

    // ********  Change Scene Button Logic ***********
    // To Kyakuma
    public void OnButtonKyakumaClick()
    {
        Exploration_AudioManager.Se02Play();

        ChangeSceneButton_Kyakuma.SetActive(false);
        ChangeSceneButton_Corridor.SetActive(false);
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

    // To Corridor
    public void OnButtonCorridorClick()
    {
        //Exploration_AudioManager.Se02Play();

        ChangeSceneButton_Kyakuma.SetActive(false);
        ChangeSceneButton_Corridor.SetActive(false);
        MainCamera.transform.DOMove(ScenePos_Corridor, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_CorridorToDefault.SetActive(true);
            ChangeSceneButton_Shunou.SetActive(true);
            ChangeSceneButton_ParentsRoom.SetActive(true);
            GamePlayButton_GirlRoomPlate.SetActive(true);
        }); ;

    }
    public void OnButtonCorridorToDefaultClick()
    {
        ChangeSceneButton_CorridorToDefault.SetActive(false);
        ChangeSceneButton_Shunou.SetActive(false);
        ChangeSceneButton_ParentsRoom.SetActive(false);
        GamePlayButton_GirlRoomPlate.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_Default, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_Kyakuma.SetActive(true);
            ChangeSceneButton_Corridor.SetActive(true);
        });
    }
    // To Shunou
    public void OnButtonShunouClick()
    {
        ChangeSceneButton_CorridorToDefault.SetActive(false);
        ChangeSceneButton_Shunou.SetActive(false);
        ChangeSceneButton_ParentsRoom.SetActive(false);
        GamePlayButton_GirlRoomPlate.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_Shunou, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_ShunouToCorridor.SetActive(true);
            GamePlayButton_Desk.SetActive(true);
        });
    }
    public void OnButtonShunouToCorridorClick()
    {
        ChangeSceneButton_ShunouToCorridor.SetActive(false);
        GamePlayButton_Desk.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_Corridor, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_CorridorToDefault.SetActive(true);
            ChangeSceneButton_Shunou.SetActive(true);
            ChangeSceneButton_ParentsRoom.SetActive(true);
            GamePlayButton_GirlRoomPlate.SetActive(true);
        });
    }
    // Kyakuma To Default
    public void OnButtonKyakumaToDefaultClick()
    {
        ChangeSceneButton_KyakumaToDefault.SetActive(false);
        GamePlayButton_LeftFusuma.SetActive(false);
        GamePlayButton_RightFusuma.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_Default, MoveSpeed).OnComplete((TweenCallback)(() =>
        {
            ChangeSceneButton_Kyakuma.SetActive(true);
            this.ChangeSceneButton_Corridor.SetActive(true);
        }));
    }
    public void OnButtonParentsRoomClick()
    {
        ChangeSceneButton_CorridorToDefault.SetActive(false);
        ChangeSceneButton_Shunou.SetActive(false);
        ChangeSceneButton_ParentsRoom.SetActive(false);
        GamePlayButton_GirlRoomPlate.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_ParentsRoom, MoveSpeed).OnComplete((TweenCallback)(() =>
        {
            ChangeSceneButton_ParentsRoomToCorridor.SetActive(true);

        }));
    }
    public void OnButtonParentsRoomToCorridorClick()
    {

        ChangeSceneButton_ParentsRoomToCorridor.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_Corridor, MoveSpeed).OnComplete((TweenCallback)(() =>
        {
            ChangeSceneButton_CorridorToDefault.SetActive(true);
            ChangeSceneButton_Shunou.SetActive(true);
            ChangeSceneButton_ParentsRoom.SetActive(true);
            GamePlayButton_GirlRoomPlate.SetActive(true);
        }));
    }


    // ****************  GamePlayButtons_Kyakuma ****************
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
            MoveScene_Kyakuma.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("RI/Exploration02_Kyakuma_Door_Open");
            Items_Medal.SetActive(true);
        }
    }

    // ****************  GamePlayButtons_Corridor ****************
    public void OnGameplayButtonGirlRoomPlateClick()
    {
        GamePlayScene_GirlRoomPlate.SetActive(true);
        GamePlayButton_GirlRoomPlate_Return.SetActive(true);

        GamePlayButton_GirlRoomPlate.SetActive(false); 
        ChangeSceneButton_CorridorToDefault.SetActive(false);
        ChangeSceneButton_Shunou.SetActive(false);
        ChangeSceneButton_ParentsRoom.SetActive(false);
    }
    public void OnGameplayButtonGirlRoomPlateReturnClick()
    {
        GamePlayButton_GirlRoomPlate.SetActive(true);
        ChangeSceneButton_CorridorToDefault.SetActive(true);
        ChangeSceneButton_Shunou.SetActive(true);
        ChangeSceneButton_ParentsRoom.SetActive(true);

        GamePlayScene_GirlRoomPlate.SetActive(false);
        GamePlayButton_GirlRoomPlate_Return.SetActive(false);
    }

    // ****************  GamePlayButtons_Shunou ****************
    // Desk 
    public void OnGameplayButtonDeskClick()
    {
        GamePlayButton_Desk.SetActive(false);
        ChangeSceneButton_ShunouToCorridor.SetActive(false);

        GamePlayScene_Desk.SetActive(true);
        GamePlayButton_Desk_Return.SetActive(true);

        GamePlayButton_Note.SetActive(true);
        GamePlayButton_Drawer.SetActive(true);
    }
    public void OnGameplayButtonDeskReturnClick()
    {
        GamePlayButton_Desk.SetActive(true);
        ChangeSceneButton_ShunouToCorridor.SetActive(true);

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
