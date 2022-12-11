using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Hero>(out var hero))
        {
            UserDataController.Instance.SaveCurrentToTable();
            SceneManager.LoadScene("GameResult");
        }
    }
}
