using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Fungus;
using Unity.Burst.CompilerServices;

public class Exploration02ButtonManager : MonoBehaviour
{
    public GameObject ChangeButton_01;
    public GameObject ChangeButton_02;

    public GameObject SceneCamera;
    public GameObject ChangeScene_01;
    public GameObject ChangeScene_02;



    public float MoveSpeed=2.0f;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        ChangeButton_01.GetComponent<Button>().onClick.AddListener(() => OnButton01Click());
        ChangeButton_02.GetComponent<Button>().onClick.AddListener(() => OnButton02Click());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButton01Click()
    {
        Debug.Log("01");
        SceneCamera.transform.position = Vector3.SmoothDamp(SceneCamera.transform.position,
            ChangeScene_01.transform.position, ref velocity, 2f);

    }
    public void OnButton02Click()
    {
        Debug.Log("02");
        SceneCamera.transform.position = Vector3.SmoothDamp(SceneCamera.transform.position,
            ChangeScene_02.transform.position, ref velocity, 2f);

    }
}
