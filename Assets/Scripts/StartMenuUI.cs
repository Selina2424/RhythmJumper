using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject controls;

    public void ShowControls()
    {
        mainMenu.SetActive(false);
        controls.SetActive(true);
    }

    public void ShowMainMenu()
    {
        controls.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("PreTestScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");

        Application.Quit();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
