using UnityEngine;

public class AudioPlayer : PlayerObserver
{
    [SerializeField] private AudioSource jumpSound;
    
    private void OnPlayerJumped(Transform obj)
    {
        jumpSound.Play();
    }
    
    protected override void OnStartedObservingPlayer(Player.Player player)
    {
        player.Jumped += OnPlayerJumped;
    }
    protected override void OnFinishedObservingPlayer(Player.Player player)
    {
        player.Jumped -= OnPlayerJumped;
    }
}
