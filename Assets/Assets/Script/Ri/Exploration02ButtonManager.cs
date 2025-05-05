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
    public GameObject GamePlayButton_Desk_Return;

    [Header("ChangeScene")]
    public GameObject ChangeScene_Kyakuma;
    public GameObject ChangeScene_Shunou;
    public GameObject ChangeScene_Default;


    [Header("GamePlayScene")]
    public GameObject GamePlayScene_Desk;

    [Header("Items")]
    public GameObject Items_Medal;
    private bool GetMedal = false;

    public float MoveSpeed = 2.0f;

    private Vector3 ScenePos_Default;
    private Vector3 ScenePos_Kyakuma;
    private Vector3 ScenePos_Shunou;

    private AudioManager Exploration_AudioManager;


    // Start is called before the first frame update
    void Start()
    {
        Exploration_AudioManager = this.GetComponent<AudioManager>();

        ChangeSceneButton_Kyakuma.GetComponent<Button>().onClick.AddListener(() => OnButtonKyakumaClick());
        ChangeSceneButton_Shunou.GetComponent<Button>().onClick.AddListener(() => OnButtonShunouClick());
        ChangeSceneButton_KyakumaToDefault.GetComponent<Button>().onClick.AddListener(() => OnButtonKyakumaToDefaultClick());
        ChangeSceneButton_ShunouToDefault.GetComponent<Button>().onClick.AddListener(() => OnButtonShunouToDefaultClick());

        GamePlayButton_LeftFusuma.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonFusumaClick(true));
        GamePlayButton_RightFusuma.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonFusumaClick(false));

        GamePlayButton_Desk.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDeskClick());
        GamePlayButton_Desk_Return.GetComponent<Button>().onClick.AddListener(() => OnGameplayButtonDeskReturnClick());

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
        Debug.Log("01");
        Exploration_AudioManager.Se02Play();

        ChangeSceneButton_Kyakuma.SetActive(false);
        ChangeSceneButton_Shunou.SetActive(false);
        MainCamera.transform.DOMove(ScenePos_Kyakuma, MoveSpeed).OnComplete(() =>
        {
            ChangeSceneButton_KyakumaToDefault.SetActive(true);
            if(!GetMedal)
            {
                GamePlayButton_LeftFusuma.SetActive(true);
                GamePlayButton_RightFusuma.SetActive(true);
            }
        }); ;
    }


    public void OnButtonShunouClick()
    {
        Debug.Log("02");
        Exploration_AudioManager.Se02Play();

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
        Debug.Log("03");
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
        Debug.Log("04");
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
        if(leftOrRight)
        {
            LeftFusumaClickCount += 1;
            if(LeftFusumaClickCount>=4)
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

        if (LeftFusumaClickCount==4&&RightFusumaClickCount==2)
        {
            ChangeScene_Kyakuma.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("RI/Exploration02_Kyakuma_Door_Open");
            Items_Medal.SetActive(true);
        }
    }
    public void OnGameplayButtonDeskReturnClick()
    {
        GamePlayButton_Desk.SetActive(true);
        ChangeSceneButton_ShunouToDefault.SetActive(true);

        GamePlayScene_Desk.SetActive(false);
        GamePlayButton_Desk_Return.SetActive(false);
    }

    public void OnGameplayButtonDeskClick()
    {
        GamePlayButton_Desk.SetActive(false);
        ChangeSceneButton_ShunouToDefault.SetActive(false);

        GamePlayScene_Desk.SetActive(true);
        GamePlayButton_Desk_Return.SetActive(true);
    }

}
