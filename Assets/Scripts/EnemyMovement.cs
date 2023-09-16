using System.Collections;
using UnityEngine;
using Utilities;
using static Submodules.Unity_Essentials.Static.Movement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public Transform playerTransform;
    [SerializeField] public float stalkUpdateFrequency;
    [SerializeField] public float rotationAroundPlayer; // TODO make this a private unset variable, see Start()
    [SerializeField] public float[] distancesFromPlayer;
    [SerializeField] public float WanderDistanceMin;
    [SerializeField] public float WanderDistanceMax;

    private float lastStalkUpdate;

    private float currentDistanceFromPlayer => distancesFromPlayer[GameState.TeletubbiesFound];

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
            StartCoroutine(MoveTo(transform, newPosition, Random.Range(stalkUpdateFrequency * 0.5f, stalkUpdateFrequency)));
            yield return new WaitForSeconds(stalkUpdateFrequency); // Repeat after x seconds, but not before the previous coroutine ended
        }
    }

    private Vector3 DetermineNewPositionAroundPlayer()
    {
        rotationAroundPlayer += Random.Range(WanderDistanceMin, WanderDistanceMax);

        Vector3 rotation = new Vector3(Mathf.Cos(rotationAroundPlayer * Mathf.Deg2Rad), 0, Mathf.Sin(rotationAroundPlayer * Mathf.Deg2Rad)).normalized;

        return playerTransform.position + rotation * currentDistanceFromPlayer;
    }
}
