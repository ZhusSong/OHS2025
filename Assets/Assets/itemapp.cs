using UnityEngine;

public class ItemClickMove : MonoBehaviour
{
    public Transform targetPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("item")) 
                {
                    hit.collider.transform.position = targetPosition.position; 
                }
            }
        }
    }
}
