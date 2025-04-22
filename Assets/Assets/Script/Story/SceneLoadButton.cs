using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadbutton : MonoBehaviour
{

    public void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("�V�[���������͂���Ă��܂���I");
        }
    }
}
