using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class UserData
{
    public int Coins;
    public string UserName;
    public int Lives;
    // public int scenRem;
}

[Serializable]
public class ResultTable
{
    public List<UserData> userDatas;
}

public class UserDataController : MonoBehaviour
{
    public int scenRem;
    public static UserDataController Instance { get; private set; }

    public UserData userData;

    private string PATH => Application.persistentDataPath + "/UserData.txt";
    private string RESULT_TABLE_PATH => Application.persistentDataPath + "/TableData.txt";

    private void Awake()
    {
        print(PATH);
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            print("Create instance");

            LoadData();
        }
        else
        {
            print("Instance was created, delete current");
            Destroy(gameObject);
        }
    }

    private void LoadData()
    {
        if (System.IO.File.Exists(PATH))
        {
            print("load exists user data");
            string json = System.IO.File.ReadAllText(PATH);
            userData = JsonUtility.FromJson<UserData>(json);
        }
        else
        {
            print("create new user data");
            userData = new UserData();
            userData.Coins = 0;
            userData.UserName = UserInfo.Instance.UserName;
            userData.Lives = 3;
        }

        ResultTable table = GetResultTable();
        print(table.userDatas.Count);
    }
    public void SceneRemember()
    {
        scenRem = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SceneIndex", scenRem);
    }
    public int GetSceneRemember()
    {
        scenRem = PlayerPrefs.GetInt("SceneIndex");
        return scenRem;
    }
    public void SaveData()
    {
        string json = JsonUtility.ToJson(userData);
        System.IO.File.WriteAllText(PATH, json);
        print(json);
    }

    public void SaveCurrentToTable()
    {
        if (System.IO.File.Exists(RESULT_TABLE_PATH))
        {
            string json = System.IO.File.ReadAllText(RESULT_TABLE_PATH);
            ResultTable table = JsonUtility.FromJson<ResultTable>(json);

            if(table.userDatas == null)
            {
                table.userDatas = new List<UserData>();
            }
            table.userDatas.Add(userData);
            
            json = JsonUtility.ToJson(table);
            print("saving: " + json);
            System.IO.File.WriteAllText(RESULT_TABLE_PATH, json);
        }
        else
        {
            ResultTable table = new ResultTable();
            table.userDatas = new List<UserData>();
            table.userDatas.Add(userData);

            string json = JsonUtility.ToJson(table);
            System.IO.File.WriteAllText(RESULT_TABLE_PATH, json);
        }
    }

    public ResultTable GetResultTable()
    {
        if (System.IO.File.Exists(RESULT_TABLE_PATH) == false)
        {
            var table = new ResultTable();
            table.userDatas = new List<UserData>();
            return table;
        }
        else
        {
            string json = System.IO.File.ReadAllText(RESULT_TABLE_PATH);
            ResultTable table = JsonUtility.FromJson<ResultTable>(json);
            return table;
        }
    }

    public void AddHealth(int hp)
    {
        userData.Lives += hp;
        SaveData();
    }

    public void RemoveHealth(int hp)
    {
        userData.Lives -= hp;
        SaveData();
    }

    public void AddCoins(int coins)
    {
        userData.Coins += coins;
        SaveData();
    }
    public void SetUserName(string newName)
    {
        userData.UserName = newName;
        SaveData();
    }
    public void ResetData()
    {
        userData.Coins = 0;
        userData.Lives = 3;
    }

    public void ResetCoins()
    {
        userData.Coins = 0;
    }

    public void ResetLives()
    {
        userData.Lives = 3;
    }
}


