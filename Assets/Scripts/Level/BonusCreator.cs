using Bonuses;
using UnityEngine;

namespace Level
{
    [CreateAssetMenu]
    public class BonusCreator : ScriptableObject
    {
        [SerializeField] private Bonus[] bonusTemplates;
        public Bonus Create(Vector3 position, Transform parent)
        {
            var bonusTemplate = bonusTemplates[Random.Range(0, bonusTemplates.Length)];
            Bonus createdBonus = Instantiate(bonusTemplate, position, Quaternion.identity);
            createdBonus.transform.SetParent(parent);
            return createdBonus;
        }
    }
}
