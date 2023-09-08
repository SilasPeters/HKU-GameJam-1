using UnityEngine;

namespace Utilities
{
	public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		protected abstract void Awake();

		private static T instance;
		public static T Instance
		{
			get
			{
				if (instance == null)
					instance = FindObjectOfType<T>();

				return instance;
			}
		}
	}
}