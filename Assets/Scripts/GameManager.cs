using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameManager instance;

    // Static property to access the instance
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                // If the instance doesn't exist, find it in the scene
                instance = FindObjectOfType<GameManager>();

                // If it still doesn't exist, create a new GameObject and attach the GameManager script
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("GameManager");
                    instance = singletonObject.AddComponent<GameManager>();
                }

                DontDestroyOnLoad(instance.gameObject); // Make the object persistent across scenes
            }

            return instance;
        }
    }

    // Other GameManager functionality and properties can be added here

    // Flag to indicate whether the game is being loaded
    public bool IsLoadingGame { get; set; } = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
