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
    private Vector2 MousePos;

    // Messages need to show
    private string[] Messages = new string[6] {
        "階段を上がる", 
        "客間に行く", 
        "玄関に帰る",
        "左の襖を触る", 
        "右の襖を触る" ,
        "机を触る",
    };


    void Start()
    {
        PromptBox.GetComponent<TextMeshProUGUI>().raycastTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = Input.mousePosition;
        if (MouseDetctionObjects[0].activeSelf&& RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[0].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = MousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[0];
        }
        else if(MouseDetctionObjects[1].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[1].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = MousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[1];
        }
        else if (MouseDetctionObjects[2].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[2].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = MousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[2];
        }
        else if (MouseDetctionObjects[3].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[3].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = MousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[2];
        }
        else if (MouseDetctionObjects[4].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[4].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = MousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[3];
        }
        else if (MouseDetctionObjects[5].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[5].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = MousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[4];
        }
        else if (MouseDetctionObjects[6].activeSelf && RectTransformUtility.RectangleContainsScreenPoint(MouseDetctionObjects[6].GetComponent<RectTransform>(), MousePos))
        {
            PromptBox.SetActive(true);
            PromptBox.GetComponent<RectTransform>().position = MousePos;
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[5];
        }
        else
        {
            PromptBox.SetActive(false);
        }
    }

   
}
