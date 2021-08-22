using System;
using System.Collections.Generic;
using System.Linq;
using Fillers;
using Platform;
using UnityEngine;
using UnityEngine.Serialization;

namespace Level
{
    [CreateAssetMenu]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private PlatformCreator platformCreator;
        [SerializeField] private BonusCreator bonusCreator;
        [SerializeField] private float bonusSpawnChance;
        [SerializeField] private List<ColorDictionaryElement> colors;
        [SerializeField] private int platformsCount;
        [SerializeField] private float distanceBetweenPlatforms;
        [SerializeField] private PipeCreator pipeCreator;

        public PipeCreator PipeCreator => pipeCreator;              
        public PlatformCreator PlatformCreator => platformCreator;
        public BonusCreator BonusCreator => bonusCreator;           
        public float BonusSpawnChance => bonusSpawnChance;
        public List<ColorDictionaryElement> Colors => colors.ToList();
        public int PlatformsCount => platformsCount;             
        public float DistanceBetweenPlatforms => distanceBetweenPlatforms; 
    }

    [Serializable]
    public class ColorDictionaryElement
    {
        public ColorCategory category;
        public Color color;
    }
}
