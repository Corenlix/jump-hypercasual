using System;
using Level;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{

    [SerializeField] private GameState gameState;
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private LevelData[] levels;
    
    public void OnGameLoaded(SaveData saveData)
    {
        levelGenerator.Generate(levels[(saveData.Level - 1) % levels.Length]);
    }
    
    private void OnEnable()
    {
        gameState.GameLoaded += OnGameLoaded;
    }

    private void OnDisable()
    {
        gameState.GameLoaded -= OnGameLoaded;
    }
}
