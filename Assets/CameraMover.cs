using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform targetPosition; 
    public float moveSpeed = 5f; 

    public void MoveCamera()
    {
        StartCoroutine(MoveToTarget());
    }

    private System.Collections.IEnumerator MoveToTarget()
    {
        Transform cameraTransform = Camera.main.transform;

        while (Vector3.Distance(cameraTransform.position, targetPosition.position) > 0.01f)
        {
            cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, targetPosition.position, moveSpeed * Time.deltaTime);
            yield return null;
        }
        Debug.Log("aaaaa");

        cameraTransform.position = targetPosition.position;
    }
}
