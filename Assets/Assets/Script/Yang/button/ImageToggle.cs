using UnityEngine;
using UnityEngine.UI;

public class ImageToggle : MonoBehaviour
{
    bool canuse = true;
    public GameObject imageObject;
    Button thisButton;
    void Awake()
    {
        thisButton = this.GetComponent<Button>();
    }

    public void ToggleImage()
    {
        if (imageObject != null)
        {
            imageObject.SetActive(!imageObject.activeSelf);
        }
    }
}