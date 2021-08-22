using System;
using System.Collections.Generic;
using Fillers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level
{
    public class LevelGenerator : MonoBehaviour
    {
        public event Action<Player.Player> PlayerCreated;
        
        [SerializeField] private FillColors fillColors;
        [SerializeField] private float pipeAdditiveHeight = 5f;
        [SerializeField] private Vector3 startPlayerPosition = new Vector3(2, 1.7f, 0);
        [SerializeField] private PlayerCreator playerCreator;

        private LevelData _currentLevelData;

        public void Generate(LevelData levelData)
        {
            _currentLevelData = levelData;
            float levelHeight = levelData.DistanceBetweenPlatforms * levelData.PlatformsCount;
            InitFillColors();
            
            Pipe createdPipe = levelData.PipeCreator.Create(- Vector3.up * levelHeight / 2f, levelHeight, pipeAdditiveHeight);
            SpawnPlatformsWithBonuses(createdPipe.transform, levelHeight);
            Player.Player player = playerCreator.Create(startPlayerPosition);
            PlayerCreated?.Invoke(player);
        }

        private void SpawnPlatformsWithBonuses(Transform parent, float levelHeight)
        {
            var platformCreator = _currentLevelData.PlatformCreator;
            platformCreator.Init(parent);
            platformCreator.CreateSafetyPlatform(Vector3.zero);
            platformCreator.CreateFinalPlatform(-Vector3.up * levelHeight);

            float bonusSpawnRadius = new Vector2(startPlayerPosition.x, startPlayerPosition.z).magnitude;
            
            for (int i = 1; i < _currentLevelData.PlatformsCount - 1; i++)
            {
                float platformY = - i * _currentLevelData.DistanceBetweenPlatforms;
                Vector3 platformPosition = Vector3.up * platformY;
                _currentLevelData.PlatformCreator.Create(platformPosition);
                SpawnBonusOnCircle(platformPosition, bonusSpawnRadius, parent);
            }
        }

        private void SpawnBonusOnCircle(Vector3 position, float spawnRadius, Transform parent)
        {
            if (Random.Range(0, 100f) <= _currentLevelData.BonusSpawnChance)
            {
                Vector3 pointOnCircle = (Vector3) Random.insideUnitCircle.normalized * spawnRadius;
                pointOnCircle = new Vector3(pointOnCircle.x,  _currentLevelData.DistanceBetweenPlatforms * Random.Range(0.25f, 0.75f), pointOnCircle.y);
                _currentLevelData.BonusCreator.Create(position + pointOnCircle, parent);
            }

        }

        private void InitFillColors()
        {
            foreach (var color in _currentLevelData.Colors)
            {
                fillColors.SetColor(color.category, color.color);
            }
        }
    }
}
