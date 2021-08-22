using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fillers
{
    public class FillColors : MonoBehaviour
    {
        private readonly Dictionary<ColorCategory, Color> _colors = new Dictionary<ColorCategory, Color>();

        public void SetColors(Dictionary<ColorCategory, Color> colors)
        {
            foreach (var color in colors)
            {
                SetColor(color.Key, color.Value);
            }
        }

        public void SetColor(ColorCategory category, Color color)
        {
            _colors[category] = color;
        }

        public Color GetColor(ColorCategory category)
        {
            return _colors[category];
        }

        private void Awake()
        {
            foreach (ColorCategory colorCategory in Enum.GetValues(typeof(ColorCategory)))
            {
                _colors.Add(colorCategory, Color.white);
            }
        }
    }

    public enum ColorCategory
    {
        PlatformSegment,
        Killer,
        Boost,
        Player,
        Pipe,
        Background
    }
}