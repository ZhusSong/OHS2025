using DG.Tweening;
using Fungus;
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

    [Header("SEs")]
    public AudioClip[] Exploration03_SE;

    [Header("ChangeButtons")]
    [Header("ChangeButtons_Default")]
    // To Nazotoki_1 Button
    public GameObject ChangeSceneButton_DefaultToNazotoki01;

    [Header("ChangeButtons_Nazotoki_1")]
    // To Default Button
    public GameObject ChangeSceneButton_Nazotoki01ToDefault;



    [Header("GamePlayButtons_Nazotoki_1")]
    //public GameObject GamePlayButton_Kyakuma_LeftFusuma;
    public GameObject GamePlayButton_Nazotoki01_Ningyou;
    public GameObject GamePlayButton_Nazotoki01_Ningyou_Return;
    public GameObject GamePlayButton_Nazotoki01_Hinto;
    public GameObject GamePlayButton_Nazotoki01_Hinto_Return;

    bool NingyouNazotoki = false;


    [Header("Items_Kyakuma")]


    [Header("ChangeScene")]
    public GameObject MoveScene_Default;
    public GameObject MoveScene_Nazotoki_1;


    [Header("Items_Shunou")]
    public GameObject Items_Shunou_Key;
    private bool IsGetKey = false;
    private bool IsOpenDrawer = false;


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



        // ************** Game Play buttons ******************
        // ************* Nazotoki01 **************
        GamePlayButton_Nazotoki01_Ningyou.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Ningyou_Click());
        GamePlayButton_Nazotoki01_Ningyou_Return.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Ningyou_Return_Click());

        GamePlayButton_Nazotoki01_Hinto.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Hinto_Click());
        GamePlayButton_Nazotoki01_Hinto_Return.GetComponent<Button>().onClick.AddListener(() => OnGamePlayButton_Nazotoki01_Hinto_Return_Click());
        // Move Scene's Position

        ScenePos_Default = new Vector3(MoveScene_Default.GetComponent<Transform>().position.x,
                                       MoveScene_Default.GetComponent<Transform>().position.y,
                                      -10.0f);
        ScenePos_Nazotoki_1 = new Vector3(MoveScene_Nazotoki_1.GetComponent<Transform>().position.x,
                                       MoveScene_Nazotoki_1.GetComponent<Transform>().position.y,
                                      -10.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ********  Change Scene Button Logic ***********
    // *********** Default *********
    // To Nazotoki_1
    public void OnChangeSceneButton_DefaultToNazotoki01_Click()
    {
        Debug.Log("11111");
        ChangeSceneButton_DefaultToNazotoki01.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_Nazotoki_1, MoveSpeed).OnComplete(() =>
        {
            Exploration03_MouseDetection.SetNowScene(Exploration_03_Scenes.Nazotoki_1);

            ChangeSceneButton_Nazotoki01ToDefault.SetActive(true);

            GamePlayButton_Nazotoki01_Ningyou.SetActive(true);
            GamePlayButton_Nazotoki01_Hinto.SetActive(true);

        }); ;
    }


    // *********** Nazotoki_1 *********
    // To Default
    public void OnChangeSceneButton_Nazotoki01ToDefault_Click()
    {
        ChangeSceneButton_Nazotoki01ToDefault.SetActive(false);

        GamePlayButton_Nazotoki01_Ningyou.SetActive(false);
        GamePlayButton_Nazotoki01_Hinto.SetActive(false);

        MainCamera.transform.DOMove(ScenePos_Default, MoveSpeed).OnComplete(() =>
        {
            Exploration03_MouseDetection.SetNowScene(Exploration_03_Scenes.Default);
            ChangeSceneButton_DefaultToNazotoki01.SetActive(true);

        }); ;
    }

    // ********  Game Play Button Logic ***********
    // ********* Nazotoki01 *************
    public void OnGamePlayButton_Nazotoki01_Ningyou_Click()
    {
        ChangeSceneButton_Nazotoki01ToDefault.SetActive(false);
        GamePlayButton_Nazotoki01_Hinto.SetActive(false);

        GamePlayButton_Nazotoki01_Ningyou_Return.SetActive(true);




    }
    public void OnGamePlayButton_Nazotoki01_Ningyou_Return_Click()
    {

    }
    public void OnGamePlayButton_Nazotoki01_Hinto_Click()
    {

    }
    public void OnGamePlayButton_Nazotoki01_Hinto_Return_Click()
    {

    }
}
