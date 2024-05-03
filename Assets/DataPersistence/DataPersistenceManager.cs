using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")] [SerializeField]
    private string fileName;
    [SerializeField] private bool useEncryption;
    
    private PlayerData _gameData;
    private List<IDataPersistence> _dataPersistenceObjects;
    private FileDataHandler _dataHandler;
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene.");
        }
        instance = this;
    }

    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
        this._dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        _dataPersistenceObjects = FindAllDataPersistenceObjects(); //FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this._gameData = new PlayerData();
    }
    
    public void LoadGame()
    {
        // TODO - Load any saved data from a file using the data handler
        this._gameData = _dataHandler.Load();
        
        // if no data can be loaded, initialize to a new game
        if (this._gameData== null)
        {
            Debug.Log("No data was found. Initalizing data to defaults.");
            NewGame();
        }
        
        // TODO - push the loaded data to all other scripts that need it
        foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(_gameData);
        }
        
        if (PlayerDataManager.Instance.sceneEnumType != Define.Scene.NONE && PlayerDataManager.Instance.sceneEnumType != Define.Scene.MN)
        {
            GameManager.Instance.GameFlow.LoadSceneByLoadedData(Define.FadeType.Black, PlayerDataManager.Instance.sceneEnumType); 
        }
    }  
    
    public void SaveGame()
    {
        // TODO - pass the data to other scripts so they can update it
        foreach (IDataPersistence dataPersistenceObject in _dataPersistenceObjects)
        {
            dataPersistenceObject.SaveData(ref _gameData);
        }
        Debug.Log("Saved Stage, Chapter Index = " +_gameData.sceneName +", " + _gameData.chapterIndex);

        // TODO - save that data to a file using the data handler
        _dataHandler.Save(_gameData);
    }

    public void ResetGame()
    {
        foreach (IDataPersistence dataPersistenceObject in _dataPersistenceObjects)
        {
            dataPersistenceObject.ResetData(ref _gameData);
        }
        SaveGame();
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects =
            FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        Debug.Log(dataPersistenceObjects.Count());
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
