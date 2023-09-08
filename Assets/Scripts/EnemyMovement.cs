using System;
using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public Transform playerTransform;
    [SerializeField] public float stalkUpdateFrequency;
    [SerializeField] public float rotationAroundPlayer; // TODO make this a private unset variable, see Start()
    [SerializeField] public float distanceFromPlayer;
    [SerializeField] public float WanderDistanceMin;
    [SerializeField] public float WanderDistanceMax;

    private float lastStalkUpdate;

    // Start is called before the first frame update
    void Start()
    {
        // TODO Set rotationAroundPlayer based on current position

        StartCoroutine(Stalk());
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(playerTransform);
    }

    private IEnumerator Stalk()
    {
        while (true)
        {
            Vector3 newPosition = DetermineNewPositionAroundPlayer();
            StartCoroutine(MoveTo(newPosition, UnityEngine.Random.Range(stalkUpdateFrequency * 0.5f, stalkUpdateFrequency)));
            yield return new WaitForSeconds(stalkUpdateFrequency); // Repeat after x seconds, but not before the previous coroutine ended
        }
    }

    private IEnumerator MoveTo(Vector3 targetPos, float duration)
    {
        Vector3 startPos    = transform.position;
        float   timeStarted = Time.time;

        while (Time.time - timeStarted < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, (Time.time - timeStarted) / duration);
            yield return null;
        }
    }

    private Vector3 DetermineNewPositionAroundPlayer()
    {
        rotationAroundPlayer += UnityEngine.Random.Range(WanderDistanceMin, WanderDistanceMax);

        Vector3 rotation = new Vector3(Mathf.Cos(rotationAroundPlayer * Mathf.Deg2Rad), 0, Mathf.Sin(rotationAroundPlayer * Mathf.Deg2Rad)).normalized;

        return playerTransform.position + rotation * distanceFromPlayer;
    }
}
