using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagesManagment : UIObjectManager
{
    [SerializeField] private List<UIStageUse> _stagPrefabs = null;
    public List<UIStageUse> Stages = new List<UIStageUse>();
    public UIStageUse SelectStage = null;

    private void Awake()
    {
        foreach (UIStageUse stage in _stagPrefabs)
        {
            UIStageUse s = Instantiate(stage, Vector3.zero, Quaternion.identity, Content.transform);
            //UIStageUse s = Instantiate(stage, _content.transform, _content);
            s.EventClickSelect += ShopClickSelect;
            Stages.Add(s);
        }

       // Stages[0].IsLock = StateLock.SELECT;
    }

    private void ShopClickSelect(ObjectUseBase select)
    {
        if (select.IsSelect == StateSelect.UNSELECT)
        {
            UnSelectEvent?.Invoke();
            select.IsSelect = StateSelect.SELECT;
            SelectStage = (UIStageUse)select;
        }
    }

    private void OnDestroy()
    {
        foreach (UIStageUse s in Stages)
        {
            s.EventClickSelect -= ShopClickSelect;
        }
    }
}
