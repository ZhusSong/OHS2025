using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour
{
    //格子的结构体
     struct Slots
    { 
        public Transform item;
        public bool haveOrNot;
    }

    Slots[] slots = new Slots[6];

    void Start()
    {
        for (int i=0;i<6;i++)
        {
            slots[i].item = GameObject.Find("Slots_1").GetComponent<Transform>();
            slots[i].haveOrNot = false;
        }
    }


    public void AddItemToBag()
    {

    }
    public void RemoveItemInBag(int index)
    {

    }
  
}
