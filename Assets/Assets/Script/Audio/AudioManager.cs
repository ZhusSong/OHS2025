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
    public AudioClip seClip20; 
    public AudioClip seClip21; 
    public AudioClip seClip22; 
    public AudioClip seClip23; 
    public AudioClip seClip24; 
    public AudioClip seClip25; 
    public AudioClip seClip26; 
    public AudioClip seClip27; 
    public AudioClip seClip28; 
    public AudioClip seClip29; 
    public AudioClip seClip30; 
    public AudioClip seClip31; 
    public AudioClip seClip32; 
    public AudioClip seClip33; 
    public AudioClip seClip34; 
    public AudioClip seClip35; 
    public AudioClip seClip36; 
    public AudioClip seClip37; 
    public AudioClip seClip38; 
    public AudioClip seClip39; 

    private List<AudioSource> activeSESources = new List<AudioSource>();

    private float volume;
    // 蜀・Κ逕ｨ・壼・騾壹・蜀咲函蜃ｦ逅・
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


    // 螟夜Κ逕ｨ・壽欠螳壹＆繧後◆AudioClip繧貞・逕溘＠縲・浹驥上ｒ謖・ｮ壹＠縺ｾ縺・
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

    // 蛟句挨SE蜀咲函逕ｨ縺ｮ髢｢謨ｰ・亥､悶°繧牙他縺ｶ・・
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
    public void Se12Play() { PlaySE(seClip12); } 
    public void Se13Play() { PlaySE(seClip13); } 
    public void Se14Play() { PlaySE(seClip14); } 
    public void Se15Play() { PlaySE(seClip15); } 
    public void Se16Play() { PlaySE(seClip16); } 
    public void Se17Play() { PlaySE(seClip17); } 
    public void Se18Play() { PlaySE(seClip18); } 
    public void Se19Play() { PlaySE(seClip19); } 
    public void Se20Play() { PlaySE(seClip20); } 
    public void Se21Play() { PlaySE(seClip21); } 
    public void Se22Play() { PlaySE(seClip22); } 
    public void Se23Play() { PlaySE(seClip23); } 
    public void Se24Play() { PlaySE(seClip24); } 
    public void Se25Play() { PlaySE(seClip25); } 
    public void Se26Play() { PlaySE(seClip26); } 
    public void Se27Play() { PlaySE(seClip27); } 
    public void Se28Play() { PlaySE(seClip28); } 
    public void Se29Play() { PlaySE(seClip29); } 
    public void Se30Play() { PlaySE(seClip30); } 
    public void Se31Play() { PlaySE(seClip31); } 
    public void Se32Play() { PlaySE(seClip32); } 
    public void Se33Play() { PlaySE(seClip33); } 
    public void Se34Play() { PlaySE(seClip34); } 
    public void Se35Play() { PlaySE(seClip35); } 
    public void Se36Play() { PlaySE(seClip36); } 
    public void Se37Play() { PlaySE(seClip37); } 
    public void Se38Play() { PlaySE(seClip38); } 
    public void Se39Play() { PlaySE(seClip39); } 

  


    // 縺吶∋縺ｦ縺ｮSE繧貞●豁｢
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
