// 25.5.11. RI
using DG.Tweening;
using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    [Header("SEs")]
    public AudioClip[] Exploration02_SE;

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
    public GameObject GamePlayButton_Kyakuma_Medal;
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

    public GameObject GamePlayButton_Shunou_Drawer_Key;

    [Header("GamePlayButtons_Corridor")]
    public GameObject GamePlayButton_Corridor_GirlRoomPlate;
    public GameObject GamePlayButton_Corridor_GirlRoomPlate_Return;
    public GameObject GamePlayButton_Corridor_GoToNextScene;

    [Header("GamePlayButtons_ParentsRoom")]
    public GameObject GamePlayButton_ParentsRoom_Closet;
    public GameObject GamePlayButton_ParentsRoom_Minigame_Return;
    public GameObject GamePlayButton_ParentsRoom_OnpuMedal;


    [Header("GamePlayButtons_Libing")]
    public GameObject GamePlayButton_Libing_Dentou;
    public GameObject GamePlayButton_Libing_Clock;
    public GameObject GamePlayButton_Libing_Sofa;
    public GameObject GamePlayButton_Libing_HornMedal;
    public GameObject GamePlayButton_Libing_BrushMedal;
    public GameObject GamePlayButton_Libing_Minigame_Return;

    [Header("GamePlayButtons_Kitchen")]
    public GameObject GamePlayButton_Kitchen_Todona;
    public GameObject GamePlayButton_Kitchen_Todona_Return;
    public GameObject GamePlayButton_Kitchen_Shingu;
    public GameObject GamePlayButton_Kitchen_CleanDish;
    public GameObject GamePlayButton_Kitchen_Dish_Return;

    [Header("GamePlayScene_ParentsRoom")]
    public GameObject GamePlayScene_ParentsRoom_Closet;
    public GameObject GamePlayScene_ParentsRoom_Closet_Minigame;

    [Header("GamePlayScene_Shunou")]
    public GameObject GamePlayScene_Shunou_Desk;
    public GameObject GamePlayScene_Shunou_Note;
    public GameObject GamePlayScene_Shunou_Drawer;
    public GameObject GamePlayScene_Shunou_Drawer_Minigame;
    public GameObject GamePlayScene_Shunou_Drawer_Minigame_UI;

    [Header("GamePlayScene_Corridor")]
    public GameObject GamePlayScene_Corridor_GirlRoomPlate;

    [Header("GamePlayScene_Libing")]
    public GameObject GamePlayScene_Libing_ClockMinigame;
    public GameObject GamePlayScene_Libing_ClockMinigame_UI;

    [Header("GamePlayScene_Kitchen")]
    public GameObject GamePlayScene_Kithchen_Todona;
    public GameObject GamePlayScene_Kithchen_Dish;
    public GameObject GamePlayScene_Kithchen_Todona_ClockTime;
    private bool DishIsClean = false;


    [Header("Items_Kyakuma")]
    public GameObject Items_Kyakuma_Medal;
    private bool IsOpenLeftFusuma = false;
    private bool IsOpenRightFusuma = false;
    private bool GetKyakumaMedal = false;

    [Header("ChangeScene")]
    public GameObject MoveScene_Kyakuma;
    public GameObject MoveScene_Corridor;
    public GameObject MoveScene_Default;
    public GameObject MoveScene_Shunou;
    public GameObject MoveScene_ParentsRoom;
    public GameObject MoveScene_Libing;
    public GameObject MoveScene_Kitchen;


    [Header("Items_Shunou")]
    public GameObject Items_Shunou_Key;
    private bool IsGetKey= false;
    private bool IsOpenDrawer = false;

    [Header("Items_Libing")]
    public GameObject Items_Libing_Kaityuudentou;
    public GameObject Items_Libing_HornMedal;
    public GameObject Items_Libing_BrushMedal;
    private bool IsOpenClock = false;
    private bool IsGetBrushMedal = false;
    private bool IsGetHornMedal = false;
    private bool IsGetDentou = false;


    [Header("Items_ParentsRoom")]
    public GameObject Items_ParentsRoom_OnpuMedal;
    private bool IsOpenCloset = false;
    private bool IsGetOnpuMedal = false;


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
        GamePlayButton_Kyakuma_Medal.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonKyakumaMedalClick());

        // Shunou Gameplay buttons
        GamePlayButton_Shunou_Desk.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDeskClick());
        GamePlayButton_Shunou_Note.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonNoteClick());
        GamePlayButton_Shunou_Drawer.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDrawerClick());
        GamePlayButton_Shunou_Drawer_Minigame.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDrawerMinigameClick());

        GamePlayButton_Shunou_Desk_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDeskReturnClick());
        GamePlayButton_Shunou_Note_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonNoteReturnClick());
        GamePlayButton_Shunou_Drawer_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDrawerReturnClick());
        GamePlayButton_Shunou_Drawer_Minigame_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDrawerMinigameReturnClick());
      
        GamePlayButton_Shunou_Drawer_Key.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDrawerKeyClick());

        // Libing Gameplay buttons
        GamePlayButton_Libing_Dentou.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDentouClick());
        GamePlayButton_Libing_Clock.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonMinigameClick());
        GamePlayButton_Libing_Sofa.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonSofaClick());
        GamePlayButton_Libing_HornMedal.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonHornMedalClick());
        GamePlayButton_Libing_BrushMedal.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonBrushMedalClick());
        GamePlayButton_Libing_Minigame_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonLibingMinigameReturnClick());

        // Corridor Gameplay buttons
        GamePlayButton_Corridor_GirlRoomPlate.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonGirlRoomPlateClick());
        GamePlayButton_Corridor_GirlRoomPlate_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonGirlRoomPlateReturnClick());
        GamePlayButton_Corridor_GoToNextScene.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonGotoNextSceneClick());

        // ParentsRoom Gameplay buttons
        GamePlayButton_ParentsRoom_Closet.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonParentsClosetClick());
        GamePlayButton_ParentsRoom_Minigame_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonParentsMinigameReturnClick());

        GamePlayButton_ParentsRoom_OnpuMedal.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonParentsRoomOnpuMedalClick());

        // Kithchen Gameplay buttons
        GamePlayButton_Kitchen_Todona.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonTodonaClick());
        GamePlayButton_Kitchen_Todona_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonTodonaReturnClick());
        GamePlayButton_Kitchen_Shingu.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonShinguClick());
        GamePlayButton_Kitchen_CleanDish.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDishClick());
        GamePlayButton_Kitchen_Dish_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDishReturnClick());




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
       
    }

    // ********  Change Scene Button Logic ***********

    // *********** Default *********
    // To Kyakuma
    public void OnButtonKyakumaClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[0], 0.8f);
        //Exploration_AudioManager.Se02Play(0.5f);

        ChangeSceneButton_Kyakuma.SetActive(false);
        ChangeSceneButton_Corridor.SetActive(false);
        ChangeSceneButton_Libing.SetActive(false);
        MainCamera.transform.DOMove(ScenePos_Kyakuma, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_KyakumaToDefault.SetActive(true);
            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Kyakuma);
            if (!IsOpenLeftFusuma)
            {
                GamePlayButton_Kyakuma_LeftFusuma.SetActive(true);
            }
            if(!IsOpenRightFusuma)
            {
                GamePlayButton_Kyakuma_RightFusuma.SetActive(true);
            }
            if(IsOpenLeftFusuma&&IsOpenRightFusuma)
            {
               if(!GetKyakumaMedal)
                {
                    GamePlayButton_Kyakuma_Medal.SetActive(true);
                }
            }
        }); ;
    }

    // To Corridor
    public void OnButtonCorridorClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[0], 0.8f);

        ChangeSceneButton_Kyakuma.SetActive(false);
        ChangeSceneButton_Corridor.SetActive(false);
        ChangeSceneButton_Libing.SetActive(false);
        MainCamera.transform.DOMove(ScenePos_Corridor, MoveSpeed).OnComplete(() =>
        {
            if (IsGetKey)
                ChangeSceneButton_ParentsRoom.SetActive(true);


            ChangeSceneButton_CorridorToDefault.SetActive(true);
            ChangeSceneButton_Shunou.SetActive(true);
   
            GamePlayButton_Corridor_GirlRoomPlate.SetActive(true);

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Corridor);
        }); ;

    }

    // To Libing
    public void OnButtonLibingClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[0], 0.8f);

        ChangeSceneButton_Kyakuma.SetActive(false);
        ChangeSceneButton_Corridor.SetActive(false);
        ChangeSceneButton_Libing.SetActive(false);
        MainCamera.transform.DOMove(ScenePos_Libing, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_LibingToDefault.SetActive(true);
            ChangeSceneButton_LibingToKitchen.SetActive(true);



            GamePlayButton_Libing_Clock.SetActive(true);
            if (!IsGetDentou)
            {
                GamePlayButton_Libing_Dentou.SetActive(true);
                Items_Libing_Kaityuudentou.SetActive(true);
            }

            if (IsGetDentou)
            {
                if (!IsGetHornMedal)
                    GamePlayButton_Libing_Sofa.SetActive(true);
            }

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Libing);

        }); ;

    }

    // ************ Corridor  **********
    // To Default
    public void OnButtonCorridorToDefaultClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[0], 0.8f);

        ChangeSceneButton_CorridorToDefault.SetActive(false);
        ChangeSceneButton_Shunou.SetActive(false);
        ChangeSceneButton_ParentsRoom.SetActive(false);
        GamePlayButton_Corridor_GirlRoomPlate.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_Default, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_Kyakuma.SetActive(true);
            ChangeSceneButton_Corridor.SetActive(true);
            ChangeSceneButton_Libing.SetActive(true);

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Default);
        });
    }
    // To Shunou
    public void OnButtonShunouClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[0], 0.8f);

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

        Exploration_AudioManager.PlaySE_External(Exploration02_SE[0], 0.8f);

        ChangeSceneButton_CorridorToDefault.SetActive(false);
        ChangeSceneButton_Shunou.SetActive(false);
        ChangeSceneButton_ParentsRoom.SetActive(false);
        GamePlayButton_Corridor_GirlRoomPlate.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_ParentsRoom, MoveSpeed).OnComplete((TweenCallback)(() =>
        {
            ChangeSceneButton_ParentsRoomToCorridor.SetActive(true);
            GamePlayButton_ParentsRoom_Closet.SetActive(true);

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.ParentsRoom);

        }));
    }

    //********** Kyakuma **************
    // Kyakuma To Default
    public void OnButtonKyakumaToDefaultClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[0], 0.8f);

        ChangeSceneButton_KyakumaToDefault.SetActive(false);
        GamePlayButton_Kyakuma_LeftFusuma.SetActive(false);
        GamePlayButton_Kyakuma_RightFusuma.SetActive(false);
        GamePlayButton_Kyakuma_Medal.SetActive(false);

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
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[0], 0.8f);

        ChangeSceneButton_LibingToDefault.SetActive(false);
        ChangeSceneButton_LibingToKitchen.SetActive(false);


        GamePlayButton_Libing_Clock.SetActive(false);
        if (!IsGetDentou)
            GamePlayButton_Libing_Dentou.SetActive(false);

        if (IsGetDentou)
        {
            if (!IsGetHornMedal)
                GamePlayButton_Libing_Sofa.SetActive(false);

        }

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
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[0], 0.8f);

        ChangeSceneButton_LibingToDefault.SetActive(false);
        ChangeSceneButton_LibingToKitchen.SetActive(false);

        GamePlayButton_Libing_Clock.SetActive(false);
        if (!IsGetDentou)
            GamePlayButton_Libing_Dentou.SetActive(false);

        if (IsGetDentou)
        {
            if (!IsGetHornMedal)
                GamePlayButton_Libing_Sofa.SetActive(false);

        }
        MainCamera.transform.DOMove(ScenePos_Kitchen, MoveSpeed).OnComplete((TweenCallback)(() =>
        {
            ChangeSceneButton_KitchenToLibing.SetActive(true);
            GamePlayButton_Kitchen_Todona.SetActive(true);
            if(!DishIsClean)
                GamePlayButton_Kitchen_Shingu.SetActive(true);

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Kitchen);
        }));
    }

    //********** Kitchen **************
    // Kitchen To Libing
    public void OnButtonKitchenToLibingClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[0], 0.8f);

        ChangeSceneButton_KitchenToLibing.SetActive(false);
        GamePlayButton_Kitchen_Todona.SetActive(false);
        GamePlayButton_Kitchen_Shingu.SetActive(false);


        MainCamera.transform.DOMove(ScenePos_Libing, MoveSpeed).OnComplete((TweenCallback)(() =>
        {
            ChangeSceneButton_LibingToDefault.SetActive(true);
            ChangeSceneButton_LibingToKitchen.SetActive(true);

            GamePlayButton_Libing_Clock.SetActive(true);
            if (!IsGetDentou)
                GamePlayButton_Libing_Dentou.SetActive(true);

            if (IsGetDentou)
            {
                if (!IsGetHornMedal)
                    GamePlayButton_Libing_Sofa.SetActive(true);
            }


            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Libing);
        }));
    }

    // ************ Shunou *****************
    // Shunou To Corridor
    public void OnButtonShunouToCorridorClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[0], 0.8f);

        ChangeSceneButton_ShunouToCorridor.SetActive(false);
        GamePlayButton_Shunou_Desk.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_Corridor, MoveSpeed).OnComplete(() =>
        {
            if (IsGetKey)
                ChangeSceneButton_ParentsRoom.SetActive(true);

            ChangeSceneButton_CorridorToDefault.SetActive(true);
            ChangeSceneButton_Shunou.SetActive(true);
            GamePlayButton_Corridor_GirlRoomPlate.SetActive(true);

            Exploration_MouseDetection.SetNowScene(Exploration_02_Scenes.Corridor);
        });
    }

    // *********** ParentsRoom ************
    // ParentsRoom To Corridor
    public void OnButtonParentsRoomToCorridorClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[0], 0.8f);

        ChangeSceneButton_ParentsRoomToCorridor.SetActive(false);
        GamePlayButton_ParentsRoom_Closet.SetActive(false);

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
            Exploration_AudioManager.PlaySE_External(Exploration02_SE[3], 0.6f);
            LeftFusumaClickCount += 1;
            if (LeftFusumaClickCount >= 4)
            {
                GamePlayButton_Kyakuma_LeftFusuma.SetActive(false);
                IsOpenLeftFusuma = true;
                LeftFusumaClickCount = 4;
            }
        }
        else
        {
            Exploration_AudioManager.PlaySE_External(Exploration02_SE[3], 0.6f);
            RightFusumaClickCount += 1;
            if (RightFusumaClickCount >= 2)
            {
                RightFusumaClickCount = 2;
                IsOpenRightFusuma = true;
                GamePlayButton_Kyakuma_RightFusuma.SetActive(false);
            }
        }

        if (IsOpenLeftFusuma && IsOpenRightFusuma)
        {
            Exploration_AudioManager.PlaySE_External(Exploration02_SE[1], 0.8f);
            MoveScene_Kyakuma.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("RI/Exploration02_Kyakuma_Door_Open");
         
            Items_Kyakuma_Medal.SetActive(true);
            GamePlayButton_Kyakuma_Medal.SetActive(true);
        }
    }
    public void OnGameplayButtonKyakumaMedalClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[2], 0.8f);
        // Left Mouse Button Down
        Items_Kyakuma_Medal.SetActive(false);
        GamePlayButton_Kyakuma_Medal.SetActive(false);
        GetKyakumaMedal = true;

    }
    // ****************  GamePlayButtons_Corridor ****************
    public void OnGameplayButtonGirlRoomPlateClick()
    {
        GamePlayScene_Corridor_GirlRoomPlate.SetActive(true);
        GamePlayButton_Corridor_GirlRoomPlate_Return.SetActive(true);

        if(IsGetBrushMedal&&IsGetDentou&&IsGetHornMedal&&IsGetOnpuMedal)
        {
            Exploration_AudioManager.PlaySE_External(Exploration02_SE[1], 0.8f);
            GamePlayScene_Corridor_GirlRoomPlate.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_GirlRoom_plate_Ver2");
            GamePlayButton_Corridor_GoToNextScene.SetActive(true);
        }

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
        GamePlayButton_Corridor_GoToNextScene.SetActive(false);
    }

    // Goto Next Scene
    public void OnGameplayButtonGotoNextSceneClick()
    {
        // add change scene here
        Debug.Log("Goto Next Scene");
        //SceneManager.LoadScene("StoryScene02");
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
        else 
        {
            if (!IsGetKey)
            {
                Items_Shunou_Key.SetActive(true);
                GamePlayButton_Shunou_Drawer_Key.SetActive(true);
            }
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

        if (!IsGetKey)
        {
            Items_Shunou_Key.SetActive(false);
            GamePlayButton_Shunou_Drawer_Key.SetActive(false);
        }

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
    public void OnGameplayButtonDrawerKeyClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[2], 0.8f);
        Items_Shunou_Key.SetActive(false);
        GamePlayButton_Shunou_Drawer_Key.SetActive(false);

        IsGetKey = true;
    }
    public void OpenDrawer()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[1], 0.8f);
        GamePlayScene_Shunou_Drawer.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("RI/Exploration02_2F_Shunou_drawer_open");
        GamePlayScene_Shunou_Drawer_Minigame.SetActive(false);
        GamePlayButton_Shunou_Drawer_Key.SetActive(true);
        Items_Shunou_Key.SetActive(true);

        IsOpenDrawer = true;
        OnGameplayButtonDrawerMinigameReturnClick();
    }


    // ********** GamePlay ParentsRoom ***********
    public void OnGameplayButtonParentsClosetClick()
    {
        ChangeSceneButton_ParentsRoomToCorridor.SetActive(false);
        GamePlayButton_ParentsRoom_Closet.SetActive(false);

        GamePlayButton_ParentsRoom_Minigame_Return.SetActive(true);
        GamePlayScene_ParentsRoom_Closet.SetActive(true);
        GamePlayScene_ParentsRoom_Closet_Minigame.SetActive(true);


    }
    public void OnGameplayButtonParentsMinigameReturnClick()
    {
        GamePlayButton_ParentsRoom_Minigame_Return.SetActive(false);
        GamePlayScene_ParentsRoom_Closet.SetActive(false);
        GamePlayScene_ParentsRoom_Closet_Minigame.SetActive(false);

        ChangeSceneButton_ParentsRoomToCorridor.SetActive(true);
        GamePlayButton_ParentsRoom_Closet.SetActive(true);
    }
    public void OnGameplayButtonParentsRoomOnpuMedalClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[2], 0.8f);
        IsGetOnpuMedal = true;
        GamePlayButton_ParentsRoom_OnpuMedal.SetActive(false);
        Items_ParentsRoom_OnpuMedal.SetActive(false);

    }
    public void OpenCloset()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[1], 0.8f);
        GamePlayScene_ParentsRoom_Closet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("RI/Exploraton02_ParentsRoom_ClosetOpen");
        GamePlayButton_ParentsRoom_OnpuMedal.SetActive(true);
        Items_ParentsRoom_OnpuMedal.SetActive(true);
        IsOpenCloset = true;
    }


    //************ Gameplay Libing ***********
    public void OnGameplayButtonMinigameClick()
    {
        ChangeSceneButton_LibingToDefault.SetActive(false);
        ChangeSceneButton_LibingToKitchen.SetActive(false);
        GamePlayButton_Libing_Clock.SetActive(false);


        GamePlayButton_Libing_Minigame_Return.SetActive(true);

        if (!IsGetDentou)
            GamePlayButton_Libing_Dentou.SetActive(false);

        if (IsGetDentou)
        {
            if(!IsGetHornMedal)
                GamePlayButton_Libing_Sofa.SetActive(false);
        }
     
        if (IsOpenClock)
        {
            GamePlayScene_Libing_ClockMinigame.SetActive(true);
            if (!IsGetBrushMedal)
                Items_Libing_BrushMedal.SetActive(true);
        }
        else
        {
            GamePlayScene_Libing_ClockMinigame.SetActive(true);
            GamePlayScene_Libing_ClockMinigame_UI.SetActive(true);
        }
    }
    public void OnGameplayButtonLibingMinigameReturnClick()
    {
        ChangeSceneButton_LibingToDefault.SetActive(true);
        ChangeSceneButton_LibingToKitchen.SetActive(true);
        GamePlayButton_Libing_Clock.SetActive(true);

        GamePlayButton_Libing_Minigame_Return.SetActive(false);
        if (!IsGetDentou)
            GamePlayButton_Libing_Dentou.SetActive(true);

        if (IsGetDentou)
        {
            if (!IsGetHornMedal)
                GamePlayButton_Libing_Sofa.SetActive(true);
        }
        if (IsOpenClock)
        {
            GamePlayScene_Libing_ClockMinigame.SetActive(false);
            if (!IsGetBrushMedal)
                Items_Libing_BrushMedal.SetActive(false);
        }
        else
        {
            GamePlayScene_Libing_ClockMinigame.SetActive(false);
            GamePlayScene_Libing_ClockMinigame_UI.SetActive(false);
        }
    }
    public void OnGameplayButtonDentouClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[2], 0.8f);
        IsGetDentou = true;
        Items_Libing_Kaityuudentou.SetActive(false);
        GamePlayButton_Libing_Dentou.SetActive(false);
        GamePlayButton_Libing_Sofa.SetActive(true);
    }
    public void OnGameplayButtonSofaClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[1], 0.8f);
        GamePlayButton_Libing_HornMedal.SetActive(true);
        GamePlayButton_Libing_Sofa.SetActive(false);
        Items_Libing_HornMedal.SetActive(true);
    }
    public void OnGameplayButtonHornMedalClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[2], 0.8f);
        IsGetHornMedal = true;
        Items_Libing_HornMedal.SetActive(false);
        GamePlayButton_Libing_HornMedal.SetActive(false);
    }
    public void OnGameplayButtonBrushMedalClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[2], 0.8f);
        IsGetBrushMedal = true;
        Items_Libing_BrushMedal.SetActive(false);
        GamePlayButton_Libing_BrushMedal.SetActive(false);
    }

    public void OpenClock()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[1], 0.8f);
        GamePlayScene_Libing_ClockMinigame.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("RI/Exploration02_Libing_Openclock");
        GamePlayButton_Libing_BrushMedal.SetActive(true);
        Items_Libing_BrushMedal.SetActive(true);
        IsOpenClock = true;
    }

    // *********** GameplayButton Kitchen ****************
    public void OnGameplayButtonTodonaClick()
    {
        GamePlayButton_Kitchen_Todona_Return.SetActive(true);
        GamePlayScene_Kithchen_Todona.SetActive(true);

        if (DishIsClean)
        {
            Exploration_AudioManager.PlaySE_External(Exploration02_SE[1], 0.8f);
            GamePlayScene_Kithchen_Todona_ClockTime.SetActive(true);
        }

        ChangeSceneButton_KitchenToLibing.SetActive(false);
        GamePlayButton_Kitchen_Shingu.SetActive(false);
        GamePlayButton_Kitchen_Todona.SetActive(false);
    }
    public void OnGameplayButtonTodonaReturnClick()
    {
        ChangeSceneButton_KitchenToLibing.SetActive(true);

        if (!DishIsClean)
            GamePlayButton_Kitchen_Shingu.SetActive(true);


        GamePlayButton_Kitchen_Todona.SetActive(true);

        GamePlayButton_Kitchen_Todona_Return.SetActive(false);
        GamePlayScene_Kithchen_Todona.SetActive(false);

    }

    public void OnGameplayButtonShinguClick()
    {
        GamePlayButton_Kitchen_Dish_Return.SetActive(true);
        GamePlayButton_Kitchen_CleanDish.SetActive(true);
        GamePlayScene_Kithchen_Dish.SetActive(true);

        ChangeSceneButton_KitchenToLibing.SetActive(false);
        GamePlayButton_Kitchen_Shingu.SetActive(false);
        GamePlayButton_Kitchen_Todona.SetActive(false);

    }
    public void OnGameplayButtonDishClick()
    {
        Exploration_AudioManager.PlaySE_External(Exploration02_SE[4], 0.8f);
        DishIsClean = true;
        GamePlayButton_Kitchen_CleanDish.SetActive(false);
        GamePlayScene_Kithchen_Dish.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("RI/Exploration02_Item_Dish");
    }
    public void OnGameplayButtonDishReturnClick()
    {
        ChangeSceneButton_KitchenToLibing.SetActive(true);

        if(DishIsClean==false)
            GamePlayButton_Kitchen_Shingu.SetActive(true);

        GamePlayButton_Kitchen_Todona.SetActive(true);

        GamePlayButton_Kitchen_Dish_Return.SetActive(false);
        GamePlayButton_Kitchen_CleanDish.SetActive(false);
        GamePlayScene_Kithchen_Dish.SetActive(false);
    }
}
