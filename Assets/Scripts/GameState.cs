using System;
using Level;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameState : MonoBehaviour
{
    public event Action<SaveData> GameLoaded;
    
    [SerializeField] private SaveSystem saveSystem;

    private static GameState _instance;
    public static GameState Instance
    {
        get
        {
            if (!_instance)
            {
                var instanceGameObject = new GameObject("GameState");
                instanceGameObject.AddComponent<GameState>();
            }

            return _instance;
        }
    }

    private SaveData _currentSaveData;
    
    private void Awake()
    {
        if (_instance)
        {
            Destroy(this);
            throw new UnityException();
        }

        _instance = this;
    }

    private void Start()
    {
        StartPlaying();
    }
    
    private void StartPlaying()
    {
        _currentSaveData = saveSystem.Load();
        GameLoaded?.Invoke((SaveData)_currentSaveData.Clone());
    }

    public void UpdateRecord(int newRecord)
    {
        _currentSaveData.ScoreRecord = newRecord;
    }
    
    public void Pass()
    {
        _currentSaveData.Level++;
        saveSystem.Save(_currentSaveData);
        LoadPlayScene();
    }

    public void Lose()
    {
        saveSystem.Save(_currentSaveData);
        LoadPlayScene();
    }

    private void LoadPlayScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    enum State
    {
        Playing,
        WaitingForRestart,
    }
}