using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameUIUser : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textUserName;
  //  [SerializeField] private TextMeshProUGUI textScore;
  //  private int score = 0;
  
    void Start()
    {
        textUserName.text = UserDataController.Instance.userData.UserName;
    }

    
   /* public void AddScore()
    {
        score += Random.Range(1, 5);
        textScore.text = "Score: " + score;
    }
    public void ReturnMenu()
    {
        string saveScore = PlayerPrefs.GetString("save");
        string[] users = saveScore.Split('|');
        string userName = UserInfo.Instance.UserName;
        bool isNewUser = true;
        saveScore = "";
        for (int i = 0; i < users.Length - 1; i++)
        {
            string[] userInfo = users[i].Split(':');
            if (userInfo[0] == userName)
            {
                if (score > int.Parse(userInfo[1]))
                {
                    userInfo[1] = score.ToString();

                }
                isNewUser = false;
            }
            saveScore += $"{userInfo[0]}:{userInfo[1]}|";
        }
        if (isNewUser)
        {
            saveScore += $"{userName}:{score}|";
        }

        PlayerPrefs.SetString("save", saveScore);
        SceneManager.LoadScene(0);
    }*/

}
