using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsManagment : MonoBehaviour
{
    [SerializeField] private GameObject _contentShips = null;
    public Action UnSelectEvent;
    private void Start()
    {
        foreach (ShipUse ship in GameManager.Instance.ShipsPay)
        {
            ShipUse s = Instantiate(ship, _contentShips.transform, _contentShips);
            s.EventClickSelect += ShopClickSelect;
        }
    }

    private void ShopClickSelect(ShipUse select)
    {
        if (select.IsLock == StateShipLock.UNSELECT)
        {
            UnSelectEvent?.Invoke();
            select.IsLock = StateShipLock.SELECT;
        }
    }
}
