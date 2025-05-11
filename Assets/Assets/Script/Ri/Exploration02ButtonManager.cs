// 25.5.11. RI
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public enum Exploration_02_Scenes
{
    Default= 0, 
    Kyakuma = 1,   
    Corridor = 2,
    Shunou = 3,
    ParentsRoom = 4,
    Libing = 5,
    Kitchen= 6,
    None = 114514,
}

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
    // Libing Room Button
    public GameObject ChangeSceneButton_Libing;
    // Libing Room To Default Button
    public GameObject ChangeSceneButton_LibingToDefault;
    // To Kitchen Button
    public GameObject ChangeSceneButton_LibingToKitchen;
    // Kitchen To Libing Button
    public GameObject ChangeSceneButton_KitchenToLibing;

    [Header("GamePlayButtons_Kyakuma")]
    public GameObject GamePlayButton_Kyakuma_LeftFusuma;
    public GameObject GamePlayButton_Kyakuma_RightFusuma;
    private int LeftFusumaClickCount = 0;
    private int RightFusumaClickCount = 0;

    [Header("GamePlayButtons_Shunou")]
    public GameObject GamePlayButton_Shunou_Desk;
    public GameObject GamePlayButton_Shunou_Note;
    public GameObject GamePlayButton_Shunou_Drawer;
    public GameObject GamePlayButton_Shunou_Drawer_Minigame;
    public GameObject GamePlayButton_Shunou_Desk_Return;
    public GameObject GamePlayButton_Shunou_Note_Return;
    public GameObject GamePlayButton_Shunou_Drawer_Return;
    public GameObject GamePlayButton_Shunou_Drawer_Minigame_Return;

    [Header("GamePlayButtons_Corridor")]
    public GameObject GamePlayButton_Corridor_GirlRoomPlate;
    public GameObject GamePlayButton_Corridor_GirlRoomPlate_Return;

    [Header("GamePlayScene_Shunou")]
    public GameObject GamePlayScene_Shunou_Desk;
    public GameObject GamePlayScene_Shunou_Note;
    public GameObject GamePlayScene_Shunou_Drawer;
    public GameObject GamePlayScene_Shunou_Drawer_Minigame;
    public GameObject GamePlayScene_Shunou_Drawer_Minigame_UI;

    [Header("GamePlayScene_Libing")]
    public GameObject GamePlayScene_Libing_ClockMinigame;
    public GameObject GamePlayScene_Libing_ClockMinigame_UI;

    [Header("GamePlayScene_Corridor")]
    public GameObject GamePlayScene_Corridor_GirlRoomPlate;

  
    [Header("Items_Kyakuma")]
    public GameObject Items_Medal;
    private bool GetMedal = false;

    [Header("ChangeScene")]
    public GameObject MoveScene_Kyakuma;
    public GameObject MoveScene_Corridor;
    public GameObject MoveScene_Default;
    public GameObject MoveScene_Shunou;
    public GameObject MoveScene_ParentsRoom;
    public GameObject MoveScene_Libing;
    public GameObject MoveScene_Kitchen;


    [Header("Items_Shunou")]
    private bool IsOpenDrawer = false;

    public float MoveSpeed = 2.0f;

    private Vector3 ScenePos_Default;
    private Vector3 ScenePos_Kyakuma;
    private Vector3 ScenePos_Corridor;
    private Vector3 ScenePos_Shunou;
    private Vector3 ScenePos_ParentsRoom;
    private Vector3 ScenePos_Libing;
    private Vector3 ScenePos_Kitchen;

    public AudioManager Exploration_AudioManager;
    private MouseDetection Exploration_MouseDetection;


    // Start is called before the first frame update
    void Start()
    {
        Exploration_AudioManager = this.GetComponent<AudioManager>();
        Exploration_MouseDetection=this.GetComponent<MouseDetection>();

    // add all button's event listener
    // ************** Change Scene buttons ******************
    // ******* Default *****
    ChangeSceneButton_Kyakuma.GetComponent<Button>().onClick.AddListener(() => OnButtonKyakumaClick());
        ChangeSceneButton_Corridor.GetComponent<Button>().onClick.AddListener(() => OnButtonCorridorClick());
        ChangeSceneButton_Libing.GetComponent<Button>().onClick.AddListener(() => OnButtonLibingClick());

        // ******* Kyakuma *****
        ChangeSceneButton_KyakumaToDefault.GetComponent<Button>().onClick.AddListener(() => OnButtonKyakumaToDefaultClick());

        // ******* Corridor *****
        ChangeSceneButton_CorridorToDefault.GetComponent<Button>().onClick.AddListener(() => OnButtonCorridorToDefaultClick());
        ChangeSceneButton_Shunou.GetComponent<Button>().onClick.AddListener(() => OnButtonShunouClick());
        ChangeSceneButton_ParentsRoom.GetComponent<Button>().onClick.AddListener(() => OnButtonParentsRoomClick());

        // ******* Shunou *****
        ChangeSceneButton_ShunouToCorridor.GetComponent<Button>().onClick.AddListener(() => OnButtonShunouToCorridorClick());

        // ******* ParentsRoom *****
        ChangeSceneButton_ParentsRoomToCorridor.GetComponent<Button>().onClick.AddListener(() => OnButtonParentsRoomToCorridorClick());

        // ******* Libing *****
        ChangeSceneButton_LibingToDefault.GetComponent<Button>().onClick.AddListener(() => OnButtonLibingToDefaultClick());
        ChangeSceneButton_LibingToKitchen.GetComponent<Button>().onClick.AddListener(() => OnButtonToKitchenClick());

        // ******* Kitchen *****
        ChangeSceneButton_KitchenToLibing.GetComponent<Button>().onClick.AddListener(() => OnButtonKitchenToLibingClick());
      
        // ************** Gameplay buttons ******************
        // Kyakuma Gameplay buttons
        GamePlayButton_Kyakuma_LeftFusuma.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonFusumaClick(true));
        GamePlayButton_Kyakuma_RightFusuma.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonFusumaClick(false));

        // Shunou Gameplay buttons
        GamePlayButton_Shunou_Desk.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDeskClick());
        GamePlayButton_Shunou_Note.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonNoteClick());
        GamePlayButton_Shunou_Drawer.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDrawerClick());
        GamePlayButton_Shunou_Drawer_Minigame.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDrawerMinigameClick());

        GamePlayButton_Shunou_Desk_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDeskReturnClick());
        GamePlayButton_Shunou_Note_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonNoteReturnClick());
        GamePlayButton_Shunou_Drawer_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDrawerReturnClick());
        GamePlayButton_Shunou_Drawer_Minigame_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDrawerMinigameReturnClick());

        // Corridor Gameplay buttons
        GamePlayButton_Corridor_GirlRoomPlate.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonGirlRoomPlateClick());
        GamePlayButton_Corridor_GirlRoomPlate_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonGirlRoomPlateReturnClick());

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
        ScenePos_Libing = new Vector3(MoveScene_Libing.GetComponent<Transform>().position.x,
                                     MoveScene_Libing.GetComponent<Transform>().position.y,
                                    -10.0f);

        ScenePos_Kitchen = new Vector3(MoveScene_Kitchen.GetComponent<Transform>().position.x,
                                     MoveScene_Kitchen.GetComponent<Transform>().position.y,
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

    // *********** Default *********
    // To Kyakuma
    public void OnButtonKyakumaClick()
    {
        Exploration_AudioManager.Se02Play();

        ChangeSceneButton_Kyakuma.SetActive(false);
        ChangeSceneButton_Corridor.SetActive(false);
        ChangeSceneButton_Libing.SetActive(false);
        MainCamera.transform.DOMove(ScenePos_Kyakuma, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_KyakumaToDefault.SetActive(true);
            if (!GetMedal)
            {
                GamePlayButton_Kyakuma_LeftFusuma.SetActive(true);
                GamePlayButton_Kyakuma_RightFusuma.SetActive(true);
                Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Kyakuma);
            }
        }); ;
    }

    // To Corridor
    public void OnButtonCorridorClick()
    {
        //Exploration_AudioManager.Se02Play();

        ChangeSceneButton_Kyakuma.SetActive(false);
        ChangeSceneButton_Corridor.SetActive(false);
        ChangeSceneButton_Libing.SetActive(false);
        MainCamera.transform.DOMove(ScenePos_Corridor, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_CorridorToDefault.SetActive(true);
            ChangeSceneButton_Shunou.SetActive(true);
            ChangeSceneButton_ParentsRoom.SetActive(true);
            GamePlayButton_Corridor_GirlRoomPlate.SetActive(true);

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Corridor);
        }); ;

    }

    // To Libing
    public void OnButtonLibingClick()
    {
        ChangeSceneButton_Kyakuma.SetActive(false);
        ChangeSceneButton_Corridor.SetActive(false);
        ChangeSceneButton_Libing.SetActive(false);
        MainCamera.transform.DOMove(ScenePos_Libing, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_LibingToDefault.SetActive(true);
            ChangeSceneButton_LibingToKitchen.SetActive(true);

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Libing);

        }); ;

    }

    // ************ Corridor  **********
    // To Default
    public void OnButtonCorridorToDefaultClick()
    {
        ChangeSceneButton_CorridorToDefault.SetActive(false);
        ChangeSceneButton_Shunou.SetActive(false);
        ChangeSceneButton_ParentsRoom.SetActive(false);
        GamePlayButton_Corridor_GirlRoomPlate.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_Default, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_Kyakuma.SetActive(true);
            ChangeSceneButton_Corridor.SetActive(true);

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Default);
        });
    }
    // To Shunou
    public void OnButtonShunouClick()
    {
        ChangeSceneButton_CorridorToDefault.SetActive(false);
        ChangeSceneButton_Shunou.SetActive(false);
        ChangeSceneButton_ParentsRoom.SetActive(false);
        GamePlayButton_Corridor_GirlRoomPlate.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_Shunou, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_ShunouToCorridor.SetActive(true);
            GamePlayButton_Shunou_Desk.SetActive(true);

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Shunou);
        });
    }
    // To ParentsRoom
    public void OnButtonParentsRoomClick()
    {
        ChangeSceneButton_CorridorToDefault.SetActive(false);
        ChangeSceneButton_Shunou.SetActive(false);
        ChangeSceneButton_ParentsRoom.SetActive(false);
        GamePlayButton_Corridor_GirlRoomPlate.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_ParentsRoom, MoveSpeed).OnComplete((TweenCallback)(() =>
        {
            ChangeSceneButton_ParentsRoomToCorridor.SetActive(true);

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.ParentsRoom);

        }));
    }

    //********** Kyakuma **************
    // Kyakuma To Default
    public void OnButtonKyakumaToDefaultClick()
    {
        ChangeSceneButton_KyakumaToDefault.SetActive(false);
        GamePlayButton_Kyakuma_LeftFusuma.SetActive(false);
        GamePlayButton_Kyakuma_RightFusuma.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_Default, MoveSpeed).OnComplete((TweenCallback)(() =>
        {
            ChangeSceneButton_Kyakuma.SetActive(true);
            ChangeSceneButton_Corridor.SetActive(true);
            ChangeSceneButton_Libing.SetActive(true);

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Default);
        }));
    }


    //********** Libing **************
    // Libing To Default
    public void OnButtonLibingToDefaultClick()
    {
        ChangeSceneButton_LibingToDefault.SetActive(false);
        ChangeSceneButton_LibingToKitchen.SetActive(false);
        MainCamera.transform.DOMove(ScenePos_Default, MoveSpeed).OnComplete((TweenCallback)(() =>
        {
            ChangeSceneButton_Kyakuma.SetActive(true);
            ChangeSceneButton_Corridor.SetActive(true);
            ChangeSceneButton_Libing.SetActive(true);

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Default);
        }));
    }

    // Libing To Kitchen
    public void OnButtonToKitchenClick()
    {
        ChangeSceneButton_LibingToDefault.SetActive(false);
        ChangeSceneButton_LibingToKitchen.SetActive(false);
        MainCamera.transform.DOMove(ScenePos_Kitchen, MoveSpeed).OnComplete((TweenCallback)(() =>
        {
            ChangeSceneButton_KitchenToLibing.SetActive(true);

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Kitchen);
        }));
    }

    //********** Kitchen **************
    // Kitchen To Libing
    public void OnButtonKitchenToLibingClick()
    {
        ChangeSceneButton_KitchenToLibing.SetActive(false);
        MainCamera.transform.DOMove(ScenePos_Libing, MoveSpeed).OnComplete((TweenCallback)(() =>
        {
            ChangeSceneButton_LibingToDefault.SetActive(true);
            ChangeSceneButton_LibingToKitchen.SetActive(true);

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Libing);
        }));
    }

    // ************ Shunou *****************
    // Shunou To Corridor
    public void OnButtonShunouToCorridorClick()
    {
        ChangeSceneButton_ShunouToCorridor.SetActive(false);
        GamePlayButton_Shunou_Desk.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_Corridor, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_CorridorToDefault.SetActive(true);
            ChangeSceneButton_Shunou.SetActive(true);
            ChangeSceneButton_ParentsRoom.SetActive(true);
            GamePlayButton_Corridor_GirlRoomPlate.SetActive(true);

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Corridor);
        });
    }

    // *********** ParentsRoom ************
    // ParentsRoom To Corridor
    public void OnButtonParentsRoomToCorridorClick()
    {
        ChangeSceneButton_ParentsRoomToCorridor.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_Corridor, MoveSpeed).OnComplete((TweenCallback)(() =>
        {
            ChangeSceneButton_CorridorToDefault.SetActive(true);
            ChangeSceneButton_Shunou.SetActive(true);
            ChangeSceneButton_ParentsRoom.SetActive(true);
            GamePlayButton_Corridor_GirlRoomPlate.SetActive(true);

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Corridor);
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
                GamePlayButton_Kyakuma_LeftFusuma.SetActive(false);
                LeftFusumaClickCount = 4;
            }
        }
        else
        {
            RightFusumaClickCount += 1;
            if (RightFusumaClickCount >= 2)
            {
                RightFusumaClickCount = 2;
                GamePlayButton_Kyakuma_RightFusuma.SetActive(false);
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
        GamePlayScene_Corridor_GirlRoomPlate.SetActive(true);
        GamePlayButton_Corridor_GirlRoomPlate_Return.SetActive(true);

        GamePlayButton_Corridor_GirlRoomPlate.SetActive(false); 
        ChangeSceneButton_CorridorToDefault.SetActive(false);
        ChangeSceneButton_Shunou.SetActive(false);
        ChangeSceneButton_ParentsRoom.SetActive(false);
    }
    public void OnGameplayButtonGirlRoomPlateReturnClick()
    {
        GamePlayButton_Corridor_GirlRoomPlate.SetActive(true);
        ChangeSceneButton_CorridorToDefault.SetActive(true);
        ChangeSceneButton_Shunou.SetActive(true);
        ChangeSceneButton_ParentsRoom.SetActive(true);

        GamePlayScene_Corridor_GirlRoomPlate.SetActive(false);
        GamePlayButton_Corridor_GirlRoomPlate_Return.SetActive(false);
    }


    // ****************  GamePlayButtons_Shunou ****************
    // Desk 
    public void OnGameplayButtonDeskClick()
    {
        GamePlayButton_Shunou_Desk.SetActive(false);
        ChangeSceneButton_ShunouToCorridor.SetActive(false);

        GamePlayScene_Shunou_Desk.SetActive(true);
        GamePlayButton_Shunou_Desk_Return.SetActive(true);

        GamePlayButton_Shunou_Note.SetActive(true);
        GamePlayButton_Shunou_Drawer.SetActive(true);
    }
    public void OnGameplayButtonDeskReturnClick()
    {
        GamePlayButton_Shunou_Desk.SetActive(true);
        ChangeSceneButton_ShunouToCorridor.SetActive(true);

        GamePlayScene_Shunou_Desk.SetActive(false);
        GamePlayButton_Shunou_Desk_Return.SetActive(false);
        GamePlayButton_Shunou_Note.SetActive(false);
        GamePlayButton_Shunou_Drawer.SetActive(false);
    }
    // Note
    public void OnGameplayButtonNoteClick()
    {
        GamePlayScene_Shunou_Note.SetActive(true);
        GamePlayButton_Shunou_Note_Return.SetActive(true);

        GamePlayButton_Shunou_Note.SetActive(false);
        GamePlayButton_Shunou_Desk_Return.SetActive(false);

        GamePlayButton_Shunou_Drawer.SetActive(false);
    }
    public void OnGameplayButtonNoteReturnClick()
    {
        GamePlayButton_Shunou_Desk_Return.SetActive(true);
        GamePlayButton_Shunou_Note.SetActive(true);
        GamePlayButton_Shunou_Drawer.SetActive(true);

        GamePlayScene_Shunou_Note.SetActive(false);
        GamePlayButton_Shunou_Note_Return.SetActive(false);
    }

    // Drawer
    public void OnGameplayButtonDrawerClick()
    {
        GamePlayScene_Shunou_Drawer.SetActive(true);
        GamePlayButton_Shunou_Drawer_Return.SetActive(true);
        if (!IsOpenDrawer)
        {
            GamePlayButton_Shunou_Drawer_Minigame.SetActive(true);
        }

        GamePlayButton_Shunou_Drawer.SetActive(false);
        GamePlayButton_Shunou_Desk_Return.SetActive(false);

        GamePlayButton_Shunou_Note.SetActive(false);
    }
    public void OnGameplayButtonDrawerReturnClick()
    {
        GamePlayButton_Shunou_Desk_Return.SetActive(true);
        GamePlayButton_Shunou_Drawer.SetActive(true);
        GamePlayButton_Shunou_Note.SetActive(true);

        GamePlayScene_Shunou_Drawer.SetActive(false);
        GamePlayButton_Shunou_Drawer_Return.SetActive(false);
        GamePlayButton_Shunou_Drawer_Minigame.SetActive(false);
    }
    public void OnGameplayButtonDrawerMinigameClick()
    {
        GamePlayScene_Shunou_Drawer_Minigame.SetActive(true);
        GamePlayScene_Shunou_Drawer_Minigame_UI.SetActive(true);
        GamePlayButton_Shunou_Drawer_Minigame_Return.SetActive(true);

        GamePlayButton_Shunou_Drawer_Minigame.SetActive(false);
        GamePlayButton_Shunou_Drawer_Return.SetActive(false);
    }
    public void OnGameplayButtonDrawerMinigameReturnClick()
    {
        GamePlayScene_Shunou_Drawer_Minigame.SetActive(false);
        GamePlayScene_Shunou_Drawer_Minigame_UI.SetActive(false);
        GamePlayButton_Shunou_Drawer_Minigame_Return.SetActive(false);

        if (!IsOpenDrawer)
        {
            GamePlayButton_Shunou_Drawer_Minigame.SetActive(true);
        }
        GamePlayButton_Shunou_Drawer_Return.SetActive(true);
    }
    public void OpenDrawer()
    {
        GamePlayScene_Shunou_Drawer.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_Shunou_drawer_open");
        IsOpenDrawer = true;
    }

    //************ Gameplay Libing ***********
    public void OpenClock()
    {
        GamePlayScene_Libing_ClockMinigame.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("RI/Exploration02_Libing_Openclock");
        IsOpenDrawer = true;
    }


}
