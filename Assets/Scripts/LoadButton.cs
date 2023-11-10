using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    private SaveSystem saveSystem;

    private void Awake()
    {
        saveSystem = FindObjectOfType<SaveSystem>();
    }

    public void LoadGame()
    {
        GameManager.Instance.IsLoadingGame = true;
        SceneManager.LoadScene("MainGame");
    }

 
}
