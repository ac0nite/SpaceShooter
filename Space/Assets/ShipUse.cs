using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum StateShipLock
{
    SELECT,
    UNSELECT,
    LOCK
};

public class ShipUse : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _select = null;
    [SerializeField] private GameObject _unselect = null;
    [SerializeField] private GameObject _lock = null;
    [SerializeField] private StateShipLock _isLock = StateShipLock.UNSELECT;

    
    public Action<ShipUse> EventClickSelect;

    private ShipsManagment _managment = null;

    public StateShipLock IsLock
    {
        get { return _isLock; }
        set
        {
            _isLock = value;
            ChangeLock(_isLock);
        }
    }

    private void Awake()
    {
        ChangeLock(_isLock);
        _managment = GetComponentInParent<ShipsManagment>();
    }

    private void Start()
    {
        _managment.UnSelectEvent += OnUnSelect;
    }

    private void OnDestroy()
    {
        _managment.UnSelectEvent -= OnUnSelect;
    }

    private void ChangeLock(StateShipLock state)
    {
        _select.SetActive(false);
        _unselect.SetActive(false);
        _lock.SetActive(false);

        switch (_isLock)
        {
            case StateShipLock.SELECT:
                _select.SetActive(true);
                break;
            case StateShipLock.UNSELECT:
                _unselect.SetActive(true);
                break;
            case StateShipLock.LOCK:
                _lock.SetActive(true);
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log($"OnPointerClick IsLock: {IsLock}");
        EventClickSelect?.Invoke(this);
    }

    private void OnUnSelect()
    {
        Debug.Log("OnUnSelect");
        if (_isLock != StateShipLock.LOCK && _isLock == StateShipLock.SELECT)
        {
            IsLock = StateShipLock.UNSELECT;
        }
            
    }
}
