using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Fungus;
using Unity.Burst.CompilerServices;
using UnityEngine.SceneManagement;

//神社场景下的所有道具枚举
public enum PropList
  {
    Ema = 0, //钥匙 
    Match =1, //火柴  
    EmaKey = 2, //绘马钥匙  
    Tenugui = 3, //Tenugui 
    NreTenugui = 4, // NreTenugui 
    Zinzyakey=5,
    None =114514,    //空物体
  }


public class JinjaButtonEventManager : MonoBehaviour
{
 
    // 钥匙等道具的交换按钮
    public GameObject[] PropButton;

    // 神社大场景中的交互按钮，如石狮子，门等
    public GameObject[] Jinja_Button;

    // 小场景中的交互按钮，如石狮子，门等
    public GameObject[] Scene_Button;

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

    private int EmagakeClickNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        // 为大场景中的可交互物体添加响应事件
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
        if (Input.GetMouseButtonDown(0)) // 检测鼠标左键点击
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            OnPropClick(hit);
            OnSceneClick(hit);
        }
      
    }

  
    // 点击到交互的小场景时
    private void OnSceneClick(RaycastHit2D hit)
    {
        // 点击到绘马牌子时
        if (hit.collider != null && hit.collider.gameObject == Scene_Button[0] && Scene_Button[0].activeSelf)
        {
            Debug.Log("Ema Scene is click");
            // 当点击到绘马牌子时，触发事件
            if (EmagakeClickNumber == 0)
            {
               ExitButton[0].GetComponent<HideObjectOnClick>().targetObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Yang/Exploration01_ Kagianaemagake");
               EmagakeClickNumber += 1;
            }
            else if (BagManager.GetComponent<BagManager>().FindProp(PropList.EmaKey))
            {
                ExitButton[0].GetComponent<HideObjectOnClick>().targetObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Yang/Exploration01_ Openemagake");
                PropButton[0].SetActive(true);
                Scene_Button[0].GetComponent<BoxCollider2D>().isTrigger = false;
                BagManager.GetComponent<BagManager>().RemoveItemInBag(PropList.EmaKey);
            }
            else
            {
                // 若没有钥匙，触发对应逻辑

            }
        }

        // 当点击到水井时
        if (hit.collider != null && hit.collider.gameObject == Scene_Button[1] && Scene_Button[1].activeSelf)
        {
            if(BagManager.GetComponent<BagManager>().FindProp(PropList.NreTenugui))
            {
                Scene_Button[1].SetActive(false);
            }
            if (BagManager.GetComponent<BagManager>().FindProp(PropList.Tenugui))
            {
                BagManager.GetComponent<BagManager>().RemoveItemInBag(PropList.Tenugui);
                PropButton[4].SetActive(true);
            }
        }

        // 当点击到石狮子时
        if (hit.collider != null && hit.collider.gameObject == Scene_Button[2] && Scene_Button[2].activeSelf)
        {
            if (BagManager.GetComponent<BagManager>().FindProp(PropList.NreTenugui))
            {
                if (BagManager.GetComponent<BagManager>().FindProp(PropList.NreTenugui))
                {
                    ExitButton[2].GetComponent<HideObjectOnClick>().targetObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Yang/Exploration01_Komainu");
                    BagManager.GetComponent<BagManager>().RemoveItemInBag(PropList.NreTenugui);
                }
            }
            
        }
    }
    // 点击到交互的道具时
    private void OnPropClick(RaycastHit2D hit)
    {
        // 判断道具拾取
        if (hit.collider != null && hit.collider.gameObject == PropButton[0] && PropButton[0].activeSelf)
        {
            Debug.Log("key is click");
            OnClickKey();
        }
        if (hit.collider != null && hit.collider.gameObject == PropButton[1] && PropButton[1].activeSelf)
        {
            Debug.Log("match is click");
            OnClickMatch();
        }
        if (hit.collider != null && hit.collider.gameObject == PropButton[2] && PropButton[2].activeSelf)
        {
            Debug.Log("EmaKey is click");
            OnClickEmaKey();
        }
        if (hit.collider != null && hit.collider.gameObject == PropButton[3] && PropButton[3].activeSelf)
        {
            Debug.Log("Tenugui is click");
            OnClickTenugui();
        }
        if (hit.collider != null && hit.collider.gameObject == PropButton[4] && PropButton[4].activeSelf)
        {
            Debug.Log("Nretenugi is click");
            OnClickNretenugi();
        }
        if (hit.collider != null && hit.collider.gameObject == PropButton[5] && PropButton[5].activeSelf)
        {
            Debug.Log("Zinzyakey is click");
            OnClickZinzyakey();
        }
    }
    public void SetCanClickOrNot(bool can)
    {
        canChoose = can;
    }
    private void OnClick(int index)
    {
        if (canChoose)
        {
            // 先进行是否可进行鸟居交互的判断
            if(index==5)
            {
                if (!BagManager.GetComponent<BagManager>().FindProp(PropList.Ema))
                {
                    Jinja_Button[5].GetComponent<Button>().interactable = false;
                    return;
                }
                else
                {
                    Jinja_Button[5].GetComponent<Button>().interactable = true;
                }
            }

            Jinja_Button[index].GetComponent<ImageToggle>().imageObject.SetActive(true);
            canChoose = false;
            ChangeSceneButton.GetComponent<Button>().interactable = false;
            BagButton.GetComponent<Button>().interactable = false;

            //当点击到绘马牌子时，执行对应逻辑
            if (index == 0)
            {
                //OnClickEmagake();
            }
            //当点击到门时，执行对应逻辑
            if (index== 1)
            {
                OnClickDoor();
            }
            //当点击到石狮子时，执行对应逻辑
            if (index == 2)
            {
                //OnClickIshinu();
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

    // 点击到绘马时，将其置入背包
    private void OnClickKey()
    {
        BagManager.GetComponent<BagManager>().AddItemToBag((int)PropList.Ema);
        PropButton[0].SetActive(false);
    }
    private void OnClickZinzyakey()
    {
        BagManager.GetComponent<BagManager>().AddItemToBag((int)PropList.Zinzyakey);
        PropButton[5].SetActive(false);
    }
    // 当点击到火柴时，切换灯笼贴图，出现绘马钥匙
    private void OnClickMatch()
    {
        ExitButton[3].GetComponent<HideObjectOnClick>().targetObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Yang/Exploration01_Tourouhi");
        PropButton[1].SetActive(false);
        PropButton[2].SetActive(true);
    }

    // 当点击到绘马钥匙时，将其添加到背包
    private void OnClickEmaKey()
    {
        BagManager.GetComponent<BagManager>().AddItemToBag((int)PropList.EmaKey);
        PropButton[2].SetActive(false);
    }

    //点击到门时，触发门的相关逻辑，并检测钥匙是否已被拾取以及使用
    private void OnClickDoor()
    {
        // 先判断是否拥有钥匙
        if(!BagManager.GetComponent<BagManager>().FindProp(PropList.Zinzyakey))
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

    //// 点击到石狮子时，判断是否持有Nretenugui，若拥有则更改贴图
    //private void OnClickIshinu()
    //{
     
    //}

    //// 点击到绘马牌子时，判断是否持有Emakey，若拥有则更改贴图为打开状态
    //private void OnClickEmagake()
    //{

    //}
    // 当点击到tenugi时
    private void OnClickTenugui()
    {
        //BagManager.GetComponent<BagManager>().AddItemToBag((int)PropList.Tenugui);
        BagManager.GetComponent<BagManager>().AddItemToBag((int)PropList.Tenugui);
        PropButton[3].SetActive(false);
    }

    // 当点击到Nretenugi时
    private void OnClickNretenugi()
    {
        BagManager.GetComponent<BagManager>().AddItemToBag((int)PropList.NreTenugui);
        PropButton[4].SetActive(false);
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
            BagManager.GetComponent<BagManager>().RemoveItemInBag(PropList.Ema);
            // 更换门贴图
            ExitButton[1].GetComponent<HideObjectOnClick>().targetObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Yang/open gate");

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
        SceneManager.LoadScene("StoryScene02");

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

