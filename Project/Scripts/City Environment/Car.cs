using UnityEngine;

public class Car : MonoBehaviour
{
	//0 is forward, 1 is right, 2 is back and 3 is left
	public int direction;
	
	public float initialSpeed;
	private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    speed = initialSpeed;
    }

	void Update()
	{
		Vector3 moveDir = Vector3.zero;

		switch (direction)
		{
		case 0:
			moveDir = Vector3.forward; // z+
			break;
		case 1:
			moveDir = Vector3.right; // x+
			break;
		case 2:
			moveDir = Vector3.back; // z-
			break;
		case 3:
			moveDir = Vector3.left; // x-
			break;
		}

		transform.Translate(moveDir * speed * Time.deltaTime);
	}
	
	// OnTriggerStay is called once per frame for every Collider other that is touching the trigger.
	protected void OnTriggerStay(Collider other)
	{
		if(other.tag == "Traffic Light")
		{
			if(other.GetComponent<TrafficLight>().isGreen == true && other.GetComponent<TrafficLight>().hasPasser == false)
			{
				speed = initialSpeed;
			}
			else
			{
				speed = 0;
			}
			
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Traffic Light"))
		{
			// Allow car to move again
			speed = initialSpeed;
		}
	}
}
