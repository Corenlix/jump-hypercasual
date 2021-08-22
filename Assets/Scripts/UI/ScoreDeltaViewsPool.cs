using UnityEngine;

namespace UI
{
    public class ScoreDeltaViewsPool : MonoBehaviour
    {
        [SerializeField] private int viewsMaxCount;
        [SerializeField] private ScoreDeltaView viewTemplate;
        [SerializeField] private RectTransform viewsParent;
    
        private ScoreDeltaView[] _views;
        private int _currentViewIndex;
    
        protected void CreateView(int score)
        {
            _views[_currentViewIndex].Activate(score, viewsParent.position);
            _currentViewIndex = (_currentViewIndex + 1) % _views.Length;
        }

        private void Init()
        {
            _views = new ScoreDeltaView[viewsMaxCount];
            for (int i = 0; i < viewsMaxCount; i++)
            {
                _views[i] = Instantiate(viewTemplate, viewsParent);
            }
        }
    
        private void Awake()
        {
            Init();
        }
    }
}
