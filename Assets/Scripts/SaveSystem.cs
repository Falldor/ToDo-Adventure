using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    /*
    public static void Salvar(Data save, string filemName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + filemName + ".sv";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, save);
        stream.Close();
    }

    public static Data Load(string filemName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/"+ filemName +".sv";
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);

            Data save = formatter.Deserialize(stream) as Data;
            stream.Close();
            return save;
        }else{ return null; }
    }*/
}
