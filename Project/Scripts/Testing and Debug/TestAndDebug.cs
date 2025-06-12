using UnityEngine;

public class TestAndDebug : MonoBehaviour
{
	public OpeningDecsription uju;
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		if(Input.GetKeyDown(KeyCode.O))
		{
			uju.OpenOrClose();
		}
	}
}
