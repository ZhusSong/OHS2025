using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioSource seSource;
    public AudioClip bgmClip;
    public AudioClip seClip;

    void Start()
    {
        PlayBGM();
    }

    public void PlayBGM()
    {
        if (bgmSource != null && bgmClip != null)
        {
            bgmSource.clip = bgmClip;
            bgmSource.loop = true;  // BGM�����[�v�Đ�
            bgmSource.Play();
        }
    }

    public void PlaySE()
    {
        if (seSource != null && seClip != null)
        {
            seSource.clip = seClip;
            seSource.loop = false;  // SE�̓��[�v���Ȃ�
            seSource.Play();
        }
    }
}