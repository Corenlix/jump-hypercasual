using TMPro;
using UnityEngine;

namespace UI
{
    public class RecordScoreView : MonoBehaviour
    {
        [SerializeField] private PlayerScore playerScore;
        [SerializeField] private TextMeshProUGUI recordText;
        [SerializeField] private string format = "Best: {0}";
    
        private void OnRecordChanged(int newRecord)
        {
            recordText.text = string.Format(format, newRecord.ToString());
        }

        private void OnEnable()
        {
            playerScore.RecordScoreChanged += OnRecordChanged;
        }

        private void OnDisable()
        {
            playerScore.RecordScoreChanged -= OnRecordChanged;
        }
    }
}
