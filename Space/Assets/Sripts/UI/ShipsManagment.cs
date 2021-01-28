using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

public class ShipsManagment : UIObjectManager
{
    [SerializeField] private List<UIShipUse> _shipPrefabs = null;
    public UIShipUse SelectShip = null;
    public Action<UIShipUse> EventSelectShip;

    private void Start()
    {
        foreach (UIShipUse shipPrefab in _shipPrefabs)
        {
            UIShipUse ship = Instantiate(shipPrefab, Vector3.zero, Quaternion.identity, Content.transform);
            var config = Saving.Instance.data.Ships.Find(conf => conf.Name == ship.Name);
            if (config != null)
            {
                ship.IsLock = config.Lock;
                ship.IsSelect = config.Select;
            }
            ship.EventClickSelect += ClickSelect;
        }

        if (Saving.Instance.data.Ships.Count == 0)
        {
            var ships = Content.GetComponentsInChildren<UIShipUse>();
            ships[0].IsSelect = StateSelect.SELECT;
            ships[0].IsLock = StateLock.UNLOCK;
        }
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
        var ships = Content.GetComponentsInChildren<UIShipUse>().ToList();
        foreach (UIShipUse s in ships)
        {
            s.EventClickSelect -= ClickSelect;
        }
    }
}
