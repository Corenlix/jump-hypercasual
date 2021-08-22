using System;
using Level;
using UnityEngine;

public class PlayerScore : PlayerObserver
{
    public event Action<int, int> ScoreChanged;
    public event Action<int> RecordScoreChanged;
    
    [SerializeField] private GameState gameState;
    private int _scorePerPlatform = 1;
    
    private int _currentScore;
    private int _recordScore;
    private int _modifier = 1;
    
    private void OnPlayerExplodedPlatform()
    {
        int scoreDelta = _scorePerPlatform * _modifier;
        _currentScore += scoreDelta;
        ScoreChanged?.Invoke(scoreDelta, _currentScore);
        
        _modifier += 1;

        if (_currentScore > _recordScore)
        {
            _recordScore = _currentScore;
            gameState.UpdateRecord(_recordScore);
            RecordScoreChanged?.Invoke(_recordScore);
        }
    }

    private void OnPlayerJumped(Transform fromPlatform)
    {
        _modifier = 1;
    }

    private void OnGameLoaded(SaveData saveData)
    {
        _recordScore = saveData.ScoreRecord;
        _scorePerPlatform = saveData.Level;
        RecordScoreChanged?.Invoke(_recordScore);
    }
    
    protected override void OnEnable()
    {
        base.OnEnable();
        gameState.GameLoaded += OnGameLoaded;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        gameState.GameLoaded -= OnGameLoaded;
    }

    protected override void OnStartedObservingPlayer(Player.Player player)
    {
        player.Jumped += OnPlayerJumped;
        player.Exploded += OnPlayerExplodedPlatform;
    }

    protected override void OnFinishedObservingPlayer(Player.Player player)
    {
        player.Jumped -= OnPlayerJumped;
        player.Exploded -= OnPlayerExplodedPlatform;
    }
}
