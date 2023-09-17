using Submodules.Unity_Essentials.Static;
using UnityEngine;
using Utilities;

public class Teletubbie : MonoBehaviour
{
    public bool found { get; private set; }

    private GameState _gameState;

    private void Awake()
    {
        _gameState = Singleton<GameState>.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (found || other.GetType() != typeof(CharacterController))
            return;

        // The player found the this teletubbie for the first time
        _gameState.IncrementTeletubbieFoundCount();
        found                      =  true;

        Debug.Log($"Teletubbie found. New count: {_gameState.TeletubbiesFound}");

        Dissolve();
    }

    private void Dissolve()
    {
        var transform1 = transform;
        var position   = transform1.position;
        var newPos     = new Vector3(position.x, -10, position.z);
        var dissolving = Movement.MoveTo(transform1, newPos, 1);
        StartCoroutine(dissolving);
    }
}
