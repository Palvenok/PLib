using UnityEngine;

namespace PLib.Singleton
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        /// <summary>
        /// Instance of &lt;T&gt; class
        /// </summary>
        public static T Instance { get; private set; }

        /// <summary>
        /// Requires <br/>
        /// <example>
        /// <c>base.Awake();</c>
        /// </example>
        /// </summary>
        public virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }
    }
}
