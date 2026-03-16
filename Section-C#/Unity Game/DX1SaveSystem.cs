using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


/*
DX1 NAMESAKE SAVE SYSTEM MAIN HANDLE

v1.0.2
01/05/2024
*/

public static class SaveSystem
{
    public static void SavePlayer(HPPlayer player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "playerc.word";

        FileStream stream = new FileStream(path, FileMode.Create);

        UserData data = new UserData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static UserData LoadPlayer(){
        string path = Application.persistentDataPath + "playerc.word";
        if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            UserData data = formatter.Deserialize(stream) as UserData;
            stream.Close();


            return data;
        }
        else{
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}


