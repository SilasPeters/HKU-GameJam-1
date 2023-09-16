using System.Collections;
using UnityEngine;

public class LionCloseup : MonoBehaviour
{
	[SerializeField] public float duration;
	[SerializeField] public new Camera camera;

	private void Start()
	{
		StartCoroutine(CloseUpToPlayer());
	}

	private IEnumerator CloseUpToPlayer()
	{
		Vector3     targetPos = new Vector3(transform.position.x, transform.position.y, -1);

		Vector3 startPos    = transform.position;
		float   timeStarted = Time.time;

		while (Time.time - timeStarted < duration)
		{
			transform.position = Vector3.Lerp(startPos, targetPos, (Time.time - timeStarted) / duration);
			yield return null;
		}

		camera.enabled = false;
	}
}