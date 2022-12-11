using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
  /* public void StartGame()
    {
        SceneManager.LoadScene(2);

    }*/

    public void NewGame()
    {
        UserDataController.Instance.ResetData();
        SceneManager.LoadScene("Level 1");
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Level()
    {
        SceneManager.LoadScene("LevelMenu");

    }

    public void Records()
    {
        SceneManager.LoadScene("GameResults");
    }
    public void Settings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
    public void Continue()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Return()
    {
        SceneManager.LoadScene("StartMenu");
    }

}
