using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Fungus;
using Unity.Burst.CompilerServices;
using UnityEngine.SceneManagement;

//神社场景下的所有道具枚举
public enum PropList
  {
    Ema = 0, //钥匙 
    Match =1, //火柴  
    EmaKey = 2, //绘马钥匙  
    Tenugui = 3, //Tenugui 
    NreTenugui = 4, // NreTenugui 
    Zinzyakey=5,
    None =114514,    //空物体
  }
enum SceneButtons
{
    Temizuya=0,
    Ishinu=1,
    Emagake=2,
    Torii=3,
    Tourou=4,
    Door=5,
}

public class JinjaButtonEventManager : MonoBehaviour
{
    //******************** GamePlayButtons ********************
    // Temizuya 
    [Header("Temizuya")]
    public GameObject GameplayButton_Temizuya;
    public GameObject GameplayButton_Temizuya_Close;
    public GameObject GameplayButton_Temizuya_Tenugui;
    public GameObject GameplayButton_Temizuya_Mizu;
    public GameObject GameplayButton_Temizuya_Nretenugi;

    private bool isGetTenugui=false;
    private bool isGetNretenugi = false;
    private bool isUseMizu = false;

    // Ishinu
    [Header("Ishinu")]
    public GameObject GameplayButton_Ishinu;
    public GameObject GameplayButton_Ishinu_Close;
    public GameObject GameplayButton_Ishinu_Clean;
    public GameObject GameplayButton_Ishinu_Match;
    private bool isClean = false;
    private bool isGetMatch = false;
    // Tourou
    [Header("Tourou")]
    public GameObject GameplayButton_Tourou;
    public GameObject GameplayButton_Tourou_Close;
    public GameObject GameplayButton_Tourou_Emakey;
    public GameObject GameplayButton_Tourou_UseMatch;
    private bool isGetEmakey = false;
    private bool isUseMatch = false;

    // Emagake
    [Header("Emagake")]
    public GameObject GameplayButton_Emagake;
    public GameObject GameplayButton_Emagake_Close;
    public GameObject GameplayButton_Emagake_Open;
    public GameObject GameplayButton_Emagake_UseKey;
    public GameObject GameplayButton_Emagake_EmagakeKey;
    private bool isOpen = false;
    private bool isUseEmaKey = false;
    private bool isGetEma=false;

    // Torii
    [Header("Torii")]
    public GameObject GameplayButton_Torii;
    public GameObject GameplayButton_Torii_Close;
    public GameObject GameplayButton_Torii_DoorKey;
    private bool isGetDoorKey;

    // Door
    [Header("Door")]
    public GameObject GameplayButton_Door;
    public GameObject GameplayButton_Door_Close;

    public GameObject ReturnToSelectScene;

    //**************** GamePlayScenes ********************
    [Header("TemizuyaScene")]
    public GameObject GameplayScene_Temizuya;
    [Header("IshinuScene")]
    public GameObject GameplayScene_Ishinu;
    [Header("TourouScene")]
    public GameObject GameplayScene_Tourou; 
    [Header("EmagakeScene")]
    public GameObject GameplayScene_Emagake;


    // 钥匙等道具的交换按钮
    //public GameObject[] PropButton;

    //// 神社大场景中的交互按钮，如石狮子，门等
    //public GameObject[] Jinja_Button;

    //// 小场景中的交互按钮，如石狮子，门等
    //public GameObject[] Scene_Button;

    //// 石狮子、门等场景各自的退出按钮
    //public GameObject[] ExitButton;

    [Header("SEs")]
    public AudioClip[] Exploration01_SE;


    public GameObject ChangeSceneButton;
    public AudioManager AudioManager;
    public MouseDetection Exploration01_MouseDetection ;

    public Flowchart Mon_Flowchart;

    // 是否已使用钥匙
    private bool isUseKey = false;
    private bool isHaveDoorKey = false;
    // 大门是否已被打开
    private bool isOpenTheDoor = false;

