using System.Collections;
using UnityEngine;

public class Mirror : MonoBehaviour
{
	public GameObject lionCloseUp;
	public AudioSource babyLaugh;

	private IEnumerator OnTriggerEnter(Collider other)
	{
        if (other.GetType() != typeof(CharacterController))
            yield break;

        lionCloseUp.SetActive(true);
	}
}