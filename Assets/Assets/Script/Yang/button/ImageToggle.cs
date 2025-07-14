using UnityEngine;
using UnityEngine.UI;

public class ImageToggle : MonoBehaviour
{
    bool canuse = true;
    public GameObject imageObject;
    public GameObject Jinja;
    Button thisButton;
    void Awake()
    {
        thisButton = this.GetComponent<Button>();
    }

    public void ToggleImage()
    {
      
    }
}