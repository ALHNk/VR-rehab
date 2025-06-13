using UnityEngine;

public class TrafficLight : MonoBehaviour
{
	public bool hasPasser;
	public bool isGreen; //Green For Cars and Red for Walkers
	
	
	public float greenDuration = 5f;
	public float redDuration = 5f;

	private float timer;
	private bool currentIsGreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    hasPasser = false;
	    isGreen = false;
	    currentIsGreen = false;
	    timer = redDuration;
    }

    // Update is called once per frame
    void Update()
    {
	    timer -= Time.deltaTime;

	    if (timer <= 0)
	    {
		    // Toggle light state
		    currentIsGreen = !currentIsGreen;
		    isGreen = currentIsGreen;

		    // Reset timer for the next cycle
		    timer = currentIsGreen ? greenDuration : redDuration;

	    }
    }
    
	// OnTriggerEnter is called when the Collider other enters the trigger.
	protected void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			hasPasser = true;
		}
	}
	
	// OnTriggerExit is called when the Collider other has stopped touching the trigger.
	protected void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			hasPasser = false;
		}
	}
}
