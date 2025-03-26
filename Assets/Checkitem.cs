using UnityEngine;
using UnityEngine.UI;

public class CheckitemClickHandler : MonoBehaviour
{
    public Image displayImage;
    public Sprite checkpointSprite;

    void Start()
    {
        if (displayImage != null)
        {
            displayImage.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckClick();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideImage();
        }
    }

    void CheckClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("item"))
            {
                Debug.Log("aaaaa");
                ShowImage();
            }
        }
    }

    void ShowImage()
    {
        if (displayImage != null && checkpointSprite != null)
        {
            displayImage.sprite = checkpointSprite;
            displayImage.gameObject.SetActive(true);
        }
    }

    void HideImage()
    {
        if (displayImage != null)
        {
            displayImage.gameObject.SetActive(false);
        }
    }
}
