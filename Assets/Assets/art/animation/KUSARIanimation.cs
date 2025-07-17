using UnityEngine;
using UnityEngine.Video;

public class KUSARIanimation : MonoBehaviour
{
    public GameObject targetObject;

    public void ActivateVideoObject()
    {
        if (targetObject == null)
        {
            Debug.LogWarning("�^�[�Q�b�g�̃I�u�W�F�N�g���ݒ肳��Ă��܂���");
            return;
        }

        targetObject.SetActive(true);

        VideoPlayer vp = targetObject.GetComponent<VideoPlayer>();
        if (vp != null)
        {
            vp.enabled = true;
            vp.Play();

            // �Đ��I�����ɔ�\���ɂ���C�x���g��ǉ�
            vp.loopPointReached += OnVideoFinished;
        }
        else
        {
            Debug.LogWarning("VideoPlayer �R���|�[�l���g��������܂���");
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        // �ΏۃI�u�W�F�N�g���\���ɂ���
        if (targetObject != null)
        {
            targetObject.SetActive(false);
            Debug.Log("����̍Đ����I���������߁A�I�u�W�F�N�g���\���ɂ��܂���");
        }
    }
}
