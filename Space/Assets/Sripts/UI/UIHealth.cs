using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 10;
    [SerializeField] private Image _healthPrefab = null;
    private List<Image> _currentHealth = new List<Image>();

    void Start()
    {
        Debug.Log($"Add(_maxHealth)");
        Add(_maxHealth);
    }

    public int UiHealth
    {
        set
        {
            if (_currentHealth.Count > value)
                Remove(_currentHealth.Count - value);
            else
                Add(value - _currentHealth.Count);
        }
    }

    private void Add(int count)
    {
        if(count > _maxHealth) return;

        for (int i = 0; i < count; i++)
        {
            _currentHealth.Add(Instantiate(_healthPrefab, Vector3.zero, Quaternion.identity, transform));
        }
    }

    private void Remove(int count)
    {
        var _count = (count > _currentHealth.Count) ? _currentHealth.Count : count;

        for (int i = 0; i < _count; i++)
        {
            Destroy(_currentHealth[i].gameObject);
            _currentHealth.RemoveAt(i);
        }
    }

    public void Change(int health)
    {
        int new_count = Mathf.Clamp(_currentHealth.Count + health, 0, _maxHealth);

        if(health < 0) 
            _currentHealth.RemoveRange(0, _currentHealth.Count - new_count);
        else
            Add(_currentHealth.Count - new_count);
    }
}
