using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void SaveRecordPlayer()
    {
        string path = Application.persistentDataPath + Helper.SaveFiles[Helper.TagName.PlayerSave];
        PlayerData playerData = new PlayerData();
        BinaryFormatter formatter = new BinaryFormatter();

        if (File.Exists(path))
        {
            (string, int)[] newData = LoadRecordPlayer().Concat(new (string, int)[] { playerData.Data() }).ToArray();
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(stream, newData);
                stream.Close();
            }
        }
        else
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(stream, new (string,int)[] { playerData.Data() });
                stream.Close();
            }
        }

    }

    public static (string, int)[] LoadRecordPlayer()
    {
        string path = Application.persistentDataPath + Helper.SaveFiles[Helper.TagName.PlayerSave];
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            (string, int)[] data = formatter.Deserialize(stream) as (string, int)[];
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found: " + path);
            return null;
        }
    }
}
