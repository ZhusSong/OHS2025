using UnityEngine;
using System.Collections.Generic;

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
    public AudioClip seClip11; // 追加

    private List<AudioSource> activeSESources = new List<AudioSource>();

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

    // 個別SE再生用の関数（外から呼ぶ）
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
    public void Se11Play() { PlaySE(seClip11); } // 追加

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
