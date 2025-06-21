using Fungus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class KinkoMinigame : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform clockDial;       
    public float returnSpeed = 100f;

    public GameObject Exploration03_Manager;
    private Exploration03_Button_Manager Ex03_Manager;
    private Vector2 centerScreenPos;
    private float lastAngle;
    private float totalRotation = 0f;
    private bool isReturning = false;

    public GameObject[] GamePlayButton_Nazotoki01_KinkoNumber;
    private int[] KinkoNumber = new int[4] { 0, 0, 0, 0 };

    void Start()
    {
        if (clockDial == null)
            clockDial = this.GetComponent<RectTransform>();

        Ex03_Manager = Exploration03_Manager.GetComponent<Exploration03_Button_Manager>();

        centerScreenPos = RectTransformUtility.WorldToScreenPoint(null, clockDial.position);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isReturning) return;
        
        centerScreenPos = RectTransformUtility.WorldToScreenPoint(null, clockDial.position);
        lastAngle = GetMouseAngle(eventData.position);
      
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isReturning) return;
        float currentAngle = GetMouseAngle(eventData.position);
        float deltaAngle = Mathf.DeltaAngle(lastAngle, currentAngle);

        totalRotation += deltaAngle;
        lastAngle = currentAngle;

        clockDial.rotation = Quaternion.Euler(0f, 0f, totalRotation);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isReturning) return; 

        int topNumber = GetCurrentTopNumber(totalRotation);

        CheckNumber(topNumber);

        isReturning = true;
    }

    void Update()
    {
        if (isReturning)
        {
            float currentZ = clockDial.eulerAngles.z;
            float delta = Mathf.DeltaAngle(currentZ, 0f);
            float step = returnSpeed * Time.deltaTime;

            if (Mathf.Abs(delta) < 0.5f)
            {
                clockDial.rotation = Quaternion.identity;
                totalRotation = 0f;
                isReturning = false;
            }
            else
            {
                float newZ = currentZ + Mathf.Clamp(delta, -step, step);
                clockDial.rotation = Quaternion.Euler(0f, 0f, newZ);
            }
        }
    }

    private float GetMouseAngle(Vector2 mousePos)
    {
        Vector2 dir = mousePos - centerScreenPos;
        return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }

    private int GetCurrentTopNumber(float rotationZ)
    {
        float normalizedAngle = -rotationZ % 360f;
        if (normalizedAngle < 0)
            normalizedAngle += 360f;

        int number = Mathf.RoundToInt(normalizedAngle / 30f);
        number = 12 - number;
        if (number <= 0)
            number += 12;

        return number;
    }

    private void CheckNumber(int number)
    {
        if (KinkoNumber[0] != 2)
        {
            if (number == 2)
            {
                KinkoNumber[0] = 2;
                GamePlayButton_Nazotoki01_KinkoNumber[0].GetComponentInChildren<TextMeshProUGUI>().text = "2";
            }
        }
        else 
        if (KinkoNumber[1] != 8)
        {
            if (number == 8)
            {
                KinkoNumber[1] = 8;
                GamePlayButton_Nazotoki01_KinkoNumber[1].GetComponentInChildren<TextMeshProUGUI>().text = "8";
            }
        }
        else 
        if (KinkoNumber[2] != 0)
        {
            if (number == 0)
            {
                KinkoNumber[2] = 0;
                GamePlayButton_Nazotoki01_KinkoNumber[2].GetComponentInChildren<TextMeshProUGUI>().text = "0";
            }
        }
        else 
        if (KinkoNumber[3] != 2)
        {
            if (number == 2)
            {
                KinkoNumber[3] = 2;
                GamePlayButton_Nazotoki01_KinkoNumber[3].GetComponentInChildren<TextMeshProUGUI>().text = "2";
            }
        }
        else
        {
        }
        if(KinkoNumber[0]== 2&& KinkoNumber[1] == 8
            && KinkoNumber[2] == 0&& KinkoNumber[3] == 2)
        {
            Ex03_Manager.KinkoMinigameSuccess();
        }


    }
}
