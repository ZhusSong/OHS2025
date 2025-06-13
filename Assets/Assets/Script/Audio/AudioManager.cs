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
    public AudioClip seClip06;
    public AudioClip seClip07;
    public AudioClip seClip08;
    public AudioClip seClip09;
    public AudioClip seClip10;
    public AudioClip seClip11; 
    public AudioClip seClip12; 
    public AudioClip seClip13; 
    public AudioClip seClip14; 
    public AudioClip seClip15; 
    public AudioClip seClip16; 
    public AudioClip seClip17; 
    public AudioClip seClip18; 
    public AudioClip seClip19; 

    private List<AudioSource> activeSESources = new List<AudioSource>();

    private float volume;
    // 冁E��用�E��E通�E再生処琁E
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


    // 外部用�E�指定されたAudioClipを�E生し、E��量を持E��しまぁE
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

    // 個別SE再生用の関数�E�外から呼ぶ�E�E
    public void Se01Play() { PlaySE(seClip01); }
    public void Se02Play() { PlaySE(seClip02); }
    public void Se03Play() { PlaySE(seClip03); }
    public void Se04Play() { PlaySE(seClip04); }
    public void Se05Play() { PlaySE(seClip05); }
    public void Se06Play() { PlaySE(seClip06); }
    public void Se07Play() { PlaySE(seClip07); }
    public void Se08Play() { PlaySE(seClip08); }
    public void Se09Play() { PlaySE(seClip09); }
    public void Se10Play() { PlaySE(seClip10); }
    public void Se11Play() { PlaySE(seClip11); } // �ǉ�
    public void Se12Play() { PlaySE(seClip12); } 
    public void Se13Play() { PlaySE(seClip13); } 
    public void Se14Play() { PlaySE(seClip14); } 
    public void Se15Play() { PlaySE(seClip15); } 
    public void Se16Play() { PlaySE(seClip16); } 
    public void Se17Play() { PlaySE(seClip17); } 
    public void Se18Play() { PlaySE(seClip18); } 
    public void Se19Play() { PlaySE(seClip19); } 

  


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
