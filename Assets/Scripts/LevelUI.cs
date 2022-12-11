using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public void StartLevel1()
    {
        UserDataController.Instance.ResetData();
        SceneManager.LoadScene("Level 1"); 
    }
    public void StartLevel2()
    {
        UserDataController.Instance.ResetData();
        SceneManager.LoadScene("Level 2");
    }
    public void StartLevel3()
    {
        UserDataController.Instance.ResetData();
        SceneManager.LoadScene("Level 3");
    }
    public void StartLevel4()
    {
        UserDataController.Instance.ResetData();
        SceneManager.LoadScene("Level 4");
    }
    public void Menu()
    {
        UserDataController.Instance.ResetData();
        SceneManager.LoadScene("StartMenu");

    }

}
