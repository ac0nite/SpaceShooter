using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIObjectManager : MonoBehaviour
{
    [SerializeField] protected GameObject _content = null;
    public Action UnSelectEvent;
    [SerializeField] public Text Name = null;
}
