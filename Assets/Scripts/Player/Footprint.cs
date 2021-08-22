using Fillers;
using UnityEngine;

namespace Player
{
    public class Footprint : MonoBehaviour, ICategoryFillable
    {
        [SerializeField] private CategoryFiller filler;
        
        public void Fill(ColorCategory colorCategory)
        {
            filler.Fill(colorCategory);
        }
    }
}
