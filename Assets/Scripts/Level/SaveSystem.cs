using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Level
{
    public class SaveSystem : MonoBehaviour
    {
        private string _savePath;

        private void Awake()
        {
            _savePath = Application.persistentDataPath + "/save.me";
        }

        public void Save(SaveData data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using var stream = new FileStream(_savePath, FileMode.Create);
            formatter.Serialize(stream, data);
        }
        
        public SaveData Load()
        {
            if (File.Exists(_savePath))
            {
                var formatter = new BinaryFormatter();
                using var stream = new FileStream(_savePath, FileMode.Open);
                var data = formatter.Deserialize(stream) as SaveData;
                if (data == null)
                    return GenerateDefaultSaveData();
                
                return data;
            }

            return GenerateDefaultSaveData();
        }

        private SaveData GenerateDefaultSaveData()
        {
            return new SaveData(1, 0);
        }
    }
}
