using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Data
{
    public int Coins = 0;
    public int HighScore = 0;
    public int CurrentStage = 0;
    public int CurrentShip = 0;
    public List<Ship> Ships = new List<Ship>();
    public List<Stage> Stages = new List<Stage>();
    
    public void Clear()
    {
        Coins = 0;
        HighScore = 0;
        CurrentStage = 1;
        Ships.Clear();
        Stages.Clear();
    }

    public void NextStage()
    {
        var index = Stages.FindIndex(stage => stage.Select == StateSelect.SELECT);
        Stages[index].Select = StateSelect.UNSELECT;
        index = (index + 1) % Stages.Count;
        Stages[index].Select = StateSelect.SELECT;
        Stages[index].Lock = StateLock.UNLOCK;
        CurrentStage = index;
    }
}

[System.Serializable]
public class Ship
{
    public string Name = "";
    public StateLock Lock = StateLock.LOCK;
    public StateSelect Select = StateSelect.UNSELECT;
    public int Cost = 0;

    public Ship(string name, StateLock _lock, StateSelect select, int cost)
    {
        Name = name;
        Lock = _lock;
        Select = select;
        Cost = cost;
    }
}

[System.Serializable]
public class Stage
{
    public string Name = "";
    public UInt32 Score = 0;
    public StateLock Lock = StateLock.LOCK;
    public StateSelect Select = StateSelect.UNSELECT;

    public Stage(string name, UInt32 score, StateLock _lock, StateSelect select)
    {
        Name = name;
        Score = score;
        Lock = _lock;
        Select = select;
    }
}
