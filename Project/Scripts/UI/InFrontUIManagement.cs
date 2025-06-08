using UnityEngine;
using System.Collections;

public class InFrontUIManagement : MonoBehaviour
{
    public Transform cameraPosition;
    public Vector3 offset = new Vector3(0f, 0f, 2f);

    public float rotationSmoothness = 5f;
    private Quaternion targetRotation;
    public float moveSpeed = 5f;
    private bool isLocked = false; 

    void LateUpdate()
    {
        if (!isLocked)
        {
            transform.position = cameraPosition.position + cameraPosition.transform.TransformDirection(offset);
            targetRotation = Quaternion.LookRotation(transform.position - cameraPosition.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothness * Time.deltaTime);
        }
        
    }
    public void LockCanvas()
    {
        if (!isLocked) isLocked = true;
        else isLocked = false;
    }

    

}
