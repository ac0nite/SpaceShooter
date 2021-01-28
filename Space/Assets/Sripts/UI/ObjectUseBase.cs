using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum StateSelect
{
    SELECT,
    UNSELECT
};

public enum StateLock
{
    LOCK,
    UNLOCK
};

public class ObjectUseBase : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _select = null;
    [SerializeField] private GameObject _unselect = null;
    [SerializeField] private GameObject _lock = null;

    [SerializeField] private StateLock _isLock = StateLock.LOCK;
    [SerializeField] private StateSelect _isSelect = StateSelect.UNSELECT;

    [SerializeField] public string Name = "no name";
    private UIObjectManager _managment = null;

    public Action<ObjectUseBase> EventClickSelect;

    public StateLock IsLock
    {
        get { return _isLock; }
        set
        {
            _isLock = value;
            if (_isLock == StateLock.LOCK)
                _lock.SetActive(true);
            else
                _lock.SetActive(false);
        }
    }

    public StateSelect IsSelect
    {
        get { return _isSelect; }
        set
        {
            _isSelect = value;

            _select.SetActive(false);
            _unselect.SetActive(false);

            if (_isSelect == StateSelect.SELECT)
            {
                _select.SetActive(true);
                _managment.Name.text = Name;
            }
            else
            {
                _unselect.SetActive(true);
            }
        }
    }

    protected virtual void Awake()
    {
        IsSelect = _isSelect;
        IsLock = _isLock;

        _managment = GetComponentInParent<UIObjectManager>();
    }

    protected virtual void Start()
    {
        _managment.UnSelectEvent += OnUnSelect;
    }

    protected virtual void OnDestroy()
    {
        _managment.UnSelectEvent -= OnUnSelect;
    }

    //private void ChangeLock(StateLock state)
    //{
    //    _select.SetActive(false);
    //    _unselect.SetActive(false);
    //    _lock.SetActive(false);

    //    switch (_isLock)
    //    {
    //        case StateLock.SELECT:
    //            _select.SetActive(true);
    //            _managment.Name.text = _name;
    //            break;
    //        case StateLock.UNSELECT:
    //            _unselect.SetActive(true);
    //            break;
    //        case StateLock.LOCK:
    //            _lock.SetActive(true);
    //            break;
    //    }
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log($"OnPointerClick IsLock: {IsLock}");
        EventClickSelect?.Invoke(this);
    }

    private void OnUnSelect()
    {
        //Debug.Log("OnUnSelect");
        
        if (_isSelect == StateSelect.SELECT)
            IsSelect = StateSelect.UNSELECT;
    }
}
