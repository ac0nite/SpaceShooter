using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIObjectManager : MonoBehaviour
{
    [SerializeField] public GameObject Content = null;
    public Action UnSelectEvent;
    [SerializeField] public Text Name = null;
}
