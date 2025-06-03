using System.Collections;
using UnityEngine;

public class WalkLevelController : MonoBehaviour
{
    public float initialSpeed;
    public float stepBackDistance = 1f;
    public Camera playerCamera;
    [SerializeField] GameObject panel, levelCompetedText, mistakeText;
    public UIManagement ui;
    private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelCompetedText.SetActive(false);
        mistakeText.SetActive(false);
        speed = initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        moveForward();
    }

    public void moveForward()
    {
        Vector3 moveDirection = playerCamera.transform.forward;
        moveDirection.y = 0f;
        moveDirection.Normalize();
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            mistake();
        }
        else if (other.tag == "Win")
        {
            win();
            other.gameObject.SetActive(false);
        }
    }

    public void mistake()
    {
        ui.decScore();
        mistakeText.SetActive(true);
        speed = 0f;
        StartCoroutine(movePlayerBackForASecond());
        StartCoroutine(hideMistakeText());
    }

     private IEnumerator movePlayerBackForASecond()
    {
       Vector3 startPosition = transform.position;

        Vector3 cameraBackDirection = -playerCamera.transform.forward;
        cameraBackDirection.y = 0f; 
        cameraBackDirection.Normalize(); 
        float timePassed = 0f;
        while (timePassed < 1f)
        {
            transform.position = Vector3.Lerp(startPosition, startPosition + cameraBackDirection * stepBackDistance, timePassed);
            timePassed += Time.deltaTime;
            yield return null;
        }

    }
    public void win()
    {
        panel.SetActive(true);
        levelCompetedText.SetActive(true);
        speed = 0f;
        ui.incScore(5);
        ui.setScore();
    }

    IEnumerator hideMistakeText()
    {
        yield return new WaitForSeconds(3f);
        mistakeText.SetActive(false);
        speed = initialSpeed;
    }
}
