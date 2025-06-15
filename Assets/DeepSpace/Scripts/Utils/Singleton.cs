using UnityEngine;

namespace DeepSpace.Utils
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        public virtual void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.Log("There is already a Singleton " + typeof(T) + "\nDestroying this");
                Destroy(this);
            }
            else
            {
                Instance = this as T;
            }
        }
    }


    public class PersistentSingleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        public virtual void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.Log("There is already a Singleton " + typeof(T) + "\nDestroying this");
                Destroy(this);
            }
            else
            {
                Instance = this as T;
                DontDestroyOnLoad(this);
            }
        }
    }
}
