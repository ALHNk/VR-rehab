using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 thumbStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if (thumbStick.magnitude > 0.1f)
        {
            Vector3 moveDirection = new Vector3(thumbStick.x, 0, thumbStick.y);
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.Self);
        }
        Vector2 rotater = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        if (Mathf.Abs(rotater.x) > 0.1)
        {
            float yaw = rotater.x * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, yaw, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NextLevel")
        {
            string level = other.GetComponent<NextLevel>().level;
            SceneManager.LoadScene(level);
        }
    }
}
