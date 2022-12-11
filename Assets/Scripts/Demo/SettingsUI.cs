using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingsUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField InputUserName;
    [SerializeField] private TextMeshProUGUI errorText;
    public void Save()
    {
        string userName = InputUserName.text;
     
        if(userName.Length < 4)
        {
            errorText.text = "Error: enter user name > 3 chars";
            return;
        }
        for (int i = 0; i < userName.Length; i++)
        {
            if (userName[i]==' ')
            {
                errorText.text = "Error: delet space";
                return;
            }
        }
        UserInfo.Instance.UserName = userName;  
        UserDataController.Instance.SetUserName(userName);
        SceneManager.LoadScene(0);

    }
    public void Return()
    {
        SceneManager.LoadScene("StartMenu");
    }


}
