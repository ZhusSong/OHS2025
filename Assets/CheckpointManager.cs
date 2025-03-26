using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointClickHandler : MonoBehaviour
{
    public Image displayImage;
    public Sprite checkpointSprite;
    public GameObject hiddenItem;
    public Transform targetPosition;

    void Start()
    {
        if (displayImage != null)
        {
            displayImage.gameObject.SetActive(false);
        }
        if (hiddenItem != null)
        {
            hiddenItem.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckClick();
            CheckHiddenItemClick();
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
            if (hit.collider.CompareTag("Checkpoint"))
            {
                Debug.Log("aaaaa");
                ShowImage();
            }
        }
    }

    void CheckHiddenItemClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == hiddenItem)
            {
                MoveHiddenItem();
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
        if (hiddenItem != null)
        {
            hiddenItem.SetActive(true);
        }
    }

    void HideImage()
    {
        if (displayImage != null)
        {
            displayImage.gameObject.SetActive(false);
        }
    }

    void MoveHiddenItem()
    {
        if (hiddenItem != null && targetPosition != null)
        {
            hiddenItem.transform.position = targetPosition.position;
        }
    }
}
