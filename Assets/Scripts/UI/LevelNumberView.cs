using Level;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LevelNumberView : MonoBehaviour
    {
        [SerializeField] private GameState gameState;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private string format = "Level {0}";
        
        private void UpdateText(int level)
        {
            levelText.text = string.Format(format, level);
        }

        private void OnGameLoaded(SaveData saveData)
        {
            UpdateText(saveData.Level);
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
}
