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
            Debug.Log("MainBGM 再生");
            audioManager.PlayBGM(AudioManager.BGMNAME.MAINBGM);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Debug.Log("MainBGM 停止");
            audioManager.StopBGM(AudioManager.BGMNAME.MAINBGM);
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            Debug.Log("環境BGM 再生");
            audioManager.PlayBGM(AudioManager.BGMNAME.AMBIENTBGM);
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            Debug.Log("環境BGM 停止");
            audioManager.StopBGM(AudioManager.BGMNAME.AMBIENTBGM);
        }


        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            Debug.Log("効果音SE 再生");
            audioManager.PlaySE(AudioManager.SENAME.EFFECTSE);
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            Debug.Log("効果音SE 停止");
            audioManager.StopSE(AudioManager.SENAME.EFFECTSE);
        }

        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            Debug.Log("リアクションSE 再生");
            audioManager.PlaySE(AudioManager.SENAME.REACTIONSE);
        }
        if (Input.GetKeyUp(KeyCode.Alpha8))
        {
            Debug.Log("リアクションSE 停止");
            audioManager.StopSE(AudioManager.SENAME.REACTIONSE);
        }
    }

}
