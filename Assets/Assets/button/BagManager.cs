using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    [Tooltip("最多保存 6 个格子的 Transform 列表")]
    public List<Transform> slots = new List<Transform>();  // 存储格子的 Transform

    //[Tooltip("最多保存 6 个坐标的列表")]
    //public List<Vector2> slotPositions = new List<Vector2>(6);  // 存储格子位置的列表

    /// <summary>
    /// 尝试往格子里添加物品，最多 6 个格子
    /// </summary>
    public bool AddItemToFirstEmptySlot(GameObject item)
    {
        foreach (Transform slot in slots)
        {
            if (slot.childCount == 0)  // 如果格子是空的
            {
                item.transform.SetParent(slot, false);  // 设置物品为该格子的子物体
                item.transform.localPosition = Vector3.zero;  // 重置物品在格子中的位置

                // 获取物品在格子中的位置（相对于背包）
                Vector2 slotPos = slot.localPosition;
                //AddSlot(slotPos);  // 添加该格子的坐标到列表
                return true;
            }
        }
        Debug.LogWarning("背包已满，无法添加物品。");
        return false;  // 背包已满
    }

    /// <summary>
    /// 尝试往坐标列表里添加一个坐标，最多 6 个
    /// </summary>
    //public void AddSlot(Vector2 pos)
    //{
    //    if (slotPositions.Count >= 6)
    //    {
    //        Debug.LogWarning("背包格子已满（6 个），无法再添加：" + pos);
    //        return;
    //    }

    //    slotPositions.Add(pos);  // 添加坐标
    //    Debug.Log($"已添加格子坐标：({pos.x}, {pos.y})，当前共 {slotPositions.Count} 个格子");
    //}
}
