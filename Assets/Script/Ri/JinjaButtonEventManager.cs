using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JinjaButtonEventManager : MonoBehaviour
{
    public GameObject[] Jinja_Button;
    public GameObject[] ExitButton;

    private bool canChoose = true;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Jinja_Button.Length; i++)
        {
            int index = i;
            Jinja_Button[i].GetComponent<Button>().onClick.AddListener(() => OnClick(index));
            ExitButton[i].GetComponent<Button>().onClick.AddListener(() => OnClickExit(index));
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnClick(int index)
    {
        if (canChoose)
        {
            Jinja_Button[index].GetComponent<ImageToggle>().imageObject.SetActive(true);
            canChoose = false;
              
        }
    
    }
    private void OnClickExit(int index)
    {
        if (ExitButton[index].GetComponent<HideObjectOnClick>().targetObject != null && 
            ExitButton[index].GetComponent<HideObjectOnClick>().targetObject.activeSelf)
        {
            Jinja_Button[index].GetComponent<ImageToggle>().imageObject.SetActive(false);
            ExitButton[index].GetComponent<HideObjectOnClick>().targetObject.SetActive(false);
            canChoose = true;
            Debug.Log("目标物体"+ ExitButton[index].name+"已隐藏");
        }
    }
}
