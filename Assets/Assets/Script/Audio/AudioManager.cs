using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public AudioClip seClip01;
    public AudioClip seClip02;
    public AudioClip seClip03;
    public AudioClip seClip04;
    public AudioClip seClip05;

    private List<AudioSource> activeSESources = new List<AudioSource>();

    private float volume;
    // 内部用：共通の再生処理
    private void PlaySE(AudioClip clip)
    {
        if (clip == null) return;

        GameObject seObj = new GameObject("SE_AudioSource");
        seObj.transform.parent = this.transform;

        AudioSource newSource = seObj.AddComponent<AudioSource>();
        newSource.clip = clip;
        newSource.Play();
        activeSESources.Add(newSource);

        Destroy(seObj, clip.length + 0.1f);
    }


    // 外部用：指定されたAudioClipを再生し、音量を指定します
    public void PlaySE_External(AudioClip clip,float _volume)
    {
        if (clip == null) return;

        GameObject tempAudioObject = new GameObject("TempAudio_" + clip.name);
        AudioSource audioSource = tempAudioObject.AddComponent<AudioSource>();

       
        audioSource.clip = clip;
        audioSource.volume = Mathf.Clamp01(_volume);
        audioSource.Play();

        Object.Destroy(tempAudioObject, clip.length);
    }

    // 個別SE再生用の関数（外から呼ぶ）
    public void Se01Play() { PlaySE(seClip01); }
    public void Se02Play() { PlaySE(seClip02); }
    public void Se03Play() { PlaySE(seClip03); }
    public void Se04Play() { PlaySE(seClip04); }
    public void Se05Play() { PlaySE(seClip05); }

  


    // すべてのSEを停止
    public void StopAllSE()
    {
        foreach (AudioSource source in activeSESources)
        {
            if (source != null && source.isPlaying)
                source.Stop();

            if (source != null)
                Destroy(source.gameObject);
        }

        activeSESources.Clear();
    }
}
