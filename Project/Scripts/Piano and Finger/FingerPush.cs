using UnityEngine;

public class FingerPush : MonoBehaviour
{
    public SculptingObject sculptingObject; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sculptingObject = FindAnyObjectByType<SculptingObject>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sculptable"))
        {
            sculptingObject.OnFingerCollide(collision.contacts[0].point); 
        }
    }
}
