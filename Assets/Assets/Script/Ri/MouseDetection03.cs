// 25.6.19. RI
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MouseDetection03 : MonoBehaviour
{

    // The camera of this scene
    //public GameObject SceneCamera;

    // Images that need to do mouse detectiion
    public GameObject[] MouseDetctionObjects_Default;
    public GameObject[] MouseDetctionObjects_Nazotoki_1;
    public GameObject[] MouseDetctionObjects_Nazotoki_2;

    // Message prompt box
    public GameObject PromptBox;

    private Vector2 MiddlePos = new Vector2(Screen.width / 2, Screen.height / 2);
    private Vector2 MousePos;
    private Vector2 OffsetMousePos;
    private float Offset_X = 140;

    private Exploration_03_Scenes NowScene;
    private bool ButudanSuccess = false;
    //private float Offset_Y = 10;

    // Messages need to show
    private string[] Messages_Default = new string[1] {
        "蔵内へ移動する",
    };
    private string[] Messages_Nazotoki01= new string[9] {
        "外に帰る",
        "人形を調べる",
        "壁画を調べる" ,
        "金庫のパネルを調べる",
        "壁画を調べる",
        "仏壇を調べる",
        "鍵を拾う",
        "古い金庫へ移動する",
        "白い懐紙を拾う",
    };
    private string[] Messages_Nazotoki02 = new string[4] {
        "蔵内に帰る",
        "畳を調べる",
        "壁画を調べる" ,
        "金庫を調べる",
    };

    public void SetNowScene(Exploration_03_Scenes scene) { NowScene = scene; }
    void Start()
    {
        PromptBox.transform.SetAsLastSibling();
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
            case Exploration_03_Scenes.Default:
                if (MouseDetctionObjects_Default[0].activeSelf &&
                         RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Default[0].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Default[0];
                }
                else
                {
                    PromptBox.SetActive(false);
                }
                break;

            case Exploration_03_Scenes.Nazotoki_1:

                if (MouseDetctionObjects_Nazotoki_1[0].activeSelf &&
                         RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Nazotoki_1[0].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Nazotoki01[0];
                }
                else if (MouseDetctionObjects_Nazotoki_1[1].activeSelf &&
                        RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Nazotoki_1[1].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Nazotoki01[1];
                }
               else if (MouseDetctionObjects_Nazotoki_1[2].activeSelf &&
                        RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Nazotoki_1[2].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Nazotoki01[2];
                }
                else if (MouseDetctionObjects_Nazotoki_1[3].activeSelf &&
                      RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Nazotoki_1[3].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Nazotoki01[3];
                }
                else if (MouseDetctionObjects_Nazotoki_1[4].activeSelf &&
                      RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Nazotoki_1[4].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Nazotoki01[4];
                }
                else if (MouseDetctionObjects_Nazotoki_1[5].activeSelf &&
                      RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Nazotoki_1[5].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    if(!ButudanSuccess)
                        PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Nazotoki01[5];
                    else
                        PromptBox.GetComponent<TextMeshProUGUI>().text = "光る仏壇を調べる";


                }
                else if (MouseDetctionObjects_Nazotoki_1[6].activeSelf &&
                    RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Nazotoki_1[6].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Nazotoki01[6];
                }
                else if (MouseDetctionObjects_Nazotoki_1[7].activeSelf &&
               RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Nazotoki_1[7].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Nazotoki01[7];
                }
                else if (MouseDetctionObjects_Nazotoki_1[8].activeSelf &&
             RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Nazotoki_1[8].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Nazotoki01[8];
                }
                else
                {
                    PromptBox.SetActive(false);
                }
                break;

            case Exploration_03_Scenes.Nazotoki_2:
                if (MouseDetctionObjects_Nazotoki_2[0].activeSelf &&
                         RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Nazotoki_2[0].GetComponent<RectTransform>(), MousePos))
                {
                    PromptBox.SetActive(true);
                    PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
                    PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Nazotoki02[0];
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

    public void GetButudanOpen()
    {
       ButudanSuccess = true;
    }
}
