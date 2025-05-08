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
    public GameObject[] MouseDetctionObjects;

    // Message prompt box
    public GameObject PromptBox;

    private Vector2 MiddlePos= new Vector2(Screen.width/2,Screen.height/2);
    private Vector2 MousePos;
    private Vector2 OffsetMousePos;
    private float Offset_X = 140;
    //private float Offset_Y = 10;

    // Messages need to show
    private string[] Messages = new string[15] {
        "階段を上がる", 
        "客間に行く", 
        "玄関に帰る",
        "廊下に帰る",
        "左の襖を調べる",
        "右の襖を調べる" ,
        "机を調べる",
        "ノートを調べる",
        "引き出しを調べる",
        "錠を調べる",
        "収納部屋に行く",
        "階段を下りる",
        "廊下に帰る",
        "夫婦部屋に行く",
        "ドアを調べる",
    };


    void Start()
    {
        PromptBox.GetComponent<TextMeshProUGUI>().raycastTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = (Vector2)Input.mousePosition;
        OffsetMousePos =new Vector2(MousePos.x+(MiddlePos.x- MousePos.x) / (Screen.width / 2) * Offset_X,
                                    MousePos.y);

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("Middle pos is "+MiddlePos+"Mosuse pos is " + MousePos);
        //}
        if (MouseDetctionObjects[0].activeSelf&& RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[0].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[0];
        }
        else if(MouseDetctionObjects[1].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[1].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[1];
        }
        else if (MouseDetctionObjects[2].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[2].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[2];
        }
        else if (MouseDetctionObjects[3].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[3].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[3];
        }
        else if (MouseDetctionObjects[4].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[4].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[4];
        }
        else if (MouseDetctionObjects[5].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[5].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[5];
        }
        else if (MouseDetctionObjects[6].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[6].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[6];
        }
        else if (MouseDetctionObjects[7].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[7].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[7];
        }
        else if (MouseDetctionObjects[8].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[8].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[8];
        }
        else if (MouseDetctionObjects[9].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[9].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[9];
        }
        else if (MouseDetctionObjects[10].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[10].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[10];
        }
        else if (MouseDetctionObjects[11].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[11].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[11];
        }
        else if (MouseDetctionObjects[12].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[12].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[12];
        }
        else if (MouseDetctionObjects[13].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[13].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[13];
        }
        else if (MouseDetctionObjects[14].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[14].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = OffsetMousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[14];
        }
        else
        {
            PromptBox.GetComponent<TextMeshProUGUI>().text =null;
            PromptBox.SetActive(false);
        }
    }

   
}
