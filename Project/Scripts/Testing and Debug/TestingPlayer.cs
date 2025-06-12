using UnityEngine;

public class TestingPlayer : MonoBehaviour
{
	public float speed = 5f;

	void Update()
	{
		float x = Input.GetAxis("Horizontal"); 
		float z = Input.GetAxis("Vertical");  

		Vector3 move = new Vector3(x, 0, z);
		transform.Translate(move * speed * Time.deltaTime);
	}
    
}
