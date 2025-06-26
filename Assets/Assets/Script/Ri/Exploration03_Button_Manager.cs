using DG.Tweening;
using Fungus;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Exploration_03_Scenes
{
    Default = 0,
    Nazotoki_1 = 1,
    Nazotoki_2 = 3,

}

public class Exploration03_Button_Manager : MonoBehaviour
{
    public Camera MainCamera;
    private Exploration_03_Scenes NowScene;

    [Header("SEs")]
    public AudioClip[] Exploration03_SE;

    [Header("ChangeButtons")]
    [Header("ChangeButtons_Default")]
    // To Nazotoki_1 Button
    public GameObject ChangeSceneButton_DefaultToNazotoki01;

    [Header("ChangeButtons_Nazotoki_1")]
    // To Default Button
    public GameObject ChangeSceneButton_Nazotoki01ToDefault;
    public GameObject ChangeSceneButton_Nazotoki01ToNazotoki02;


    [Header("ChangeButtons_Nazotoki_2")]
    public GameObject ChangeSceneButton_Nazotoki02ToNazotoki01;

    [Header("GamePlayButtons_Nazotoki_1")]
    //public GameObject GamePlayButton_Kyakuma_LeftFusuma;
    public GameObject GamePlayButton_Nazotoki01_Ningyou;
    public GameObject GamePlayButton_Nazotoki01_Ningyou_Return;
    public GameObject GamePlayButton_Nazotoki01_Hinto;
    public GameObject GamePlayButton_Nazotoki01_HintoImage;
    public GameObject GamePlayButton_Nazotoki01_Hinto_Return;


    public GameObject GamePlayButton_Nazotoki01_Ningyou_Parent;
    public GameObject[] GamePlayButton_Nazotoki01_Ningyou_Minigame;
    private int[] GamePlayScene_Nazotoki01_Ningyou_ClickNumber = new int[4] { 0, 0, 0, 0 };

    public GameObject GamePlayButton_Nazotoki01_Butudan;
    public GameObject GamePlayButton_Nazotoki01_Butudan_Return;

    public GameObject GamePlayButton_Nazotoki01_CheckButudan;
    public GameObject GamePlayButton_Nazotoki01_GotoNextScene;

    public GameObject GamePlayButton_Nazotoki01_Kinko;
    public GameObject GamePlayButton_Nazotoki01_Kinko_Return;

    public GameObject GamePlayButton_Nazotoki01_KinkoMinigame;

    public GameObject GamePlayButton_Nazotoki01_KinkoNazo;
    public GameObject GamePlayButton_Nazotoki01_KinkoNazo_Return;
    bool NingyouNazotoki = false;
    bool KinkoNazotoki = false;



    [Header("GamePlayButtons_Nazotoki_2")]
    public GameObject GamePlayButton_Nazotoki02_Kinko;
    public GameObject GamePlayButton_Nazotoki02_Kinko_Return;
    public GameObject GamePlayButton_Nazotoki02_Hekiga;
    public GameObject GamePlayButton_Nazotoki02_Hekiga_Return;

    public GameObject GamePlayButton_Nazotoki02_Tatami;
    public GameObject GamePlayButton_Nazotoki02_Tatami_Return;

    public GameObject GamePlayButton_Nazotoki02_TatamiMinigame;

    public GameObject GamePlayButton_KinkoMinigame;
    public GameObject[] GamePlayButton_KinkoNumber;
    private int[] KinkoNumber = new int[3] { 0, 0, 0 };

    [Header("GamePlayButtons_EndNazo")]
    public GameObject GamePlayButton_EndNazo;


    [Header("GamePlayScene_Nazotoki01")]
    public GameObject GamePlayScene_Nazotoki01_Butudan;
    public GameObject GamePlayScene_Nazotoki01_Kinko;
    public GameObject GamePlayScene_Nazotoki01_KinkoNazo;

    [Header("GamePlayScene_Nazotoki02")]
    public GameObject GamePlayScene_Nazotoki02_Hekiga;
    public GameObject GamePlayScene_Nazotoki02_Kinko;
    public GameObject GamePlayScene_Nazotoki02_Tatami;

    [Header("ChangeScene")]
    public GameObject MoveScene_Default;
    public GameObject MoveScene_Nazotoki_1;
    public GameObject MoveScene_Nazotoki_2;


    [Header("Items_Nazotoki01")]
    public GameObject Items_Nazotoki01_Key;
    public GameObject Items_Fox;
    public GameObject Items_KaishiSora;
    private bool IsGetKey = false;
    private bool IsGetSora = false;
    private bool CanRotateNingyou = true;


    [Header("Items_Nazotoki02")]
    public GameObject Items_Kihuda;

    public GameObject Items_0;
    public GameObject Items_3;
    public GameObject Items_1;
    private bool IsNingyou01Success = false;
    private bool IsNingyou02Success = false;
    private bool IsNingyou03Success = false;
    private bool CanChangeKinkoNumber = true;
    private bool IsGetKihuda = false;

    [Header("Items_EndNazo")]
    public GameObject Items_Kihuda_End;
    public GameObject Items_KaishiSora_End;
    public GameObject Items_KihudaSora;
    private bool isGetKihudaSora;
    private bool canShowEndNazo=false;
    private bool canCheckEndNazo = true;

    public float MoveSpeed = 2.0f;

    private Vector3 ScenePos_Default;
    private Vector3 ScenePos_Nazotoki_1;
    private Vector3 ScenePos_Nazotoki_2;

    public AudioManager Exploration03_AudioManager;
    private MouseDetection03 Exploration03_MouseDetection;

