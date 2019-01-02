using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CustomBehaviour;

/// <summary>
/// Klasa obsługująca zdarzenia.
/// </summary>
public class EventManager : SingletonBehaviour<EventManager>
{
    /// <summary>
    /// Słownik przechowujący parę - nazwa zdarzenia, funckje wywoływane przy danym zdarzeniu
    /// </summary>
    private Dictionary<string, UnityEvent> EventDict = new Dictionary<string, UnityEvent>();

    void Awake()
    {
        Debug.Log("Starting event manager");
    }
    
    /// <summary>
    /// Instancja obiektu typu EventManager
    /// </summary>
    public new static EventManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<EventManager>();
                
                if (!_instance)
                {
                    Debug.LogError("No active EventManager!");
                }
            }
            return _instance;
        }
    }

    /// <summary>
    /// Subskrybuje funkcję do danego zdarzenia 
    /// </summary>
    /// <param name="EventName">Nazwa zdarzenia</param>
    /// <param name="listener">Funckja subskrybująca</param>
    public static void StartListening(string EventName, UnityAction listener)
    {
        UnityEvent @event = new UnityEvent();
        if (Instance.EventDict.TryGetValue(EventName, out @event))
        {
            @event.AddListener(listener);
        }
        else
        {
            @event = new UnityEvent();
            @event.AddListener(listener);
            Instance.EventDict.Add(EventName, @event);
        }
    }

    /// <summary>
    /// Usuwa daną funckję zasubskrybowaną do danego zdarzenia
    /// </summary>
    /// <param name="EventName">Nazwa zdarzenia</param>
    /// <param name="listener">Fukcja, która ma zostać odsubskrybowana</param>
    public static void StopListening(string EventName, UnityAction listener)
    {
        if (_instance == null) return;
        UnityEvent @event = new UnityEvent();
        if (Instance.EventDict.TryGetValue(EventName, out @event))
        {
            @event.RemoveListener(listener);
        }
    }
    public static void TriggerEvent(string eventName)
    {
        UnityEvent @event = null;
        if (Instance.EventDict.TryGetValue(eventName,out @event))
        {
            @event.Invoke();
        }
    }
    public static void DestroyInstance()
    {
        if (_instance != null)
        {
            Destroy(_instance);
        }
        else
        {
            Debug.Log("Failed Event Manager instance destruction!");
        }
    }
}
