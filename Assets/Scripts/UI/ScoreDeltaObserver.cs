using UnityEngine;

namespace UI
{
    public class ScoreDeltaObserver : ScoreDeltaViewsPool
    {
        [SerializeField] private PlayerScore playerScore;

        private void OnScoreChanged(int deltaScore, int score)
        {
            CreateView(deltaScore);
        }
    
        private void OnEnable()
        {
            playerScore.ScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            playerScore.ScoreChanged -= OnScoreChanged;
        }
    }
}
