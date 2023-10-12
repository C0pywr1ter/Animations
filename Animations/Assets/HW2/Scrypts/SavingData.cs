using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SavingData : MonoBehaviour
{
 
    public static string path;
    public GameData gameData;
    private Player playerData;
    public GameObject _Player;
    public GameObject SavingDiskette;
    public GameObject LoadFail;
    public GameObject FileLoaded;
    private float timer;
    private void Awake()
    {
        path = Application.dataPath + "/SaveData.json";
        gameData = new GameData();
        playerData = _Player.GetComponent<Player>();
       

    }
    private void Update()
    {
       if(timer >= 3f)
        {
          
            FileLoaded.SetActive(false);
            LoadFail.SetActive(false);
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.F9))
        {
            Load();
        }
    }
    public void Save()
    {
        StartCoroutine(SavingCoroutine());

        gameData.playerHP = playerData.HP;
        gameData.enemiesKilled = Enemy.enemyDeaths;
        gameData.playerPosition = playerData.transform.position;

        string jsonData = JsonUtility.ToJson(gameData, true);

        File.WriteAllText(path, jsonData);

    }
    public void Load()
    {
        if (File.Exists(path))
        {
            timer += Time.deltaTime;
            FileLoaded.SetActive(true);

            string data = File.ReadAllText(path);
            gameData = JsonUtility.FromJson<GameData>(data);

            playerData.HP = gameData.playerHP;
            playerData.transform.position = gameData.playerPosition;
            Enemy.enemyDeaths = gameData.enemiesKilled;
        }
        else
        {
            timer += Time.deltaTime;
            LoadFail.SetActive(true);
        }
    }
    IEnumerator SavingCoroutine()
    {
        SavingDiskette.SetActive(true);
        yield return new WaitForSeconds(3);
        SavingDiskette.SetActive(false);
    }
    
}

[System.Serializable]
public class GameData
{
    public Vector2 playerPosition;
    public int playerHP;
    public int enemiesKilled;
}