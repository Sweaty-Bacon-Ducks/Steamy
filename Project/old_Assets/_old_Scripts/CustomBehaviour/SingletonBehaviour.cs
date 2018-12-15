using UnityEngine;
using System;
namespace CustomBehaviour
{
    /// <summary>
    ///This class makes the classes deriving from it singletons 
    /// </summary>
    public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
    {
        #region Singleton
       protected static T _instance;

        public static T Instance
        {
            get
            { return _instance; }

            private set
            { _instance = value; }
        }

        void Awake()
        {
            if (_instance != null)
            {
                throw new SingletonException("More than one instance of " + gameObject.name + " detected!");
            }
            _instance = (T)this;
        }
        #endregion
    }
    /// <summary>
    /// Used for handling any exceptions that a singleton can couse (i.e. more than one instance of an singleton)
    /// </summary>
    [Serializable()]
    public class SingletonException : Exception
    {
        public SingletonException() : base() { }
        public SingletonException(string Message) : base(Message) { }
        public SingletonException(string Message,Exception inner) :base(Message,inner) { }
    }
}

