using UnityEngine;
using UnityEngine.UI;

public class InFrontUIManagement : MonoBehaviour
{
    public Transform cameraPosition;
    public Vector3 offset = new Vector3(0f, 0f, 2f);

    public float rotationSmoothness = 5f;
    private Quaternion targetRotation;

    void LateUpdate()
    {
        transform.position = cameraPosition.position + cameraPosition.transform.TransformDirection(offset);
        targetRotation = Quaternion.LookRotation(transform.position - cameraPosition.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothness * Time.deltaTime);
    }

}
