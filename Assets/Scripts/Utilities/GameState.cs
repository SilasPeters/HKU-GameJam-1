using System.Collections;
using System.Linq;
using Submodules.Unity_Essentials.Static;
using UnityEngine;
using UnityEngine.Serialization;

namespace Utilities
{
	public class GameState : Singleton<MonoBehaviour>
	{
		public AudioSource[] teletubbiesFoundAudio;
		public AudioSource taunt;
		public Teletubbie[] teletubbies;
		public float timeBetweenHints;

		private GameObject _mirror;
		private float _timeLastPlayerProgression;

		/// <inheritdoc />
		protected override void Awake()
		{
			_mirror = GameObject.FindGameObjectWithTag("Mirror");
			_mirror.SetActive(false);

			StartCoroutine(GivePlayerHints());
		}

		public int TeletubbiesFound { get; private set; } = 0;

		private IEnumerator GivePlayerHints()
			=> HighLevelFunctions.RepeatWithInterval(timeBetweenHints, RevealLocationOfEnemy);


		/// <summary>
		/// When the player appears clueless, play a sound near a not-yet found enemy
		/// </summary>
		private void RevealLocationOfEnemy()
		{
			Debug.Log("Helping a little");
			var soundLocation = teletubbies.FirstOrDefault(x => !x.found)?.transform.position;
			if (soundLocation is null)
				return;

			taunt.transform.position = (Vector3) soundLocation;
			taunt.Play();
		}

		public void IncrementTeletubbieFoundCount()
		{
			TeletubbiesFound += 1;
			teletubbiesFoundAudio[TeletubbiesFound -1].Play();

			if (TeletubbiesFound >= 4)
				RevealMirror();
		}

		private void RevealMirror()
		{
			_mirror.SetActive(true);
		}
	}
}