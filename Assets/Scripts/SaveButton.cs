using UnityEngine;

public class SaveButton : MonoBehaviour
{
    private SaveSystem saveSystem;

    private void Awake()
    {
        saveSystem = FindObjectOfType<SaveSystem>();
    }

    public void SaveGame()
    {
        saveSystem.RequestSave(); // Request the save operation
    }
}
