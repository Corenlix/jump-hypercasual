using UnityEngine;

namespace Level
{
    [CreateAssetMenu]
    public class PlayerCreator : ScriptableObject
    {
        [SerializeField] private Player.Player player;

        public Player.Player Create(Vector3 position, Transform parent = null)
        {
            return Instantiate(player, position, Quaternion.identity, parent);
        }
    }
}