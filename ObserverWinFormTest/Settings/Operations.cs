using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ObserverWinFormTest.Settings
{
    public class Operations
    {
        public void Save<T>(List<T> tuples, Action<string> setSettingValue)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, tuples);
                ms.Position = 0;
                byte[] buffer = new byte[(int)ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                //Properties.Settings.Default.AssetTypes = Convert.ToBase64String(buffer);
                setSettingValue(Convert.ToBase64String(buffer));
                Properties.Settings.Default.Save();
            }
        }

        public List<T> Load<T>(string setting)
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(setting)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (List<T>)bf.Deserialize(ms);
            }
        }
    }
}