    // Start is called before the first frame update
    void Start()
    {
        Exploration03_AudioManager = this.GetComponent<AudioManager>();
        Exploration03_MouseDetection = this.GetComponent<MouseDetection03>();

        // add all button's event listener
        // ************** Change Scene buttons ******************
        // ******* Default *****
        ChangeSceneButton_DefaultToNazotoki01.GetComponent<Button>().onClick.AddListener(()=>OnChangeSceneButton_DefaultToNazotoki01_Click());

        // ******* Nazotoki01 *****
        ChangeSceneButton_Nazotoki01ToDefault.GetComponent<Button>().onClick.AddListener(() => OnChangeSceneButton_Nazotoki01ToDefault_Click());
        ChangeSceneButton_Nazotoki01ToNazotoki02.GetComponent<Button>().onClick.AddListener(() => OnChangeSceneButton_Nazotoki01ToNazotoki02_Click());


        // ******* Nazotoki02 *****
        ChangeSceneButton_Nazotoki02ToNazotoki01.GetComponent<Button>().onClick.AddListener(() => OnChangeSceneButton_Nazotoki02ToNazotoki01_Click());

        // ************** Game Play buttons ******************
        // ************* Nazotoki01 **************
        GamePlayButton_Nazotoki01_Ningyou.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Ningyou_Click());
        GamePlayButton_Nazotoki01_Ningyou_Return.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Ningyou_Return_Click());

        GamePlayButton_Nazotoki01_Hinto.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Hinto_Click());
        GamePlayButton_Nazotoki01_Hinto_Return.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Hinto_Return_Click());

      
        GamePlayButton_Nazotoki01_Ningyou_Minigame[0].GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Ningyou01_Click());
        GamePlayButton_Nazotoki01_Ningyou_Minigame[1].GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Ningyou02_Click());
        GamePlayButton_Nazotoki01_Ningyou_Minigame[2].GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Ningyou03_Click());
        GamePlayButton_Nazotoki01_Ningyou_Minigame[3].GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Ningyou04_Click());

        Items_Nazotoki01_Key.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Key_Click());

        GamePlayButton_Nazotoki01_Butudan.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Butudan_Click());
        GamePlayButton_Nazotoki01_Butudan_Return.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Butudan_Return_Click());
        Items_KaishiSora.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_KaishiSora_Click());
        GamePlayButton_Nazotoki01_CheckButudan.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_CheckButudan_Click());
        GamePlayButton_Nazotoki01_GotoNextScene.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_GotoNextScene_Click());
        GamePlayButton_Nazotoki01_Kinko.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Kinko_Click());
        GamePlayButton_Nazotoki01_Kinko_Return.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Kinko_Return_Click());

        //GamePlayButton_Nazotoki01_KinkoEntry.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_KinkoEntry_Click());
        //GamePlayButton_Nazotoki01_KinkoMinigame_Return.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_KinkoMinigame_Return_Click());


        GamePlayButton_Nazotoki01_KinkoNazo.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_KinkoNazo_Click());
        GamePlayButton_Nazotoki01_KinkoNazo_Return.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_KinkoNazo_Return_Click());

        // ************* Nazotoki02 **************
        GamePlayButton_Nazotoki02_Hekiga.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki02_Hekiga_Click());
        GamePlayButton_Nazotoki02_Hekiga_Return.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki02_Hekiga_Return_Click());
        GamePlayButton_Nazotoki02_Tatami.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki02_Tatami_Click());
        GamePlayButton_Nazotoki02_Tatami_Return.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki02_Tatami_Return_Click());
        GamePlayButton_Nazotoki02_Kinko.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki02_Kinko_Click());
        GamePlayButton_Nazotoki02_Kinko_Return.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki02_Kinko_Return_Click());

        GamePlayButton_KinkoNumber[0].GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki02_KinkoNumber01_Click());
        GamePlayButton_KinkoNumber[1].GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki02_KinkoNumber02_Click());
        GamePlayButton_KinkoNumber[2].GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki02_KinkoNumber03_Click());

        Items_Kihuda.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki02_Kihuda_Click());


        // ************* Nazotoki02 **************
        GamePlayButton_EndNazo.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_EndNazo_Click());
      
        Items_KihudaSora.GetComponent<Button>().onClick.AddListener(() => Items_KihudaSora_Click());

        // ************** Game Play Scenes ******************



        // Move Scene's Position

        ScenePos_Default = new Vector3(MoveScene_Default.GetComponent<Transform>().position.x,
                                       MoveScene_Default.GetComponent<Transform>().position.y,
                                      -10.0f);
        ScenePos_Nazotoki_1 = new Vector3(MoveScene_Nazotoki_1.GetComponent<Transform>().position.x,
                                       MoveScene_Nazotoki_1.GetComponent<Transform>().position.y,
                                      -10.0f);
        ScenePos_Nazotoki_2 = new Vector3(MoveScene_Nazotoki_2.GetComponent<Transform>().position.x,
                                      MoveScene_Nazotoki_2.GetComponent<Transform>().position.y,
                                     -10.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if(IsGetSora&&IsGetKihuda&& canCheckEndNazo)
        {
            canShowEndNazo = true;
        }
    }

    // ********  Change Scene Button Logic ***********
    // *********** Default *********
    // To Nazotoki_1
    public void OnChangeSceneButton_DefaultToNazotoki01_Click()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[0], 1.0f);


        ChangeSceneButton_DefaultToNazotoki01.SetActive(false);
        if (canShowEndNazo)
            GamePlayButton_EndNazo.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_Nazotoki_1, MoveSpeed).OnComplete(() =>
        {
            if (canShowEndNazo)
                GamePlayButton_EndNazo.SetActive(true);

            NowScene = Exploration_03_Scenes.Nazotoki_1;
            Exploration03_MouseDetection.SetNowScene(NowScene);

            ChangeSceneButton_Nazotoki01ToDefault.SetActive(true);
            ChangeSceneButton_Nazotoki01ToNazotoki02.SetActive(true);

            GamePlayButton_Nazotoki01_Ningyou.SetActive(true);
            GamePlayButton_Nazotoki01_Hinto.SetActive(true);
            if (IsGetKey)
            {
                GamePlayButton_Nazotoki01_Butudan.SetActive(true);
                GamePlayButton_Nazotoki01_Kinko.SetActive(true);
                GamePlayButton_Nazotoki01_KinkoNazo.SetActive(true);
            }
          

        }); ;
    }


    // *********** Nazotoki_1 *********
    // To Default
    public void OnChangeSceneButton_Nazotoki01ToDefault_Click()
    {
        if (canShowEndNazo)
            GamePlayButton_EndNazo.SetActive(false);
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[0], 1.0f);

        ChangeSceneButton_Nazotoki01ToDefault.SetActive(false);
        ChangeSceneButton_Nazotoki01ToNazotoki02.SetActive(false);

        GamePlayButton_Nazotoki01_Ningyou.SetActive(false);
        GamePlayButton_Nazotoki01_Hinto.SetActive(false);
        if (IsGetKey)
        {
            GamePlayButton_Nazotoki01_Kinko.SetActive(false);
            GamePlayButton_Nazotoki01_KinkoNazo.SetActive(false);
            GamePlayButton_Nazotoki01_Butudan.SetActive(false);
        }

            MainCamera.transform.DOMove(ScenePos_Default, MoveSpeed).OnComplete(() =>
            {
                if (canShowEndNazo)
                    GamePlayButton_EndNazo.SetActive(true);

            NowScene = Exploration_03_Scenes.Default;
            Exploration03_MouseDetection.SetNowScene(NowScene);
            ChangeSceneButton_DefaultToNazotoki01.SetActive(true);

        }); ;
    }
    public void OnChangeSceneButton_Nazotoki01ToNazotoki02_Click()
    {
        if (canShowEndNazo)
            GamePlayButton_EndNazo.SetActive(false);
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[0], 1.0f);

        ChangeSceneButton_Nazotoki01ToDefault.SetActive(false);
        ChangeSceneButton_Nazotoki01ToNazotoki02.SetActive(false);

        GamePlayButton_Nazotoki01_Ningyou.SetActive(false);
        GamePlayButton_Nazotoki01_Hinto.SetActive(false);


        if (IsGetKey)
        {
            GamePlayButton_Nazotoki01_Kinko.SetActive(false);
            GamePlayButton_Nazotoki01_KinkoNazo.SetActive(false);
            GamePlayButton_Nazotoki01_Butudan.SetActive(false);
        }

        MainCamera.transform.DOMove(ScenePos_Nazotoki_2, MoveSpeed).OnComplete(() =>
        {
            if (canShowEndNazo)
                GamePlayButton_EndNazo.SetActive(true);
            NowScene = Exploration_03_Scenes.Nazotoki_2;
            Exploration03_MouseDetection.SetNowScene(NowScene);
            ChangeSceneButton_Nazotoki02ToNazotoki01.SetActive(true);
            GamePlayButton_Nazotoki02_Hekiga.SetActive(true);
            GamePlayButton_Nazotoki02_Kinko.SetActive(true);
            GamePlayButton_Nazotoki02_Tatami.SetActive(true);
        }); ;
    }


    public void OnChangeSceneButton_Nazotoki02ToNazotoki01_Click()
    {
        if (canShowEndNazo)
            GamePlayButton_EndNazo.SetActive(false);
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[0], 1.0f);

        ChangeSceneButton_Nazotoki02ToNazotoki01.SetActive(false);

        GamePlayButton_Nazotoki02_Kinko.SetActive(false);
        GamePlayButton_Nazotoki02_Hekiga.SetActive(false);
        GamePlayButton_Nazotoki02_Tatami.SetActive(false);
      

        MainCamera.transform.DOMove(ScenePos_Nazotoki_1, MoveSpeed).OnComplete(() =>
        {
            if (canShowEndNazo)
                GamePlayButton_EndNazo.SetActive(true);
            NowScene = Exploration_03_Scenes.Nazotoki_1;
            Exploration03_MouseDetection.SetNowScene(NowScene);

            ChangeSceneButton_Nazotoki01ToDefault.SetActive(true);
            ChangeSceneButton_Nazotoki01ToNazotoki02.SetActive(true);

            GamePlayButton_Nazotoki01_Ningyou.SetActive(true);
            GamePlayButton_Nazotoki01_Hinto.SetActive(true);
            if (IsGetKey)
            {
                GamePlayButton_Nazotoki01_Butudan.SetActive(true);
                GamePlayButton_Nazotoki01_Kinko.SetActive(true);
                GamePlayButton_Nazotoki01_KinkoNazo.SetActive(true);
            }
        }); ;
    }

    // ********  Game Play Button Logic ***********
    // ********* Nazotoki01 *************

    public void OnGamePlayButton_Nazotoki01_Key_Click()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[10], 1.0f);
        IsGetKey = true;
        Items_Nazotoki01_Key.SetActive(false);
    }
    public void OnGamePlayButton_Nazotoki01_Ningyou_Click()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[0], 1.0f);

        GamePlayButton_Nazotoki01_Ningyou_Return.SetActive(true);
        GamePlayButton_Nazotoki01_Ningyou_Parent.SetActive(true);


        ChangeSceneButton_Nazotoki01ToDefault.SetActive(false);
        ChangeSceneButton_Nazotoki01ToNazotoki02.SetActive(false);

        GamePlayButton_Nazotoki01_Hinto.SetActive(false);
        GamePlayButton_Nazotoki01_Ningyou.SetActive(false);

        if (IsGetKey)
        {
            GamePlayButton_Nazotoki01_Butudan.SetActive(false);
            GamePlayButton_Nazotoki01_Kinko.SetActive(false);
            GamePlayButton_Nazotoki01_KinkoNazo.SetActive(false);
        }

    }
    public void OnGamePlayButton_Nazotoki01_Ningyou_Return_Click()
    {
        GamePlayButton_Nazotoki01_Ningyou_Return.SetActive(false);
        GamePlayButton_Nazotoki01_Ningyou_Parent.SetActive(false);

        ChangeSceneButton_Nazotoki01ToDefault.SetActive(true);
        ChangeSceneButton_Nazotoki01ToNazotoki02.SetActive(true);

        GamePlayButton_Nazotoki01_Ningyou.SetActive(true);
        GamePlayButton_Nazotoki01_Hinto.SetActive(true);

        if (IsGetKey)
        {
            GamePlayButton_Nazotoki01_Butudan.SetActive(true);
            GamePlayButton_Nazotoki01_Kinko.SetActive(true);
            GamePlayButton_Nazotoki01_KinkoNazo.SetActive(true);
        }

    }
    public void OnGamePlayButton_Nazotoki01_Hinto_Click()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[0], 1.0f);

        GamePlayButton_Nazotoki01_HintoImage.SetActive(true);
        GamePlayButton_Nazotoki01_Hinto_Return.SetActive(true);

        ChangeSceneButton_Nazotoki01ToDefault.SetActive(false);
        ChangeSceneButton_Nazotoki01ToNazotoki02.SetActive(false);

        GamePlayButton_Nazotoki01_Hinto.SetActive(false);
        GamePlayButton_Nazotoki01_Ningyou.SetActive(false);

        if (IsGetKey)
        {
            GamePlayButton_Nazotoki01_Butudan.SetActive(false);
            GamePlayButton_Nazotoki01_Kinko.SetActive(false);
            GamePlayButton_Nazotoki01_KinkoNazo.SetActive(false);
        }

    }
    public void OnGamePlayButton_Nazotoki01_Hinto_Return_Click()
    {
        GamePlayButton_Nazotoki01_HintoImage.SetActive(false);
        GamePlayButton_Nazotoki01_Hinto_Return.SetActive(false);

        ChangeSceneButton_Nazotoki01ToDefault.SetActive(true);
        ChangeSceneButton_Nazotoki01ToNazotoki02.SetActive(true);
        GamePlayButton_Nazotoki01_Hinto.SetActive(true);
        GamePlayButton_Nazotoki01_Ningyou.SetActive(true);

        if (IsGetKey)
        {
            GamePlayButton_Nazotoki01_Butudan.SetActive(true);
            GamePlayButton_Nazotoki01_Kinko.SetActive(true);
            GamePlayButton_Nazotoki01_KinkoNazo.SetActive(true);
        }

    }

    // Minigame01 Fox's key
    public void OnGamePlayButton_Nazotoki01_Ningyou01_Click()
    {
        if (CanRotateNingyou)
        {
            Exploration03_AudioManager.PlaySE_External(Exploration03_SE[1], 0.3f);

            GamePlayScene_Nazotoki01_Ningyou_ClickNumber[0] =
          GamePlayScene_Nazotoki01_Ningyou_ClickNumber[0] == 3 ? 0 : GamePlayScene_Nazotoki01_Ningyou_ClickNumber[0] += 1;
            switch (GamePlayScene_Nazotoki01_Ningyou_ClickNumber[0])
            {
                case 0:
                    GamePlayButton_Nazotoki01_Ningyou_Minigame[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_Ningyou_Syoumen");
                    break;
                case 1:
                    GamePlayButton_Nazotoki01_Ningyou_Minigame[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_NingyouMigi");
                    break;
                case 2:
                    GamePlayButton_Nazotoki01_Ningyou_Minigame[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_NingyouUshiro");
                    break;
                case 3:
                    GamePlayButton_Nazotoki01_Ningyou_Minigame[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_Ningyou_Hidari");
                    break;
            }
            CheckNingyouMinigame();
        }
      

    }
    public void OnGamePlayButton_Nazotoki01_Ningyou02_Click()
    {
        if (CanRotateNingyou)
        {
            Exploration03_AudioManager.PlaySE_External(Exploration03_SE[1], 0.3f);

            GamePlayScene_Nazotoki01_Ningyou_ClickNumber[1] =
      GamePlayScene_Nazotoki01_Ningyou_ClickNumber[1] == 3 ? 0 : GamePlayScene_Nazotoki01_Ningyou_ClickNumber[1] += 1;
            switch (GamePlayScene_Nazotoki01_Ningyou_ClickNumber[1])
            {
                case 0:
                    GamePlayButton_Nazotoki01_Ningyou_Minigame[1].GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_Ningyou_Syoumen");
                    break;
                case 1:
                    GamePlayButton_Nazotoki01_Ningyou_Minigame[1].GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_NingyouMigi");
                    break;
                case 2:
                    GamePlayButton_Nazotoki01_Ningyou_Minigame[1].GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_NingyouUshiro");
                    break;
                case 3:
                    GamePlayButton_Nazotoki01_Ningyou_Minigame[1].GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_Ningyou_Hidari");
                    break;
            }
            CheckNingyouMinigame();
        }
      
    }
    public void OnGamePlayButton_Nazotoki01_Ningyou03_Click()
    {
        if (CanRotateNingyou)
        {
            Exploration03_AudioManager.PlaySE_External(Exploration03_SE[1], 0.3f);

            GamePlayScene_Nazotoki01_Ningyou_ClickNumber[2] =
                   GamePlayScene_Nazotoki01_Ningyou_ClickNumber[2] == 3 ? 0 : GamePlayScene_Nazotoki01_Ningyou_ClickNumber[2] += 1;
            switch (GamePlayScene_Nazotoki01_Ningyou_ClickNumber[2])
            {
                case 0:
                    GamePlayButton_Nazotoki01_Ningyou_Minigame[2].GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_Ningyou_Syoumen");
                    break;
                case 1:
                    GamePlayButton_Nazotoki01_Ningyou_Minigame[2].GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_NingyouMigi");
                    break;
                case 2:
                    GamePlayButton_Nazotoki01_Ningyou_Minigame[2].GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_NingyouUshiro");
                    break;
                case 3:
                    GamePlayButton_Nazotoki01_Ningyou_Minigame[2].GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_Ningyou_Hidari");
                    break;
            }
            CheckNingyouMinigame();
        }

       
    }
    public void OnGamePlayButton_Nazotoki01_Ningyou04_Click()
    {
        if (CanRotateNingyou)
        {
            Exploration03_AudioManager.PlaySE_External(Exploration03_SE[1], 0.3f);

            GamePlayScene_Nazotoki01_Ningyou_ClickNumber[3] =
                   GamePlayScene_Nazotoki01_Ningyou_ClickNumber[3] == 3 ? 0 : GamePlayScene_Nazotoki01_Ningyou_ClickNumber[3] += 1;
            switch (GamePlayScene_Nazotoki01_Ningyou_ClickNumber[3])
            {
                case 0:
                    GamePlayButton_Nazotoki01_Ningyou_Minigame[3].GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_Ningyou_Syoumen");
                    break;
                case 1:
                    GamePlayButton_Nazotoki01_Ningyou_Minigame[3].GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_NingyouMigi");
                    break;
                case 2:
                    GamePlayButton_Nazotoki01_Ningyou_Minigame[3].GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_NingyouUshiro");
                    break;
                case 3:
                    GamePlayButton_Nazotoki01_Ningyou_Minigame[3].GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_Ningyou_Hidari");
                    break;
            }
            CheckNingyouMinigame();
        }


        }

    private void CheckNingyouMinigame()
    {
        if (GamePlayScene_Nazotoki01_Ningyou_ClickNumber[0]==3&&
            GamePlayScene_Nazotoki01_Ningyou_ClickNumber[1] == 2 &&
            GamePlayScene_Nazotoki01_Ningyou_ClickNumber[2] == 1 &&
            GamePlayScene_Nazotoki01_Ningyou_ClickNumber[3] == 0)
        {
            NingyouNazotoki = true;
            NingyouMinigameSuccess();

        }
    }
    private void NingyouMinigameSuccess()
    {
        GamePlayButton_Nazotoki01_Ningyou_Return.SetActive(false);
        GamePlayButton_Nazotoki01_Ningyou_Minigame[3].SetActive(false);

        StartCoroutine(Fox01());
    }
    
    IEnumerator Fox01()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[2], 1.0f);
        CanRotateNingyou = false;
        yield return new WaitForSeconds(0.5f);
        Items_Fox.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        Items_Fox.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 200);
        Items_Fox.GetComponent<Image>().sprite= Resources.Load<Sprite>("RI/Exploration_03/Fox/Exploration03_Kura_Nazo1_Kitune_Aruki");

        yield return new WaitForSeconds(1.0f);
        Items_Fox.GetComponent<Image>().sprite = Resources.Load<Sprite>("RI/Exploration_03/Fox/Exploration03_Kura_Nazo1_Kitune_Hashiri");

        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[3], 1.0f);
        yield return new WaitForSeconds(0.5f);
        Items_Fox.SetActive(false);
        Items_Nazotoki01_Key.SetActive(true);
        GamePlayButton_Nazotoki01_Ningyou_Return.SetActive(true);
    }

    public void OnGamePlayButton_Nazotoki01_Butudan_Click()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[0], 1.0f);
        GamePlayScene_Nazotoki01_Butudan.SetActive(true);
        GamePlayButton_Nazotoki01_Butudan_Return.SetActive(true);

        if(KinkoNazotoki&& !IsGetSora)
        {
            Items_KaishiSora.SetActive(true);
        }
        if (isGetKihudaSora)
        {
            GamePlayButton_Nazotoki01_CheckButudan.SetActive(true);
            GamePlayButton_Nazotoki01_Butudan_Return.SetActive(false);
        }


        ChangeSceneButton_Nazotoki01ToDefault.SetActive(false);
        ChangeSceneButton_Nazotoki01ToNazotoki02.SetActive(false);
        GamePlayButton_Nazotoki01_Hinto.SetActive(false);
        GamePlayButton_Nazotoki01_Ningyou.SetActive(false);

        GamePlayButton_Nazotoki01_Butudan.SetActive(false);
        GamePlayButton_Nazotoki01_Kinko.SetActive(false);
        GamePlayButton_Nazotoki01_KinkoNazo.SetActive(false);

    }
    public void OnGamePlayButton_Nazotoki01_Butudan_Return_Click()
    {
        GamePlayScene_Nazotoki01_Butudan.SetActive(false);
        GamePlayButton_Nazotoki01_Butudan_Return.SetActive(false);

        if (KinkoNazotoki && !IsGetSora)
        {
            Items_KaishiSora.SetActive(false);
        }
        ChangeSceneButton_Nazotoki01ToDefault.SetActive(true);
        ChangeSceneButton_Nazotoki01ToNazotoki02.SetActive(true);

        GamePlayButton_Nazotoki01_Hinto.SetActive(true);
        GamePlayButton_Nazotoki01_Ningyou.SetActive(true);
        GamePlayButton_Nazotoki01_Butudan.SetActive(true);
        GamePlayButton_Nazotoki01_Kinko.SetActive(true);
        GamePlayButton_Nazotoki01_KinkoNazo.SetActive(true);

        if (canShowEndNazo)
            GamePlayButton_EndNazo.SetActive(true);

    }

    public void OnGamePlayButton_Nazotoki01_CheckButudan_Click()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[11], 1.0f);
        GamePlayButton_Nazotoki01_CheckButudan.SetActive(false);
        GamePlayScene_Nazotoki01_Butudan.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_ButudanMakimono");
        GamePlayButton_Nazotoki01_GotoNextScene.SetActive(true);
    
    }
    public void OnGamePlayButton_Nazotoki01_GotoNextScene_Click()
    {
        // add goto next scene here
        Debug.Log("Goto next scene");
        SceneManager.LoadScene("StoryScene06");
    }
    public void OnGamePlayButton_Nazotoki01_KaishiSora_Click()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[7], 1.0f);
        IsGetSora = true;

        Items_KaishiSora.SetActive(false);
    }
    public void OnGamePlayButton_Nazotoki01_Kinko_Click()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[4], 1.0f);
        GamePlayScene_Nazotoki01_Kinko.SetActive(true);
        GamePlayButton_Nazotoki01_Kinko_Return.SetActive(true);
        GamePlayButton_Nazotoki01_KinkoMinigame.SetActive(true);
        //GamePlayButton_Nazotoki01_KinkoEntry.SetActive(true);

        ChangeSceneButton_Nazotoki01ToDefault.SetActive(false);
        ChangeSceneButton_Nazotoki01ToNazotoki02.SetActive(false);

        GamePlayButton_Nazotoki01_Hinto.SetActive(false);
        GamePlayButton_Nazotoki01_Ningyou.SetActive(false);

        GamePlayButton_Nazotoki01_Kinko.SetActive(false);
        GamePlayButton_Nazotoki01_KinkoNazo.SetActive(false);

        GamePlayButton_Nazotoki01_Butudan.SetActive(false);
    }
    public void OnGamePlayButton_Nazotoki01_Kinko_Return_Click()
    {
        GamePlayScene_Nazotoki01_Kinko.SetActive(false);
        GamePlayButton_Nazotoki01_Kinko_Return.SetActive(false);
        GamePlayButton_Nazotoki01_KinkoMinigame.SetActive(false);
        //GamePlayButton_Nazotoki01_KinkoEntry.SetActive(false);

        ChangeSceneButton_Nazotoki01ToDefault.SetActive(true);
        ChangeSceneButton_Nazotoki01ToNazotoki02.SetActive(true);

        GamePlayButton_Nazotoki01_Hinto.SetActive(true);
        GamePlayButton_Nazotoki01_Ningyou.SetActive(true);

        GamePlayButton_Nazotoki01_Butudan.SetActive(true);
        GamePlayButton_Nazotoki01_Kinko.SetActive(true);
        GamePlayButton_Nazotoki01_KinkoNazo.SetActive(true);
    }
   
    public void OnNazotoki01_KinkoMinigameSE()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[5], 1.0f);
    }
    public void OnGamePlayButton_Nazotoki01_KinkoNazo_Click()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[0], 1.0f);
        GamePlayScene_Nazotoki01_KinkoNazo.SetActive(true);
        GamePlayButton_Nazotoki01_KinkoNazo_Return.SetActive(true);

        ChangeSceneButton_Nazotoki01ToDefault.SetActive(false);
        ChangeSceneButton_Nazotoki01ToNazotoki02.SetActive(false);

        GamePlayButton_Nazotoki01_Hinto.SetActive(false);
        GamePlayButton_Nazotoki01_Ningyou.SetActive(false);

        GamePlayButton_Nazotoki01_Kinko.SetActive(false);
        GamePlayButton_Nazotoki01_KinkoNazo.SetActive(false);

        GamePlayButton_Nazotoki01_Butudan.SetActive(false);
    }
    public void OnGamePlayButton_Nazotoki01_KinkoNazo_Return_Click()
    {
        GamePlayScene_Nazotoki01_KinkoNazo.SetActive(false);
        GamePlayButton_Nazotoki01_KinkoNazo_Return.SetActive(false);

        ChangeSceneButton_Nazotoki01ToDefault.SetActive(true);
        ChangeSceneButton_Nazotoki01ToNazotoki02.SetActive(true);

        GamePlayButton_Nazotoki01_Hinto.SetActive(true);
        GamePlayButton_Nazotoki01_Ningyou.SetActive(true);

        if (IsGetKey)
        {
            GamePlayButton_Nazotoki01_Butudan.SetActive(true);
            GamePlayButton_Nazotoki01_Kinko.SetActive(true);
            GamePlayButton_Nazotoki01_KinkoNazo.SetActive(true);
        }
    }

   
    public void KinkoMinigameSuccess()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[6], 0.6f);
        GamePlayScene_Nazotoki01_Butudan.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploraton03_Kura_Butudan_Nazo2");
       
        KinkoNazotoki = true;

        Exploration03_MouseDetection.GetButudanOpen();
    
    }
    // ******************** Nazotoki02 *********************
    public void OnGamePlayButton_Nazotoki02_Hekiga_Click()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[0], 1.0f);
        GamePlayScene_Nazotoki02_Hekiga.SetActive(true);
        GamePlayButton_Nazotoki02_Hekiga_Return.SetActive(true);

        GamePlayButton_Nazotoki02_Hekiga.SetActive(false);
        GamePlayButton_Nazotoki02_Kinko.SetActive(false);
        GamePlayButton_Nazotoki02_Tatami.SetActive(false);

        ChangeSceneButton_Nazotoki02ToNazotoki01.SetActive(false);
    }
    public void OnGamePlayButton_Nazotoki02_Hekiga_Return_Click()
    {
        GamePlayScene_Nazotoki02_Hekiga.SetActive(false);
        GamePlayButton_Nazotoki02_Hekiga_Return.SetActive(false);

        GamePlayButton_Nazotoki02_Hekiga.SetActive(true);
        GamePlayButton_Nazotoki02_Kinko.SetActive(true);
        GamePlayButton_Nazotoki02_Tatami.SetActive(true);

        ChangeSceneButton_Nazotoki02ToNazotoki01.SetActive(true);
    }
    public void OnGamePlayButton_Nazotoki02_Tatami_Click()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[0], 1.0f);

        GamePlayScene_Nazotoki02_Tatami.SetActive(true);
        GamePlayButton_Nazotoki02_Tatami_Return.SetActive(true);
        GamePlayButton_Nazotoki02_TatamiMinigame.SetActive(true);

        GamePlayButton_Nazotoki02_Hekiga.SetActive(false);
        GamePlayButton_Nazotoki02_Kinko.SetActive(false);
        GamePlayButton_Nazotoki02_Tatami.SetActive(false);

        ChangeSceneButton_Nazotoki02ToNazotoki01.SetActive(false);


    }
    public void OnGamePlayButton_Nazotoki02_Tatami_Return_Click()
    {
        GamePlayScene_Nazotoki02_Tatami.SetActive(false);
        GamePlayButton_Nazotoki02_Tatami_Return.SetActive(false);
        GamePlayButton_Nazotoki02_TatamiMinigame.SetActive(false);


        GamePlayButton_Nazotoki02_Hekiga.SetActive(true);
        GamePlayButton_Nazotoki02_Kinko.SetActive(true);
        GamePlayButton_Nazotoki02_Tatami.SetActive(true);

        ChangeSceneButton_Nazotoki02ToNazotoki01.SetActive(true);
    }
    public void OnGamePlayButton_Nazotoki02_Kinko_Click()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[0], 1.0f);

        GamePlayScene_Nazotoki02_Kinko.SetActive(true);
        GamePlayButton_Nazotoki02_Kinko_Return.SetActive(true);
        GamePlayButton_KinkoMinigame.SetActive(true);
        if(!CanChangeKinkoNumber&&!IsGetKihuda)
        {
            Items_Kihuda.SetActive(true);
        }

        GamePlayButton_Nazotoki02_Hekiga.SetActive(false);
        GamePlayButton_Nazotoki02_Kinko.SetActive(false);
        GamePlayButton_Nazotoki02_Tatami.SetActive(false);

        ChangeSceneButton_Nazotoki02ToNazotoki01.SetActive(false);
    }
    public void OnGamePlayButton_Nazotoki02_Kinko_Return_Click()
    {
        GamePlayScene_Nazotoki02_Kinko.SetActive(false);
        GamePlayButton_Nazotoki02_Kinko_Return.SetActive(false);
        GamePlayButton_KinkoMinigame.SetActive(false);

        GamePlayButton_Nazotoki02_Hekiga.SetActive(true);
        GamePlayButton_Nazotoki02_Kinko.SetActive(true);
        GamePlayButton_Nazotoki02_Tatami.SetActive(true);

        ChangeSceneButton_Nazotoki02ToNazotoki01.SetActive(true);

        if (canShowEndNazo)
            GamePlayButton_EndNazo.SetActive(true);
    }

    public void OnGamePlayButton_Nazotoki02_KinkoNumber01_Click()
    {
        if (CanChangeKinkoNumber)
        {
            Exploration03_AudioManager.PlaySE_External(Exploration03_SE[0], 0.6f);
            KinkoNumber[0] = (KinkoNumber[0] == 3) ? 0 : (KinkoNumber[0] + 1);
            GamePlayButton_KinkoNumber[0].GetComponentInChildren<TextMeshProUGUI>().text = KinkoNumber[0].ToString();

            CheckNazotoki02_KinkoNumber();
        }
    }
    public void OnGamePlayButton_Nazotoki02_KinkoNumber02_Click()
    {
        if (CanChangeKinkoNumber)
        {
            Exploration03_AudioManager.PlaySE_External(Exploration03_SE[0], 0.6f);
            KinkoNumber[1] = (KinkoNumber[1] == 3) ? 0 : (KinkoNumber[1] + 1);
            GamePlayButton_KinkoNumber[1].GetComponentInChildren<TextMeshProUGUI>().text = KinkoNumber[1].ToString();

            CheckNazotoki02_KinkoNumber();
        }
    }
    public void OnGamePlayButton_Nazotoki02_KinkoNumber03_Click()
    {
        if (CanChangeKinkoNumber)
        {
            Exploration03_AudioManager.PlaySE_External(Exploration03_SE[0], 0.6f);
            KinkoNumber[2] = (KinkoNumber[2] == 3) ? 0 : (KinkoNumber[2] + 1);
            GamePlayButton_KinkoNumber[2].GetComponentInChildren<TextMeshProUGUI>().text = KinkoNumber[2].ToString();

            CheckNazotoki02_KinkoNumber();
        }
    }
    private void CheckNazotoki02_KinkoNumber()
    {
        if (KinkoNumber[0]==0 && KinkoNumber[1]== 3 && KinkoNumber[2]==1&&CanChangeKinkoNumber)   
        {
            Exploration03_AudioManager.PlaySE_External(Exploration03_SE[11], 1.0f);
            CanChangeKinkoNumber = false;
            Items_Kihuda.SetActive(true);
        }
    }
    private void OnGamePlayButton_Nazotoki02_Kihuda_Click()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[10], 1.0f);
        Items_Kihuda.SetActive(false);
        IsGetKihuda = true;
    }
    public void GetTatamiNingyouSuccessName(string ningyouName)
    {
        if(ningyouName== "GamePlayItem_Ningyou01")
        {
            Exploration03_AudioManager.PlaySE_External(Exploration03_SE[11], 1.0f);

            Items_0.SetActive(true);
        }
        if(ningyouName== "GamePlayItem_Ningyou02")
        {
            Exploration03_AudioManager.PlaySE_External(Exploration03_SE[11], 1.0f);

            Items_3.SetActive(true);

        }
        if (ningyouName == "GamePlayItem_Ningyou03")
        {
            Exploration03_AudioManager.PlaySE_External(Exploration03_SE[11], 1.0f);

            Items_1.SetActive(true);
        }
        // end nazo
        if (ningyouName == "Items_KaishiSora_End"|| ningyouName == "Item_Kihuda_End")
        {
            GetEndNazoSuccess();
        }
       
    }


    //************ EndNazo************
    public void OnGamePlayButton_EndNazo_Click()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[11], 1.0f);


        canShowEndNazo = false;
        canCheckEndNazo = false;

        GamePlayButton_EndNazo.SetActive(false);

        //GamePlayButton_EndNazo_Return.SetActive(true);
        Items_KaishiSora_End.SetActive(true);
        Items_Kihuda_End.SetActive(true);

        if (NowScene==Exploration_03_Scenes.Default)
        {
            ChangeSceneButton_DefaultToNazotoki01.SetActive(false);
        }
        if(NowScene == Exploration_03_Scenes.Nazotoki_1)
        {
            ChangeSceneButton_Nazotoki01ToDefault.SetActive(false);
            ChangeSceneButton_Nazotoki01ToNazotoki02.SetActive(false);

            GamePlayButton_Nazotoki01_Ningyou.SetActive(false);
            GamePlayButton_Nazotoki01_Hinto.SetActive(false);
            if (IsGetKey)
            {
                GamePlayButton_Nazotoki01_Kinko.SetActive(false);
                GamePlayButton_Nazotoki01_KinkoNazo.SetActive(false);
                GamePlayButton_Nazotoki01_Butudan.SetActive(false);
            }

        }
        if (NowScene == Exploration_03_Scenes.Nazotoki_2)
        {
            ChangeSceneButton_Nazotoki02ToNazotoki01.SetActive(false);

            GamePlayButton_Nazotoki02_Kinko.SetActive(false);
            GamePlayButton_Nazotoki02_Hekiga.SetActive(false);
            GamePlayButton_Nazotoki02_Tatami.SetActive(false);
        }
    }

    public void Items_KihudaSora_Click()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[6], 1.0f);

        Exploration03_MouseDetection.GetKihudaSora();
        isGetKihudaSora = true;
        Items_KihudaSora.SetActive(false);

        GamePlayScene_Nazotoki01_Butudan.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("RI/Exploration_03/object/Exploration03_Kura_ButudanKihuda");

        if (NowScene == Exploration_03_Scenes.Default)
        {
            ChangeSceneButton_DefaultToNazotoki01.SetActive(true);
        }
        if (NowScene == Exploration_03_Scenes.Nazotoki_1)
        {
            ChangeSceneButton_Nazotoki01ToDefault.SetActive(true);
            ChangeSceneButton_Nazotoki01ToNazotoki02.SetActive(true);

            GamePlayButton_Nazotoki01_Ningyou.SetActive(true);
            GamePlayButton_Nazotoki01_Hinto.SetActive(true);
            if (IsGetKey)
            {
                GamePlayButton_Nazotoki01_Kinko.SetActive(true);
                GamePlayButton_Nazotoki01_KinkoNazo.SetActive(true);
                GamePlayButton_Nazotoki01_Butudan.SetActive(true);
            }

        }
        if (NowScene == Exploration_03_Scenes.Nazotoki_2)
        {
            ChangeSceneButton_Nazotoki02ToNazotoki01.SetActive(true);

            GamePlayButton_Nazotoki02_Kinko.SetActive(true);
            GamePlayButton_Nazotoki02_Hekiga.SetActive(true);
            GamePlayButton_Nazotoki02_Tatami.SetActive(true);
        }
    }
    public void GetEndNazoSuccess()
    {
        Exploration03_AudioManager.PlaySE_External(Exploration03_SE[11], 1.0f);
        Items_KaishiSora_End.SetActive(false);
        Items_Kihuda_End.SetActive(false);
        Items_KihudaSora.SetActive(true);

    }
}
