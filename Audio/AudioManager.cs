using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //PlayBGM�EPlaySE������炵�����^�C�~���O�Ŏg���Ă�

    public List<AudioSource> BGMSourceList = new List< AudioSource > ();
    public List<AudioSource> SESourceList = new List<AudioSource>();

    public enum BGMNAME
    {
       //�ǉ�������GBM�����L��

        MAINBGM,
        AMBIENTBGM
    }
    public enum SENAME
    {
        //�ǉ�������SE�����L��

        EFFECTSE,
        REACTIONSE
    }

    public void PlayBGM(BGMNAME name)
    {
        int number = (int)name;
        if (BGMSourceList.Count <= number)
        {
            Debug.Log("�v�f�����I�[�o�[���܂���");
            return;
        }
        BGMSourceList[number].Play();

    }
    public void PlaySE(SENAME name)
    {
        int number = (int)name;
        if (SESourceList.Count <= number)
        {
            Debug.Log("�v�f�����I�[�o�[���܂���");
            return;
        }
        SESourceList[number].Play();

    }
    public void StopBGM(BGMNAME name)
    {
        int number = (int)name;
        if (BGMSourceList.Count <= number)
        {
            Debug.Log("�v�f�����I�[�o�[���܂���");
            return;
        }
        BGMSourceList[number].Stop();

    }
    public void StopSE(SENAME name)
    {
        int number = (int)name;
        if (SESourceList.Count <= number)
        {
            Debug.Log("�v�f�����I�[�o�[���܂���");
            return;
        }
        SESourceList[number].Stop();

    }

    #region TEST CODE
    /*
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource mainBGMSource;
    public AudioSource ambientBGMSource;
    public AudioSource effectSESource;
    public AudioSource reactionSESource;

    [Header("Audio Clips (���u��)")]
    public AudioClip[] mainBGMs;
    public AudioClip[] ambientBGMs;
    public AudioClip[] effectSEs;
    public AudioClip[] reactionSEs;

    public object BGMManager { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // ���̃��C��BGM���Đ�
        PlayMainBGM(0);
    }

    // ---- ���C��BGM ----
    public void PlayMainBGM(int index)
    {
        if (mainBGMs.Length > index)
        {
            mainBGMSource.clip = mainBGMs[index];
            mainBGMSource.loop = true;
            mainBGMSource.Play();
        }
    }

    public void StopMainBGM()
    {
        mainBGMSource.Stop();
    }
    //void OnTextChanged()
    //{
    //    // �����J�n
    //    BGMManager.Instance.PlayAmbientBGM(BGMManager.Instance.ambientBGMClip);

    //    // ���ʉ�SE�ƃ��A�N�V����SE��1�񂸂Đ�
    //    BGMManager.Instance.PlaySE(BGMManager.Instance.seClip);
    //    BGMManager.Instance.PlayReactionSE(BGMManager.Instance.reactionSEClip);

    //    // �K�v�Ȃ�A�O�̊������~�߂�
    //    // BGMManager.Instance.StopAmbientBGM();
    //}
    // ---- ����BGM ----
    public void PlayAmbientBGM(int index)
    {
        if (ambientBGMs.Length > index)
        {
            ambientBGMSource.clip = ambientBGMs[index];
            ambientBGMSource.loop = true;
            ambientBGMSource.Play();
        }
    }

    public void StopAmbientBGM()
    {
        ambientBGMSource.Stop();
    }

    // ---- ���ʉ�SE ----
    public void PlayEffectSE(int index)
    {
        if (effectSEs.Length > index)
        {
            effectSESource.PlayOneShot(effectSEs[index]);
        }
    }

    // ---- ���A�N�V����SE ----
    public void PlayReactionSE(int index)
    {
        if (reactionSEs.Length > index)
        {
            reactionSESource.PlayOneShot(reactionSEs[index]);
        }
    }

    */

    #endregion
}
