using UnityEngine;

public class PositionSaver : MonoBehaviour
{
    private SaveSystem saveSystem;

    private void Awake()
    {
        saveSystem = FindObjectOfType<SaveSystem>();
        saveSystem.OnSaveRequested += SavePlayerPosition;
    }

    private void SavePlayerPosition()
    {
        Debug.Log(transform.position.x);
        Debug.Log(transform.position.y);
        Debug.Log(transform.position.z);
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", transform.position.z);
        PlayerPrefs.Save();
    }

    private void OnDestroy()
    {
        saveSystem.OnSaveRequested -= SavePlayerPosition;
    }
}
