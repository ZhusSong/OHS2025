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

    private string[] Messages= new string[1] {
        "蔵内へ移動する",
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
            PromptBox.GetComponent<TextMeshProUGUI>().text = Messages[0];
        }
    }
}
