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
    //private float Offset_Y = 10;

    // Messages need to show
    private string[] Messages_Default = new string[1] {
        "蔵内へ移動する",
    };
    private string[] Messages_Nazotoki01= new string[3] {
        "外に帰る",
        "人形を調べる",
        "壁画を調べる" ,
    };
   

    public void SetNowScene(Exploration_03_Scenes scene) { NowScene = scene; }
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
                else
                {
                    PromptBox.SetActive(false);
                }
                break;

            case Exploration_03_Scenes.Nazotoki_2:
                break;
          
            default:
                PromptBox.SetActive(false);
                break;
        }
    }
}
