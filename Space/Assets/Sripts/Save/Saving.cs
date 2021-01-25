using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Saving : SingletoneGameObject<Saving>
{
    [SerializeField] private string file = "SaveData.txt";
    public Data data { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        data = new Data();
        data.Clear();
    }

    public void Append(UInt64 coins, UInt16 stage)
    {
        data.Coins = coins;
        data.CurrentStage = stage;
    }

    public void Append(UInt64 highescore)
    {
        data.HighScore = highescore;
    }

    public void UpdateShips(GameObject content)
    {
        data.Ships.Clear();
        var ships = content.GetComponentsInChildren<UIShipUse>().ToList();
        Debug.Log($"Count ships: {ships.Count}");
        foreach (UIShipUse ship in ships)
        {
            data.Ships.Add(new Ship(ship.name, ship.IsLock, ship.IsSelect));
        }
    }
    
    public void UpdateStage(GameObject content)
    {
        data.Ships.Clear();
        var ships = content.GetComponentsInChildren<UIStageUse>().ToList();
        Debug.Log($"Count ships: {ships.Count}");
        foreach (UIStageUse ship in ships)
        {
            data.Ships.Add(new Ship(ship.name, ship.IsLock, ship.IsSelect));
        }
    }

    public void Write()
    {
        string content = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/" + file;
        Debug.Log($"Path Save: {path}");
        File.Delete(path);
        File.WriteAllText(path, content);
    }
    
    public bool Read()
    {
        data.Clear();
        string path = Application.persistentDataPath + "/" + file;
        
        if (File.Exists(path))
        {
            string content = File.ReadAllText(path);
            data = JsonUtility.FromJson<Data>(content);
            return true;
        }
        else
        {
            Debug.Log($"File not found {path}");
        }

        return false;
    }
}
