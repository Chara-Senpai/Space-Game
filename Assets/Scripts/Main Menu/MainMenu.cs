using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGameButton()
    {

        SceneManager.LoadScene("MainGame");

    }

    public void ExitGameButton()
    {

        Application.Quit();

    }
    
    public void MainMenuButton()
    {

        SceneManager.LoadScene("Title Screen");

    }
}
