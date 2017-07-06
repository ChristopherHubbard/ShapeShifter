using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    public static class SaveLoad
    {
        public static void Save()
        {
            BinaryFormatter binaryformat = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/savedGames.shpd");
            binaryformat.Serialize(file, UnlockedLevels.Unlocked);
            file.Close();
        }

        public static void Load()
        {
            if (File.Exists(Application.persistentDataPath + "/savedGames.shpd"))
            {
                BinaryFormatter binaryformat = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/savedGames.shpd", FileMode.Open);
                UnlockedLevels.Unlocked = (Dictionary<string, bool>)binaryformat.Deserialize(file);
                file.Close();
            }
        }
    }
}
