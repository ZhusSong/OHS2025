using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FadeAllObjectsAndPlayVideo : MonoBehaviour
{
    [Header("���ԂɃt�F�[�h���� GameObjects�iRenderer �K�{�j")]
    public List<GameObject> objectsToFade;

    [Header("1�X�e�b�v�̃t�F�[�h���ԁi�b�j")]
    public float fadeDuration = 1f;

    [Header("�X�e�b�v�Ԃ̑ҋ@���ԁi�b�j")]
    public float waitTime = 0.5f;

    [Header("����Đ��O�̑ҋ@���ԁi�b�j")]
    public float videoWaitTime = 2f;

    public float backWaitTime = 2f;

    [Header("������܂� GameObject�iVideoPlayer �K�{�j")]
    public GameObject videoContainer;

    private VideoPlayer videoPlayer;

    private GameObject lastObject; // �Ō�ɕ\�����ꂽ�I�u�W�F�N�g��ێ�

    void Awake()
    {
        // videoContainer ���� VideoPlayer ���擾
        if (videoContainer != null)
        {
            videoPlayer = videoContainer.GetComponent<VideoPlayer>();
            videoContainer.SetActive(false);
        }

        if (videoPlayer != null)
        {
            videoPlayer.Stop();
        }

        // �t�F�[�h�Ώۂ��������i��\���������j
        foreach (var obj in objectsToFade)
        {
            if (obj != null)
            {
                obj.SetActive(false);
                SetAlpha(obj, 0f);
            }
        }
    }

    // ���̊֐����ĂԂƏ������n�܂�
    public void StartFadeAndPlayVideo()
    {
        StartCoroutine(PlaySequenceForAll());
    }

    IEnumerator PlaySequenceForAll()
    {
        for (int i = 0; i < objectsToFade.Count; i++)
        {
            GameObject obj = objectsToFade[i];
            if (obj == null) continue;

            obj.SetActive(true);
            SetAlpha(obj, 0f);

            yield return StartCoroutine(FadeObject(obj, 0f, 0.5f));
            yield return new WaitForSeconds(waitTime);

            yield return StartCoroutine(FadeObject(obj, 0.5f, 1f));
            yield return new WaitForSeconds(waitTime);

            if (i < objectsToFade.Count - 1)
            {
                yield return StartCoroutine(FadeObject(obj, 1f, 0.5f));
                yield return new WaitForSeconds(waitTime);
                yield return StartCoroutine(FadeObject(obj, 0.5f, 0f));
                obj.SetActive(false); // �Ō�̃I�u�W�F�N�g�ȊO�͔�\���ɂ���
            }
            else
            {
                lastObject = obj; // �Ō�̃I�u�W�F�N�g���L��
            }

            yield return new WaitForSeconds(waitTime);
        }

        //yield return new WaitForSeconds(backWaitTime);

        //if (videoContainer != null && videoPlayer != null)
        //{
        //    videoContainer.SetActive(true);
        //    videoPlayer.Play();

        //    yield return new WaitForSeconds(videoWaitTime);

        //    videoContainer.SetActive(false);
        //}
    }

    public void HideLastObject()
    {
        if (lastObject != null)
        {
            StartCoroutine(HideAndFadeOut(lastObject));
        }
    }

    private IEnumerator HideAndFadeOut(GameObject obj)
    {
        yield return StartCoroutine(FadeObject(obj, 1f, 0f));
        obj.SetActive(false);
    }

    IEnumerator FadeObject(GameObject obj, float fromAlpha, float toAlpha)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer == null) yield break;

        Material mat = renderer.material;
        float time = 0f;

        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(fromAlpha, toAlpha, time / fadeDuration);
            SetAlpha(mat, alpha);
            time += Time.deltaTime;
            yield return null;
        }

        SetAlpha(mat, toAlpha);
    }

    void SetAlpha(GameObject obj, float alpha)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer == null) return;

        Material mat = renderer.material;
        SetAlpha(mat, alpha);
    }

    void SetAlpha(Material mat, float alpha)
    {
        if (mat.HasProperty("_Color"))
        {
            Color color = mat.color;
            color.a = alpha;
            mat.color = color;
        }
    }
}
