// 25.5.11. RI
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MouseDetection : MonoBehaviour
{

    // The camera of this scene
    //public GameObject SceneCamera;

    // Images that need to do mouse detectiion
    public GameObject[] MouseDetctionObjects_Default;
    public GameObject[] MouseDetctionObjects_Kyakuma;
    public GameObject[] MouseDetctionObjects_Shunou;
    public GameObject[] MouseDetctionObjects_Corridor;
    public GameObject[] MouseDetctionObjects_ParentsRoom;
    public GameObject[] MouseDetctionObjects_Kitchen;
    public GameObject[] MouseDetctionObjects_Libing;

    // Message prompt box
    public GameObject PromptBox;

    private Vector2 MiddlePos= new Vector2(Screen.width/2,Screen.height/2);
    private Vector2 MousePos;
    private Vector2 OffsetMousePos;
    private float Offset_X = 140;

    private Exploration_02_Scenes NowScene;
    //private float Offset_Y = 10;

    // Messages need to show
    private string[] Messages_Default = new string[3] {
        "階段を上がる",
        "リビングに行く",
        "客間に行く",
    };
    private string[] Messages_Kyakuma = new string[4] {
        "玄関に帰る",
        "左の襖を調べる",
        "右の襖を調べる" ,
        "メダルを拾う",
    };
    private string[] Messages_Shunou = new string[5] {
        "廊下に帰る",
        "机を調べる",
        "ノートを調べる",
        "引き出しを調べる",
        "錠を調べる",
    }; 
    private string[] Messages_Corridor = new string[4] {
        "収納部屋に行く",
        "夫婦部屋に行く",
        "階段を下りる",
        "ドアを調べる",
    }; 
    private string[] Messages_ParentsRoom = new string[3] {
        "廊下に帰る",
        "クローゼットを調べる",
        "メダルを拾う",
    }; 
    private string[] Messages_Kitchen = new string[1] {
        "リビングに帰る"
    };
    private string[] Messages_Libing = new string[7] {
        "玄関に帰る",
        "キッチンに行く",
        "時計を調べる",
        "懐中電灯を拾う",
        "ファーを調べる",
        "メダルを拾う",
        "メダルを拾う",


    };

    public void SetNowScene(Exploration_02_Scenes scene) { NowScene = scene; }
    void Start()
    {
        PromptBox.GetComponent<TextMeshProUGUI>().raycastTarget = false;
        PromptBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = (Vector2)Input.mousePosition;
        OffsetMousePos = new Vector2(MousePos.x + (MiddlePos.x - MousePos.x) / (Screen.width / 2) * Offset_X,
                                    MousePos.y);

        switch (NowScene)
        {
            case Exploration_02_Scenes.Default:
                if (MouseDetctionObjects_Default[0].activeSelf &&
                         RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Default[0].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Default[0];
                }
                else if (MouseDetctionObjects_Default[1].activeSelf &&
                         RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Default[1].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Default[1];
                }
                else if (MouseDetctionObjects_Default[2].activeSelf &&
                         RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Default[2].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Default[2];
                }
                else
                {
                    PromptBox.SetActive(false);
                }
                    break;

            case Exploration_02_Scenes.Kyakuma:
                if (MouseDetctionObjects_Kyakuma[0].activeSelf &&
                    RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Kyakuma[0].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Kyakuma[0];
                }
                else if (MouseDetctionObjects_Kyakuma[1].activeSelf &&
                         RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Kyakuma[1].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Kyakuma[1];
                }
                else if (MouseDetctionObjects_Kyakuma[2].activeSelf &&
                         RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Kyakuma[2].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Kyakuma[2];
                }
                else if (MouseDetctionObjects_Kyakuma[3].activeSelf &&
                       RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Kyakuma[3].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Kyakuma[3];
                }
                else
                {
                    PromptBox.SetActive(false);
                }
                break;

            case Exploration_02_Scenes.Shunou:
                if (MouseDetctionObjects_Shunou[0].activeSelf &&
                    RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Shunou[0].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Shunou[0];
                }
                else if (MouseDetctionObjects_Shunou[1].activeSelf &&
                         RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Shunou[1].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Shunou[1];
                }
                else if (MouseDetctionObjects_Shunou[2].activeSelf &&
                         RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Shunou[2].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Shunou[2];
                }
                else if (MouseDetctionObjects_Shunou[3].activeSelf &&
                         RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Shunou[3].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Shunou[3];
                }
                else if (MouseDetctionObjects_Shunou[4].activeSelf &&
                         RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Shunou[4].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Shunou[4];
                }
                else
                {
                    PromptBox.SetActive(false);
                }
                break;
            case Exploration_02_Scenes.Corridor:
                if (MouseDetctionObjects_Corridor[0].activeSelf &&
                    RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Corridor[0].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Corridor[0];
                }
                else if (MouseDetctionObjects_Corridor[1].activeSelf &&
                       RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Corridor[1].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Corridor[1];
                }
                else if (MouseDetctionObjects_Corridor[2].activeSelf &&
                        RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Corridor[2].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Corridor[2];
                }
                else if (MouseDetctionObjects_Corridor[3].activeSelf &&
                         RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Corridor[3].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Corridor[3];
                }
                else
                {
                    PromptBox.SetActive(false);
                }
                break;

            case Exploration_02_Scenes.ParentsRoom:
                if (MouseDetctionObjects_ParentsRoom[0].activeSelf &&
                    RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_ParentsRoom[0].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_ParentsRoom[0];
                }
                else if (MouseDetctionObjects_ParentsRoom[1].activeSelf &&
                        RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_ParentsRoom[1].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_ParentsRoom[1];
                }
                else if (MouseDetctionObjects_ParentsRoom[2].activeSelf &&
                       RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_ParentsRoom[2].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_ParentsRoom[2];
                }
                else
                {
                    PromptBox.SetActive(false);
                }
                break;

            case Exploration_02_Scenes.Kitchen:
                if (MouseDetctionObjects_Kitchen[0].activeSelf &&
                    RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Kitchen[0].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Kitchen[0];
                }
                else
                {
                    PromptBox.SetActive(false);
                }
                break;

            case Exploration_02_Scenes.Libing:
                if (MouseDetctionObjects_Libing[0].activeSelf&&
                    RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Libing[0].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Libing[0];
                }
                else if (MouseDetctionObjects_Libing[1].activeSelf && 
                    RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Libing[1].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Libing[1];
                }
                else if (MouseDetctionObjects_Libing[2].activeSelf &&
                RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Libing[2].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Libing[2];
                }
                else if (MouseDetctionObjects_Libing[3].activeSelf &&
              RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Libing[3].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Libing[3];
                }
                else if (MouseDetctionObjects_Libing[4].activeSelf &&
              RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Libing[4].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Libing[4];
                }
                else if (MouseDetctionObjects_Libing[5].activeSelf &&
              RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Libing[5].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Libing[5];
                }
                else if (MouseDetctionObjects_Libing[6].activeSelf &&
              RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Libing[6].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Libing[6];
                }
                else
                {
                    PromptBox.SetActive(false);
                }
                break;

           
            default:
                PromptBox.SetActive(false);
                break;
        }
    }
}
