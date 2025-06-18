using UnityEngine;

public class HeigthController : MonoBehaviour
{
    
    void Update()
	{
		Vector3 position = transform.position;
		
	    if(OVRInput.GetDown(OVRInput.Button.Four))
	    {
	    	position.y += 0.05f;
	    	transform.position = position;
	    }
	    else if(OVRInput.GetDown(OVRInput.Button.Three))
	    {
	    	position.y -= 0.05f;
	    	transform.position = position;
	    }
    }
}
