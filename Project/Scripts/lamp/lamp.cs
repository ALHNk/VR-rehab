using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamp : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject lighter, panel, levelCompletedText;
    public UIManagement ui;
    private float previousRotationY;
    private int rotationCount = 0;
    private bool isWon = false;
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "lampHolder")
        {
            previousRotationY = transform.rotation.eulerAngles.y;
        }
    }

    void OnTriggerStay(Collider other)
    {

        if (other.tag == "lampHolder")
        {

            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            float currentRotationY = transform.rotation.eulerAngles.y;
            float rotationDifference = Mathf.Abs(currentRotationY - previousRotationY);
            if (rotationDifference >= 180f)
            {
                rotationCount += Mathf.FloorToInt(rotationDifference / 180f);
                if (rotationCount >= 3)
                {
                    lighter.SetActive(true);
                    rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
                    StartCoroutine(win());
                }
            }
        }
    }

    IEnumerator win()
    {
        yield return new WaitForSeconds(1f);
        panel.SetActive(true);
        levelCompletedText.SetActive(true);
        if (!isWon)
        {
            ui.incScore(5);
            ui.setScore();
        }
    }
}
