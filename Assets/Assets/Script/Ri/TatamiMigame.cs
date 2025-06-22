using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TatamiMigame : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform targetArea;
    [SerializeField] private float snapDistance = 50f; 
    private Vector2 originalPosition;

    public GameObject EX03_Manager;
    private Exploration03_Button_Manager EX03_Manager_Script;

    private void Start()
    {
        originalPosition = GetComponent<RectTransform>().anchoredPosition;
        EX03_Manager_Script = EX03_Manager.GetComponent<Exploration03_Button_Manager>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPoint);

        GetComponent<RectTransform>().anchoredPosition = localPoint;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float distance = Vector2.Distance(
            GetComponent<RectTransform>().anchoredPosition,
            targetArea.anchoredPosition);

        if (distance <= snapDistance)
        {
            GetComponent<RectTransform>().anchoredPosition = targetArea.anchoredPosition;
            EX03_Manager_Script.GetTatamiNingyouSuccessName(transform.name);
        }
        else
        {
            // 不在目标区域，返回原位
            GetComponent<RectTransform>().anchoredPosition = originalPosition;
        }
    }
}