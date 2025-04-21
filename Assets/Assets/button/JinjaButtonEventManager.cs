using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Fungus;

//神社场景下的所有道具枚举
 public enum PropList
  {
      EmagakeKey = 0, //钥匙
      None=114514,    //空物体
  }


public class JinjaButtonEventManager : MonoBehaviour
{
 
    // 钥匙等道具的交换按钮
    public GameObject[] PropButton;

    // 场景中的交互按钮，如石狮子，门等
    public GameObject[] Jinja_Button;

    // 石狮子、门等场景各自的退出按钮
    public GameObject[] ExitButton;

    public GameObject BagButton;
    public GameObject ChangeSceneButton;

    private bool canChoose = true;
    public GameObject BagManager;

    public Flowchart Mon_Flowchart;

    // 是否已使用钥匙
    private bool isUseKey = false;
    // 大门是否已被打开
    private bool isOpenTheDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Jinja_Button.Length; i++)
        {
            int index = i;
            Jinja_Button[i].GetComponent<Button>().onClick.AddListener(() => OnClick(index));
            ExitButton[i].GetComponent<Button>().onClick.AddListener(() => OnClickExit(index));
        }

        // 为key添加一个响应事件



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 检测鼠标左键点击
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == PropButton[0] && PropButton[0].activeSelf)
            {
                Debug.Log("key is click");
                OnClickKey();
            }
        }
    }
    private void OnClick(int index)
    {
        if (canChoose)
        {
            Jinja_Button[index].GetComponent<ImageToggle>().imageObject.SetActive(true);
            canChoose = false;
            ChangeSceneButton.GetComponent<Button>().interactable = false;
            BagButton.GetComponent<Button>().interactable = false;

            //当点击到门时，执行对应逻辑
            if(index== 1)
            {
                OnClickDoor();
            }
        }
    
    }


    private void OnClickExit(int index)
    {
        if (ExitButton[index].activeSelf)
        {
            Jinja_Button[index].GetComponent<ImageToggle>().imageObject.SetActive(false);
            ExitButton[index].GetComponent<HideObjectOnClick>().targetObject.SetActive(false);
            canChoose = true;

            ChangeSceneButton.GetComponent<Button>().interactable = true;
            BagButton.GetComponent<Button>().interactable = true;
          
        }
    }

    // 点击到钥匙时，将其置入背包，并使Emagake中的钥匙不可见
    private void OnClickKey()
    {
        BagManager.GetComponent<BagManager>().AddItemToBag((int)PropList.EmagakeKey);
        PropButton[0].SetActive(false);
    }

    //点击到门时，触发门的相关逻辑，并检测钥匙是否已被拾取以及使用
    private void OnClickDoor()
    {
        // 先判断钥匙否已被拾取
        if(PropButton[0].activeSelf)
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
    private void OnFungusMessageReceived(string message)
    {
        if (message == "SayClicked")
        {
            Debug.Log("Say 对话框的继续按钮被点击");
            // 你的回调逻辑
        }
    }


    // 当fungus对话框出现时
    public void OnSayStart()
    {
        Debug.Log("Say 开始：" );
        // 在事件结束前，不许退出按钮被点击
        ExitButton[1].GetComponent<Button>().interactable = false;
    }

    // 当点击yes后
    public void OnYesClick()
    {
        Debug.Log("Yes被点击：");

        //通过钥匙是否可见判断其是否已被拾取
        if (!PropButton[0].activeSelf)
        {
            // 此处进行使用钥匙后的处理
            Debug.Log("Use Key!");
            isUseKey = true;
            // 移除背包中的钥匙
            BagManager.GetComponent<BagManager>().RemoveItemInBag(PropList.EmagakeKey);

            Mon_Flowchart.ExecuteBlock("UseKey");
            isOpenTheDoor = true;
        }
        else
        {
        }

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


    }
    // 当点击进入下一个场景时
    public void OnNo01Click()
    {
        Debug.Log("No01被点击");

    }

    // 允许退出门场景
    public void CanExitMon()
    {
        ExitButton[1].GetComponent<Button>().interactable = true;
    }
}

