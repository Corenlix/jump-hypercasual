using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private PlayerScore playerScore;

        private void OnScoreChanged(int deltaScore, int score)
        {
            scoreText.text = score.ToString();
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
