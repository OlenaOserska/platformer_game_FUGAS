using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject[] objHearts;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private TextMeshProUGUI textCoins;

    private void Start()
    {
        UpdateHeart(UserDataController.Instance.userData.Lives);
        SetCountCoinsUI(UserDataController.Instance.userData.Coins);
    }
    public void SetCountCoinsUI(int coins)
    {
        textCoins.text = coins.ToString();
    }
    public void GameOver()
    {
         panelGameOver.SetActive(true);
    }
    public void Restart()
    {
        UserDataController.Instance.ResetData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void UpdateHeart(int heart)
    {
        for (int i = 0; i < 3; i++)
        {
            if(heart>i)
            {
                objHearts[i].SetActive(true);
            }
            else
            {
                objHearts[i].SetActive(false);
            }
        }
    }
}
