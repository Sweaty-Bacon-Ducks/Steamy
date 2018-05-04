using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CustomBehaviour;

public class EventManager : SingletonBehaviour<EventManager>
{
    private Dictionary<string, UnityEvent> EventDict = new Dictionary<string, UnityEvent>();

    void Awake()
    {
        Debug.Log("Starting event manager");
    }
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
    public static void StartListening(string EventName, UnityAction listener)
    {
        UnityEvent @event = new UnityEvent();
        //Debug.Log(Instance.EventDict.Count);
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
