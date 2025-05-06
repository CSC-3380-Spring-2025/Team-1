using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

   private GameData gameData;

   private List<IDataPersistence> dataPersistenceObjects;

   private FileDataHandler data Handler;

   public static DataPersistenceManager instance {get; private set;}

   private void Awake()
   {
    if (instance != null)
    {
        Debug.LogError("More than one Data Persistence Manger in scene.");
    }
    instance = this;
   }

   private void Start()
   {
    this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    this.dataPersistenceObjects = FindAllDataPersistenceObjects();

    LoadGame();
   }

   public void NewGame()
   {
    this.gameData = new GameData();
   }

   public void LoadGame()
   {

    this.gameData = dataHandler.Load();


    if (this.gameData == null)
    {
        Debug.Log("no data was found. Initializing data to defaults.");
        NewGame();
    }

    foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
    {
        dataPersistenceObj.LoadData(gameData);
    }

   }

   public void SaveGame()
   {
    foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
    {
        dataPersistenceObj.SaveData(ref gameData);
    }
    Debug.Log("Saved data");

    dataHandler.Save(gameData);


   }

   private void OnQuit()
   {
    SaveGmae();
   }

   private List<IDataPersistence> FindAllDataPersistenceObjects()
   {
    IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

    return new List<IDataPersistence>(dataPersistenceObjects);
   }
}
