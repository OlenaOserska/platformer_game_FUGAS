
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotomymenu : MonoBehaviour
{
    public void menu()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f;
    }

}