    private bool isTorii = false;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager = this.GetComponent<AudioManager>();
        Exploration01_MouseDetection = this.GetComponent<MouseDetection>();
        // 为大场景中的可交互物体添加响应事件
        // ******* Temizuya *********
        GameplayButton_Temizuya.GetComponent<Button>().onClick.AddListener(()=>GamePlayButton_Temizuya_OnClick());
        GameplayButton_Temizuya_Close.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Temizuya_Return_OnClick());
        GameplayButton_Temizuya_Tenugui.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Temizuya_Tenugui_OnClick());
        GameplayButton_Temizuya_Mizu.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Temizuya_Mizu_OnClick());
        GameplayButton_Temizuya_Nretenugi.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Temizuya_NreTenugui_OnClick());

        // ********** Ishinu **********
        GameplayButton_Ishinu.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Ishinu_OnClick());
        GameplayButton_Ishinu_Close.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Ishinu_Close_OnClick());
        GameplayButton_Ishinu_Clean.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Ishinu_Clean_OnClick());
        GameplayButton_Ishinu_Match.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Ishinu_Match_OnClick());

        // ********** Tourou **********
        GameplayButton_Tourou.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Tourou_OnClick());
        GameplayButton_Tourou_Close.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Tourou_Close_OnClick());
        GameplayButton_Tourou_UseMatch.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Tourou_UseMatch_OnClick());
        GameplayButton_Tourou_Emakey.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Tourou_Emakey_OnClick());

        // ********** Emagake ************
        GameplayButton_Emagake.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Emagake_OnClick());
        GameplayButton_Emagake_Close.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Emagake_Close_OnClick());
        GameplayButton_Emagake_Open.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Emagake_Open_OnClick());
        GameplayButton_Emagake_EmagakeKey.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Emagake_EmagakeKey_OnClick());
        GameplayButton_Emagake_UseKey.GetComponent<Button>().onClick.AddListener(() => GamePlayButton_Emagake_UseKey_OnClick());

        // ********** Torii ************



    }

    // Update is called once per frame
    void Update()
    {
       
    }
  
    private void SetSceneButtonsClick(SceneButtons thisButton)
    {
        switch (thisButton)
        {
            case SceneButtons.Temizuya:
                GameplayButton_Temizuya_Close.SetActive(true);
                GameplayScene_Temizuya.SetActive(true);

                if(!isGetTenugui)
                    GameplayButton_Temizuya_Tenugui.SetActive(true);
                else if(!isUseMizu)
                    GameplayButton_Temizuya_Mizu.SetActive(true);
                else if(!isGetNretenugi)
                    GameplayButton_Temizuya_Nretenugi.SetActive(true);

                GameplayButton_Temizuya.SetActive(false);
                GameplayButton_Ishinu.SetActive(false);
                GameplayButton_Emagake.SetActive(false);
                GameplayButton_Torii.SetActive(false);
                GameplayButton_Tourou.SetActive(false);
                GameplayButton_Door.SetActive(false);
                break;
            case SceneButtons.Ishinu:
                GameplayButton_Ishinu_Close.SetActive(true);
                GameplayScene_Ishinu.SetActive(true);
                if(isGetNretenugi)
                {
                    if (!isClean)
                        GameplayButton_Ishinu_Clean.SetActive(true);
                    else if (!isGetMatch)
                        GameplayButton_Ishinu_Match.SetActive(true);
                }
                GameplayButton_Temizuya.SetActive(false);
                GameplayButton_Ishinu.SetActive(false);
                GameplayButton_Emagake.SetActive(false);
                GameplayButton_Torii.SetActive(false);
                GameplayButton_Tourou.SetActive(false);
                GameplayButton_Door.SetActive(false);
                break;
            case SceneButtons.Emagake:
                GameplayButton_Emagake_Close.SetActive(true);
                GameplayScene_Emagake.SetActive(true);
                if (!isOpen)
                    GameplayButton_Emagake_Open.SetActive(true);
                else if(isGetEmakey)
                {
                     if (!isUseEmaKey)
                        GameplayButton_Emagake_UseKey.SetActive(true);
                    else if (!isGetEma)
                        GameplayButton_Emagake_EmagakeKey.SetActive(true);
                }

                GameplayButton_Temizuya.SetActive(false);
                GameplayButton_Ishinu.SetActive(false);
                GameplayButton_Emagake.SetActive(false);
                GameplayButton_Torii.SetActive(false);
                GameplayButton_Tourou.SetActive(false);
                GameplayButton_Door.SetActive(false);
                break;
            case SceneButtons.Torii:
                GameplayButton_Torii_Close.SetActive(true);

                GameplayButton_Temizuya.SetActive(false);
                GameplayButton_Ishinu.SetActive(false);
                GameplayButton_Emagake.SetActive(false);
                GameplayButton_Torii.SetActive(false);
                GameplayButton_Tourou.SetActive(false);
                GameplayButton_Door.SetActive(false);
                break;
            case SceneButtons.Tourou:
                GameplayButton_Tourou_Close.SetActive(true);
                GameplayScene_Tourou.SetActive(true);
                if (isGetMatch)
                {
                    if (!isUseMatch)
                        GameplayButton_Tourou_UseMatch.SetActive(true);
                    else if (!isGetEmakey)
                        GameplayButton_Tourou_Emakey.SetActive(true);
                }

                GameplayButton_Temizuya.SetActive(false);
                GameplayButton_Ishinu.SetActive(false);
                GameplayButton_Emagake.SetActive(false);
                GameplayButton_Torii.SetActive(false);
                GameplayButton_Tourou.SetActive(false);
                GameplayButton_Door.SetActive(false);
                break;
            case SceneButtons.Door:
                GameplayButton_Door_Close.SetActive(true);

                GameplayButton_Temizuya.SetActive(false);
                GameplayButton_Ishinu.SetActive(false);
                GameplayButton_Emagake.SetActive(false);
                GameplayButton_Torii.SetActive(false);
                GameplayButton_Tourou.SetActive(false);
                GameplayButton_Door.SetActive(false);
                break;

        }
    }
    private void SetSceneButtonsCloseClick(SceneButtons thisButton)
    {
        switch (thisButton)
        {
            case SceneButtons.Temizuya:
                GameplayButton_Temizuya_Close.SetActive(false);
                GameplayButton_Temizuya_Mizu.SetActive(false);
                GameplayButton_Temizuya_Tenugui.SetActive(false);
                GameplayButton_Temizuya_Nretenugi.SetActive(false);

                GameplayScene_Temizuya.SetActive(false);

                GameplayButton_Temizuya.SetActive(true);
                GameplayButton_Ishinu.SetActive(true);
                GameplayButton_Emagake.SetActive(true);
                GameplayButton_Torii.SetActive(true);
                GameplayButton_Tourou.SetActive(true);
                GameplayButton_Door.SetActive(true);
                break;
            case SceneButtons.Ishinu:
                GameplayScene_Ishinu.SetActive(false);

                GameplayButton_Ishinu_Close.SetActive(false);
                GameplayButton_Ishinu_Clean.SetActive(false);
                GameplayButton_Ishinu_Match.SetActive(false);

                GameplayButton_Temizuya.SetActive(true);
                GameplayButton_Ishinu.SetActive(true);
                GameplayButton_Emagake.SetActive(true);
                GameplayButton_Torii.SetActive(true);
                GameplayButton_Tourou.SetActive(true);
                GameplayButton_Door.SetActive(true);
                break;
            case SceneButtons.Emagake:
                GameplayScene_Emagake.SetActive(false);

                GameplayButton_Emagake_Close.SetActive(false);
                GameplayButton_Emagake_EmagakeKey.SetActive(false);
                GameplayButton_Emagake_Open.SetActive(false);
                GameplayButton_Emagake_UseKey.SetActive(false);

                GameplayButton_Temizuya.SetActive(true);
                GameplayButton_Ishinu.SetActive(true);
                GameplayButton_Emagake.SetActive(true);
                GameplayButton_Torii.SetActive(true);
                GameplayButton_Tourou.SetActive(true);
                GameplayButton_Door.SetActive(true);
                break;
            case SceneButtons.Torii:
                GameplayButton_Torii_Close.SetActive(false);

                GameplayButton_Temizuya.SetActive(true);
                GameplayButton_Ishinu.SetActive(true);
                GameplayButton_Emagake.SetActive(true);
                GameplayButton_Torii.SetActive(true);
                GameplayButton_Tourou.SetActive(true);
                GameplayButton_Door.SetActive(true);
                break;
            case SceneButtons.Tourou:
                GameplayButton_Tourou_Close.SetActive(false);
                GameplayButton_Tourou_UseMatch.SetActive(false);
                GameplayButton_Tourou_Emakey.SetActive(false);

                GameplayScene_Tourou.SetActive(false);

                GameplayButton_Temizuya.SetActive(true);
                GameplayButton_Ishinu.SetActive(true);
                GameplayButton_Emagake.SetActive(true);
                GameplayButton_Torii.SetActive(true);
                GameplayButton_Tourou.SetActive(true);
                GameplayButton_Door.SetActive(true);
                break;
            case SceneButtons.Door:
                GameplayButton_Door_Close.SetActive(false);

                GameplayButton_Temizuya.SetActive(true);
                GameplayButton_Ishinu.SetActive(true);
                GameplayButton_Emagake.SetActive(true);
                GameplayButton_Torii.SetActive(true);
                GameplayButton_Tourou.SetActive(true);
                GameplayButton_Door.SetActive(true);
                break;
        }
        // Check Props and set scene buttons:
        if (isGetNretenugi)
            GameplayButton_Temizuya.SetActive(false);
        if(isGetMatch)
            GameplayButton_Ishinu.SetActive(false);
        if (isGetEmakey)
            GameplayButton_Tourou.SetActive(false);
        if (isGetEma)
            GameplayButton_Emagake.SetActive(false);

    }

    // ********** Temizuya ************
    public void GamePlayButton_Temizuya_OnClick()
    {
        SetSceneButtonsClick(SceneButtons.Temizuya);
    }

    public void GamePlayButton_Temizuya_Return_OnClick()
    {
        SetSceneButtonsCloseClick(SceneButtons.Temizuya);
    }
    public void GamePlayButton_Temizuya_Tenugui_OnClick()
    {
        //AudioManager.PlaySE_External(Exploration01_SE[0], 0.8f);
        isGetTenugui = true;
        GameplayButton_Temizuya_Tenugui.SetActive(false);
        GameplayButton_Temizuya_Mizu.SetActive(true);
    }
    public void GamePlayButton_Temizuya_Mizu_OnClick()
    {
        GameplayButton_Temizuya_Mizu.SetActive(false);
        GameplayButton_Temizuya_Nretenugi.SetActive(true);
        isUseMizu = true;
    }
    public void GamePlayButton_Temizuya_NreTenugui_OnClick()
    {
        GameplayButton_Temizuya_Nretenugi.SetActive(false);
        isGetNretenugi = true;
    }

    // ********* Ishinu *************
    public void GamePlayButton_Ishinu_OnClick()
    {
        SetSceneButtonsClick(SceneButtons.Ishinu);
    }
    public void GamePlayButton_Ishinu_Close_OnClick()
    {
        SetSceneButtonsCloseClick(SceneButtons.Ishinu);
    }
    public void GamePlayButton_Ishinu_Clean_OnClick()
    {
        GameplayScene_Ishinu.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Yang/Exploration01_Komainu");
        isClean= true;
        GameplayButton_Ishinu_Clean.SetActive(false);
        GameplayButton_Ishinu_Match.SetActive(true);
    }
    public void GamePlayButton_Ishinu_Match_OnClick()
    {
        //AudioManager.PlaySE_External(Exploration01_SE[0], 0.8f);
        GameplayButton_Ishinu_Match.SetActive(false);
        isGetMatch = true;
    }

    public void GamePlayButton_Tourou_OnClick()
    {
        SetSceneButtonsClick(SceneButtons.Tourou);
    }
    public void GamePlayButton_Tourou_Close_OnClick()
    {
        SetSceneButtonsCloseClick(SceneButtons.Tourou);
    }

    //************* Emagake ***************
    public void GamePlayButton_Tourou_Emakey_OnClick()
    {
        //AudioManager.PlaySE_External(Exploration01_SE[0], 0.8f);
        GameplayButton_Tourou_Emakey.SetActive(false);
        isGetEmakey = true;
    }
    public void GamePlayButton_Tourou_UseMatch_OnClick()
    {
        //AudioManager.PlaySE_External(Exploration01_SE[0], 0.8f);
        GameplayButton_Tourou_UseMatch.SetActive(false);

        GameplayButton_Tourou_Emakey.SetActive(true);
        isUseMatch = true;
    }

    // *********** Emagake ********************
    public void GamePlayButton_Emagake_OnClick()
    {
        SetSceneButtonsClick(SceneButtons.Emagake);
    }
    public void GamePlayButton_Emagake_Close_OnClick()
    {
        SetSceneButtonsCloseClick(SceneButtons.Emagake);
    }
    public void GamePlayButton_Emagake_Open_OnClick()
    {
        GameplayScene_Emagake.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Yang/Exploration01_ Kagianaemagake");
        GameplayButton_Emagake_Open.SetActive(false);
        if(isGetEmakey)
            GameplayButton_Emagake_UseKey.SetActive(true);
        isOpen = true;
    }

    public void GamePlayButton_Emagake_EmagakeKey_OnClick()
    {
        GameplayButton_Emagake_EmagakeKey.SetActive(false);
        isGetEma = true;
    }
    public void GamePlayButton_Emagake_UseKey_OnClick()
    {
        GameplayButton_Emagake_UseKey.SetActive(false);
        GameplayButton_Emagake_EmagakeKey.SetActive(true);
        GameplayScene_Emagake.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Yang/Exploration01_ Openemagake");
        isUseEmaKey = true;
    }

    //点击到门时，触发门的相关逻辑，并检测钥匙是否已被拾取以及使用
    private void OnClickDoor()
    {
        // 先判断是否拥有钥匙
        if(!isHaveDoorKey)
        {
            Mon_Flowchart.ExecuteBlock("DontHaveKey");
        }
        //若还没使用钥匙，则触发对话
        else if(!isUseKey)
        {
            Mon_Flowchart.ExecuteBlock("HaveKey");
        }
        else if(isOpenTheDoor)
        {
            Mon_Flowchart.ExecuteBlock("GotoNextScene");
        }
    }

    //// 点击到石狮子时，判断是否持有Nretenugui，若拥有则更改贴图
    //private void OnClickIshinu()
    //{
     
    //}

    //// 点击到绘马牌子时，判断是否持有Emakey，若拥有则更改贴图为打开状态
    //private void OnClickEmagake()
    //{

    //}
    // 当点击到tenugi时
    private void OnClickTenugui()
    {
        AudioManager.GetComponent<AudioManager>().Se01Play();
    }

    // 当点击到Nretenugi时
    private void OnClickNretenugi()
    {
      
        AudioManager.GetComponent<AudioManager>().Se01Play();
    }

    // 当fungus对话框出现时
    public void OnSayStart()
    {
     
    }

    // 当点击yes后
    public void OnYesClick()
    {

    
        
            Mon_Flowchart.ExecuteBlock("UseKey");
            isOpenTheDoor = true;
      

    }

    // 当点击no后
    public void OnNoClick()
    {
        Debug.Log("No被点击：");
    }

    // 当点击进入下一个场景时
    public void OnYes01Click()
    {
        Debug.Log("Yes01被点击");
        SceneManager.LoadScene("StoryScene02");

    }
    // 当点击进入下一个场景时
    public void OnNo01Click()
    {
        Debug.Log("No01被点击");

    }

    // 允许退出门场景
    public void CanExitMon()
    {
    }
}

