using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //PlayBGM・PlaySEを音を鳴らしたいタイミングで使ってね

    public List<AudioSource> BGMSourceList = new List< AudioSource > ();
    public List<AudioSource> SESourceList = new List<AudioSource>();

    public enum BGMNAME
    {
       //追加したいGBM名を記入

        MAINBGM,
        AMBIENTBGM
    }
    public enum SENAME
    {
        //追加したいSE名を記入

        EFFECTSE,
        REACTIONSE
    }

    public void PlayBGM(BGMNAME name)
    {
        int number = (int)name;
        if (BGMSourceList.Count <= number)
        {
            Debug.Log("要素数をオーバーしました");
            return;
        }
        BGMSourceList[number].Play();

    }
    public void PlaySE(SENAME name)
    {
        int number = (int)name;
        if (SESourceList.Count <= number)
        {
            Debug.Log("要素数をオーバーしました");
            return;
        }
        SESourceList[number].Play();

    }
    public void StopBGM(BGMNAME name)
    {
        int number = (int)name;
        if (BGMSourceList.Count <= number)
        {
            Debug.Log("要素数をオーバーしました");
            return;
        }
        BGMSourceList[number].Stop();

    }
    public void StopSE(SENAME name)
    {
        int number = (int)name;
        if (SESourceList.Count <= number)
        {
            Debug.Log("要素数をオーバーしました");
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

    [Header("Audio Clips (仮置き)")]
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
        // 仮のメインBGMを再生
        PlayMainBGM(0);
    }

    // ---- メインBGM ----
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
    //    // 環境音開始
    //    BGMManager.Instance.PlayAmbientBGM(BGMManager.Instance.ambientBGMClip);

    //    // 効果音SEとリアクションSEを1回ずつ再生
    //    BGMManager.Instance.PlaySE(BGMManager.Instance.seClip);
    //    BGMManager.Instance.PlayReactionSE(BGMManager.Instance.reactionSEClip);

    //    // 必要なら、前の環境音を止める
    //    // BGMManager.Instance.StopAmbientBGM();
    //}
    // ---- 環境音BGM ----
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

    // ---- 効果音SE ----
    public void PlayEffectSE(int index)
    {
        if (effectSEs.Length > index)
        {
            effectSESource.PlayOneShot(effectSEs[index]);
        }
    }

    // ---- リアクションSE ----
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
