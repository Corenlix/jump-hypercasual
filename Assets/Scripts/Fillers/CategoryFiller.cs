using System;
using Player;
using UnityEngine;

namespace Fillers
{
    public class CategoryFiller : MonoBehaviour, ICategoryFillable
    {
        [SerializeField] private Filler[] fillers;
        [SerializeField] private ColorCategory defaultFillCategory;
    
        private FillColors _fillColors;

        public void Fill(ColorCategory colorCategory)
        {
            foreach (var filler in fillers)
            {
                filler.Fill(_fillColors.GetColor(colorCategory));
            }
        }

        public void FillDefault()
        {
            Fill(defaultFillCategory);
        }
    
        public void SetFillColors(FillColors colors)
        {
            _fillColors = colors;
        }

        public void SetDefaultFillCategory(ColorCategory category)
        {
            defaultFillCategory = category;
        }

        private void OnEnable()
        {
            if (!_fillColors)
                _fillColors = FindObjectOfType<FillColors>();
        }

        private void Start()
        {
            FillDefault();
        }
    }
}
