using UnityEngine;
using Utilities;

public class Teletubbie : MonoBehaviour
{

    private bool _found = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_found || other.GetType() != typeof(CharacterController))
            return;

        // The player found the this teletubbie for the first time
        GameState.IncrementTeletubbieFoundCount();
        _found                      =  true;

        Debug.Log($"Teletubbie found. New count: {GameState.TeletubbiesFound}");
    }
}
