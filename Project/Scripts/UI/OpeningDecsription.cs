using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class OpeningDecsription : MonoBehaviour
{
	public Animator anim;
	private bool isOpen = false;
	public GameObject Text, CheckMark;

	void Start()
	{
		Text.SetActive(false);
	}

	public void OpenOrClose()
	{
		if (isOpen == false)
		{
			Text.SetActive(true);
			anim.Play("DescriptionOpen");
			StartCoroutine(RotateCheckMark(0f, 180f, 1f));
			isOpen = true;
		}
		else
		{
			StartCoroutine(Close());
		}
	}

	IEnumerator Close()
	{
		anim.Play("DescriptionClose");
		StartCoroutine(RotateCheckMark(180f, 0f, 0.45f));
		yield return new WaitForSeconds(1f);
		Text.SetActive(false);
		isOpen = false;
	}

	IEnumerator RotateCheckMark(float fromAngle, float toAngle, float duration)
	{
		float elapsed = 0f;
		Quaternion startRotation = Quaternion.Euler(0, 0, fromAngle);
		Quaternion endRotation = Quaternion.Euler(0, 0, toAngle);

		while (elapsed < duration)
		{
			elapsed += Time.deltaTime;
			CheckMark.transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsed / duration);
			yield return null;
		}

		CheckMark.transform.rotation = endRotation;
	}
}
