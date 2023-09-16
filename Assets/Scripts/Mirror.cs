using System.Collections;
using UnityEngine;

public class Mirror : MonoBehaviour
{
	[SerializeField] public GameObject lionCloseUp;
	[SerializeField] public AudioSource babyLaugh;

	private void Start()
	{
		// gameObject.SetActive(false);
	}

	private IEnumerator OnTriggerEnter(Collider other)
	{
        if (other.GetType() != typeof(CharacterController))
            yield break;

        lionCloseUp.SetActive(true);
	}
}