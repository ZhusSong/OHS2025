using Fungus;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;


public class BagManager : MonoBehaviour
{

    //格子的结构体
    public GameObject[] Slots;

    //在此处保管需要实例化显示的道具prefab,与枚举类以及JinjaButtonEventManager中的道具列表顺序相同
    public GameObject[] PropPrefabs;

    private bool[] IsEmpty=new bool[6] { true,true,true,true,true,true};

    // 已拥有的道具数组
    private PropList[] OwnedProps=new PropList[6] { PropList.None, PropList.None, PropList.None, 
                                                    PropList.None, PropList.None, PropList.None,};

    private PropList BagProp;

    void Start()
    {

    }


    public void AddItemToBag(int propIndex)
    {
      
        for (int i=0;i<6;i++)
        {
            if (IsEmpty[i])
            {
                IsEmpty[i]=false;

                OwnedProps[i] = (PropList)propIndex;

                GameObject PropObject = Instantiate(PropPrefabs[propIndex]);
                PropObject.transform.position = Slots[i].transform.position;
                PropObject.transform.SetParent(Slots[i].transform);
                break;

            }
        }
    }
    public bool FindProp(PropList thisProp)
    {
        for(int i=0;i<OwnedProps.Length;i++)
        {
            if (OwnedProps[i]== thisProp)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 根据传入的道具枚举删除背包中的对应道具
    /// </summary>
    /// <param name="thisProp">道具的枚举</param>
    public void RemoveItemInBag(PropList thisProp)
    {
        for (int i = 0; i < OwnedProps.Length; i++)
        {
            if (OwnedProps[i] == thisProp)
            {
                // 讲对应的拥有道具数组置于空，同时删除钥匙对象
                OwnedProps[i] = PropList.None;
                GameObject.Destroy(Slots[i].transform.GetChild(0).transform.gameObject);
                IsEmpty[i] = true;
            }

        }

    }
  
}
