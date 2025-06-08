using UnityEngine;

public class Key : MonoBehaviour
{
    [HideInInspector]
    public bool isPressed = false;

    public bool isNextToPress = false;   
    public float pressDistance = 0.1f;  
    public float pressSpeed = 5f;  

    private Vector3 originalPosition;
    private UIManagement ui;
    private PublicEnvironemnt publicEnvironemnt;
    private bool hasEntered = false;
    void Start()
    {
        originalPosition = transform.position;
        ui = FindAnyObjectByType<UIManagement>();
        publicEnvironemnt = FindAnyObjectByType<PublicEnvironemnt>();
    }

    void Update()
    {
        if (isPressed)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition - new Vector3(0, pressDistance, 0), Time.deltaTime * pressSpeed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * pressSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finger") && !hasEntered)
        {
            isPressed = true;
            hasEntered = true;
            if (!publicEnvironemnt.isWon)
            {
                if (isNextToPress)
                {
                    ui.incScore();
                }
                
            }        
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Finger"))
        {
            isPressed = false;
            hasEntered = false;
               
        }
    }
}
