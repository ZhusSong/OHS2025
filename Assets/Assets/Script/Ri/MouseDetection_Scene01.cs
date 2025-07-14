using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MouseDetection_Scene01 : MonoBehaviour
{
    public GameObject[] MouseDetctionObjects_Temizuya;
    public GameObject[] MouseDetctionObjects_Ishinu;
    public GameObject[] MouseDetctionObjects_Emagake;
    public GameObject[] MouseDetctionObjects_Tourou;
    public GameObject[] MouseDetctionObjects_Torii;
    public GameObject[] MouseDetctionObjects_Door;
    public GameObject PromptBox; 
    
    private Vector2 MiddlePos = new Vector2(Screen.width / 2, Screen.height / 2);
    private Vector2 MousePos;
    private Vector2 OffsetMousePos;
    private float Offset_X = 140;

    private string[] Messages_Temizuya = new string[4] {
        "手水舎を調査する",
        "手拭いを拾う",
        "手拭いを水で濡らす",
        "濡れ手拭いを拾う",
    };
    private string[] Messages_Ishinu = new string[3] {
        "石獅子を調査する",
        "石獅子をきれいにする",
        "マッチを拾う",
    }; private string[] Messages_Emagake = new string[4] {
        "絵馬掛けを調査する",
        "絵馬掛けを開ける",
        "絵が掛けの鍵を使う",
        "絵馬を拾う",
    }; private string[] Messages_Tourou = new string[3] {
        "灯籠を調査する",
        "マッチで灯籠に火をつける",
        "絵が掛けの鍵を拾う",
    }; private string[] Messages_Torii = new string[2] {
        "鳥居を調査する",
        "門の鍵を拾う",
    }; private string[] Messages_Door = new string[1] {
        "門を調査する",
    };
    // Start is called before the first frame update
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

        if (MouseDetctionObjects_Temizuya[0].activeSelf &&
                       RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Temizuya[0].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Temizuya[0];
        }
        else if (MouseDetctionObjects_Temizuya[1].activeSelf &&
                      RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Temizuya[1].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Temizuya[1];
        }
        else if (MouseDetctionObjects_Temizuya[2].activeSelf &&
                       RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Temizuya[2].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Temizuya[2];
        }
        else if (MouseDetctionObjects_Temizuya[3].activeSelf &&
                       RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Temizuya[3].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Temizuya[3];
        }


        else if (MouseDetctionObjects_Ishinu[0].activeSelf &&
                       RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Ishinu[0].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Ishinu[0];
        }
        else if (MouseDetctionObjects_Ishinu[1].activeSelf &&
                       RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Ishinu[1].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Ishinu[1];
        }
        else if (MouseDetctionObjects_Ishinu[2].activeSelf &&
                       RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Ishinu[2].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Ishinu[2];
        }


        else if (MouseDetctionObjects_Emagake[0].activeSelf &&
                       RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Emagake[0].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Emagake[0];
        }
        else if (MouseDetctionObjects_Emagake[1].activeSelf &&
                       RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Emagake[1].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Emagake[1];
        }
        else if (MouseDetctionObjects_Emagake[2].activeSelf &&
                       RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Emagake[2].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Emagake[2];
        }
        else if (MouseDetctionObjects_Emagake[3].activeSelf &&
                       RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Emagake[3].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Emagake[3];
        }


        else if (MouseDetctionObjects_Tourou[0].activeSelf &&
                       RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Tourou[0].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Tourou[0];
        }
        else if (MouseDetctionObjects_Tourou[1].activeSelf &&
                       RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Tourou[1].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Tourou[1];
        }
        else if (MouseDetctionObjects_Tourou[2].activeSelf &&
                      RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Tourou[2].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Tourou[2];
        }

        else if (MouseDetctionObjects_Torii[0].activeSelf &&
                     RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Torii[0].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Torii[0];
        }
        else if (MouseDetctionObjects_Torii[1].activeSelf &&
                    RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Torii[1].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Torii[1];
        }

        else if (MouseDetctionObjects_Door[0].activeSelf &&
                   RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects_Door[0].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages_Door[0];
        }
        else
        {
            PromptBox.SetActive(false);
        }
    }
}
