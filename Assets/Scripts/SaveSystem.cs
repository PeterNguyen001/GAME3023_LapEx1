using System;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public event Action OnSaveRequested; // Event for subscribers to listen to

    private static SaveSystem instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make the object persistent across scenes
        }
        else
        {
            Destroy(gameObject); // If another instance exists, destroy this one
        }
    }

    public void RequestSave()
    {
        OnSaveRequested?.Invoke(); // Trigger the event
    }
}
