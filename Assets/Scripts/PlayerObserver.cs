using System.Collections.Generic;
using System.Linq;
using Level;
using UnityEngine;

public abstract class PlayerObserver : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;
    private readonly List<Player.Player> _observingPlayers = new List<Player.Player>();

    protected abstract void OnFinishedObservingPlayer(Player.Player player);
    
    protected abstract void OnStartedObservingPlayer(Player.Player player);
    
    protected virtual void OnEnable()
    {
        levelGenerator.PlayerCreated += StartObservingPlayer;
    }

    protected virtual void OnDisable()
    {
        levelGenerator.PlayerCreated -= StartObservingPlayer;
        
        foreach (var observingPlayer in _observingPlayers.ToList())
        {
            FinishObservingPlayer(observingPlayer);
        }
    }

    private void StartObservingPlayer(Player.Player player)
    {
        _observingPlayers.Add(player);
        OnStartedObservingPlayer(player);
    }
    
    private void FinishObservingPlayer(Player.Player player)
    {
        _observingPlayers.Remove(player);
        OnFinishedObservingPlayer(player);
    }
}
