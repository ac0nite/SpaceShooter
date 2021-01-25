using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Data
{
    public UInt64 Coins = 0;
    public UInt64 HighScore = 0;
    public UInt16 CurrentStage = 1;
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
}

[System.Serializable]
public class Ship
{
    public string Name = "";
    public StateLock Lock = StateLock.LOCK;
    public StateSelect Select = StateSelect.UNSELECT;

    public Ship(string name, StateLock _lock, StateSelect select)
    {
        Name = name;
        Lock = _lock;
        Select = select;
    }
}

[System.Serializable]
public class Stage
{
    public UInt64 Score = 0;
    public StateLock Lock = StateLock.LOCK;
    public StateSelect Select = StateSelect.UNSELECT;

    public Stage(UInt64 score, StateLock _lock, StateSelect select)
    {
        Score = score;
        Lock = _lock;
        Select = select;
    }
}
