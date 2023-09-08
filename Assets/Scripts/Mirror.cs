using System;
using System.Collections;
using UnityEngine;

public class Mirror : MonoBehaviour
{
	private void Start()
	{
		gameObject.SetActive(false);
	}

	private IEnumerator OnTriggerEnter(Collider other)
	{
        if (other.GetType() != typeof(CharacterController))
            yield break;

		Debug.Log("You entered the mirror!");
		yield return new WaitForSeconds(3);
		Debug.LogWarning("You died!");
	}
}