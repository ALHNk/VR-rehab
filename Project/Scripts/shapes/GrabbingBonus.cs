using Oculus.Interaction;
using UnityEngine;

public class GrabbingBonus : MonoBehaviour
{
    public GrabInteractable grabInteractable;
    private bool isGrabbed = false;

    public UIManagement ui;

    void Update()
    {
        if (isGrabbed == false)
        {
            if (grabInteractable.State == InteractableState.Select)
            {
                ui.incScore();
                isGrabbed = true;
            }            
        }
        
    }

}
