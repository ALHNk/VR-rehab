using Oculus.Interaction;
using UnityEngine;

public class FireFighting : MonoBehaviour
{
    public GrabInteractable grabInt;
    public GameObject spray;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spray.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (grabInt != null && grabInt.State == InteractableState.Select)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                spray.SetActive(true);
            }
            else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)|| OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                spray.SetActive(false);
            }
        }
        else
        {
            spray.SetActive(false);
        }
    }
}
