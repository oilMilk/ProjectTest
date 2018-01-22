using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataSave
{
    private string name;
    private string age;

    public void SetUserData(string name,string age)
    {
        this.name = name;
        this.age = age;
    }

    public string GetName()
    {
        return name;
    }

    public string GetAge()
    {
        return age;
    }

}
