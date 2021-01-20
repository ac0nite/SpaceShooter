using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShipsManagment : UIObjectManager
{
    [SerializeField] private List<UIShipUse> _shipPrefabs = null;
    public UIShipUse SelectShip = null;
    public Action<UIShipUse> EventSelectShip;

    private void Awake()
    {
        foreach (UIShipUse ship in _shipPrefabs)
        {
            UIShipUse s = Instantiate(ship, Vector3.zero, Quaternion.identity, _content.transform);
            s.EventClickSelect += ClickSelect;
        }

        //Ships[0].IsLock = StateLock.SELECT;
    }

    private void ClickSelect(ObjectUseBase select)
    {
        if (select.IsSelect == StateSelect.UNSELECT)
        {
            UnSelectEvent?.Invoke();
            select.IsSelect = StateSelect.SELECT;
            SelectShip = (UIShipUse) select;
            EventSelectShip?.Invoke(SelectShip);
        }
    }

    private void OnDestroy()
    {
        var ships = _content.GetComponentsInChildren<UIShipUse>().ToList();
        foreach (UIShipUse s in ships)
        {
            s.EventClickSelect -= ClickSelect;
        }
    }
}
