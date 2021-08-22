using System;

namespace Level
{
    [Serializable]
    public class SaveData : ICloneable
    {
        public int Level;
        public int ScoreRecord;

        public SaveData(int level, int scoreRecord)
        {
            Level = level;
            ScoreRecord = scoreRecord;
        }

        public object Clone()
        {
            return new SaveData(Level, ScoreRecord);
        }
    }
}
