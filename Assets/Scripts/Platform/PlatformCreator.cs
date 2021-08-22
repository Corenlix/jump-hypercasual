using UnityEngine;

namespace Platform
{
   [CreateAssetMenu]
   public class PlatformCreator : ScriptableObject
   {
      [SerializeField] private Platform[] platformTemplates;
      [SerializeField] private Platform safetyPlatform;
      [SerializeField] private FinalPlatform finalPlatform;

      private Transform _platformsParent;
   
      public void Init(Transform platformsParent)
      {
         _platformsParent = platformsParent;
      }

      public Platform Create(Vector3 position)
      {
         var template = platformTemplates[Random.Range(0, platformTemplates.Length)];
         return SpawnPlatform(template, position);
      }

      public Platform CreateSafetyPlatform(Vector3 position)
      {
         return SpawnPlatform(safetyPlatform, position);
      }

      public Platform CreateFinalPlatform(Vector3 position)
      {
         return SpawnPlatform(finalPlatform, position);
      }

      private Platform SpawnPlatform(Platform platform, Vector3 position)
      {
         Platform createdPlatform = Instantiate(platform, position, Quaternion.identity);
         createdPlatform.transform.SetParent(_platformsParent);
         return createdPlatform;
      }
   }
}
