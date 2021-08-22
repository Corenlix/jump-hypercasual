using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreDeltaView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI deltaText;
        [SerializeField] private float tweenDuration = 1.5f;
        [SerializeField] private Vector3 tweenTranslate;
    
        private Sequence _currentSequence;
    
        public void Activate(int deltaScore, Vector3 position)
        {
            _currentSequence?.Kill();
            transform.position = position;
            deltaText.DOFade(1, 0);
        
            deltaText.text = $"+{deltaScore}";
            _currentSequence = DOTween.Sequence();
            _currentSequence.Append(transform.DOMove(transform.position + tweenTranslate, tweenDuration));
            _currentSequence.Join(deltaText.DOFade(0, tweenDuration));
        }

        private void Awake()
        {
            deltaText.DOFade(0, 0);
        }
    }
}
