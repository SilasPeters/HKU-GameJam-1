using UnityEngine;

namespace Utilities
{
	public class GameState : MonoBehaviour
	{
		private static GameObject _mirror;
		[SerializeField] public AudioSource[] teletubbiesFound;

		public void Start()
		{
			_mirror = GameObject.FindGameObjectWithTag("Mirror");
			_mirror.SetActive(false);
		}

		public static int TeletubbiesFound { get; private set; } = 0;

		public static void IncrementTeletubbieFoundCount()
		{
			TeletubbiesFound += 1;


			if (TeletubbiesFound >= 4)
				RevealMirror();
		}

		private static void RevealMirror()
		{
			_mirror.SetActive(true);
		}
	}
}