using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class MovingObjectScript : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    public float initalSpeed;
    [SerializeField] GrabInteractable grabInteractable;
    [SerializeField] HandGrabInteractable handGrabInteractable;
    [SerializeField] RandomSpawnerController spawnerController;
    [SerializeField] UIManagement ui;
    public int shapeSpawnersIndexInSpawnerController;

    private bool isRespawning = false;
    private float waitingTimer = -1f;
    

    private float speed;
    void Start()
    {
        speed = initalSpeed;
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if ((grabInteractable.State == InteractableState.Select || handGrabInteractable.State == InteractableState.Select) && isRespawning == false)
        {
            speed = 0;
            waitingTimer = 0.5f;
            isRespawning = true;
        }
        if (isRespawning)
        {
            waitingTimer -= Time.deltaTime;
            if (waitingTimer <= 0f)
            {
                waitingTimer = -1f;
                isRespawning = false;
                respawn();
            }

        }
    }


    public void respawn()
    {
        ui.deQuantity();
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        speed = initalSpeed;
        spawnerController.randomSpawn(shapeSpawnersIndexInSpawnerController);
        ui.incScore();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Edge")
        {
            ui.decScore();
            respawn();
        }
    }
}
