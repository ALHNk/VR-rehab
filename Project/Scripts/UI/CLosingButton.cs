using UnityEngine;

public class CLosingButton : MonoBehaviour
{
	public GameObject MainPanel, Holder;
	private bool isOpen = false;   
	public void OpenOrClose()
	{
		if(isOpen)
		{
			Holder.SetActive(false);
			isOpen = false;
		}
		else
		{
			Holder.SetActive(true);
			isOpen = true;
		}
	}
}
