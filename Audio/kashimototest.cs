using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kasimototest : MonoBehaviour
{
 public AudioManager audioManager;

    private void Start()
    {
        audioManager.PlayBGM(AudioManager.BGMNAME.MAINBGM);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            Debug.Log("MainBGM Ä¶");
            audioManager.PlayBGM(AudioManager.BGMNAME.MAINBGM);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Debug.Log("MainBGM â~");
            audioManager.StopBGM(AudioManager.BGMNAME.MAINBGM);
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            Debug.Log("Â«BGM Ä¶");
            audioManager.PlayBGM(AudioManager.BGMNAME.AMBIENTBGM);
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            Debug.Log("Â«BGM â~");
            audioManager.StopBGM(AudioManager.BGMNAME.AMBIENTBGM);
        }


        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            Debug.Log("øÊ¹SE Ä¶");
            audioManager.PlaySE(AudioManager.SENAME.EFFECTSE);
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            Debug.Log("øÊ¹SE â~");
            audioManager.StopSE(AudioManager.SENAME.EFFECTSE);
        }

        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            Debug.Log("ANVSE Ä¶");
            audioManager.PlaySE(AudioManager.SENAME.REACTIONSE);
        }
        if (Input.GetKeyUp(KeyCode.Alpha8))
        {
            Debug.Log("ANVSE â~");
            audioManager.StopSE(AudioManager.SENAME.REACTIONSE);
        }
    }

}
