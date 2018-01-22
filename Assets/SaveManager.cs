using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour {

    public InputField inputName;
    public InputField inputAge;
    public Dropdown dropDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveData()
    {
        int value = dropDown.value;
        switch(value)
        {
            case 0:     //Binary
                SaveByBinary();
                break;
            case 1:     //XML
                SaveByXML();
                break;
            case 2:     //JSON
                SaveByJson();
                break;
        }
    }

    public void LoadData()
    {
        int value = dropDown.value;
        switch (value)
        {
            case 0:     //Binary
                LoadByBinary();
                break;
            case 1:     //XML
                LoadByXML();
                break;
            case 2:     //JSON
                LoadByJson();
                break;
        }
    }

    private void SaveByBinary()
    {
        DataSave save = CreateDataSave();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.dataPath + "/StreamingFile" + "/data.ga");
        bf.Serialize(fileStream, save);
        fileStream.Close();
    }

    private void SaveByXML()
    {
        DataSave save = CreateDataSave();


    }

    private void SaveByJson()
    {
        DataSave save = CreateDataSave();


    }

    private void LoadByBinary()
    {
        //反序列化
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Open(Application.dataPath + "/StreamingFile" + "/data.ga", FileMode.Open);
        DataSave save = (DataSave)bf.Deserialize(fileStream);
        fileStream.Close();

        UseDataSave(save);
    }

    private void LoadByXML()
    {

    }

    private void LoadByJson()
    {

    }

    private DataSave CreateDataSave()
    {
        DataSave save = new DataSave();
        string name = inputName.text;
        string age = inputAge.text;
        save.SetUserData(name, age);
        return save;
    }

    private void UseDataSave(DataSave save)
    {
        inputName.text = save.GetName();
        inputAge.text = save.GetAge();
    }
}
