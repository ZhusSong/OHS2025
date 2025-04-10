using UnityEngine;
using UnityEngine.UI;

public class ImageToggle : MonoBehaviour
{
    public GameObject imageObject;

    public void ToggleImage()
    {
        if (imageObject != null)
        {
       
            imageObject.SetActive(!imageObject.activeSelf);
        }
    }
}
