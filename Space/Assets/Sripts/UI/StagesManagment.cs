using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StagesManagment : UIObjectManager
{
    [SerializeField] private List<UIStageUse> _stagPrefabs = null;
    public UIStageUse SelectStage = null;

    private void Awake()
    {
        UpdateManagment();
    }

    public void UpdateManagment()
    {
        foreach (UIStageUse stagePrefab in _stagPrefabs)
        {
            UIStageUse stage = Instantiate(stagePrefab, Vector3.zero, Quaternion.identity, Content.transform);
            var config = Saving.Instance.data.Stages.Find(s => s.Name == stage.Name);
            if (config != null)
            {
                stage.IsLock = config.Lock;
                stage.IsSelect = config.Select;
            }
            stage.EventClickSelect += ShopClickSelect;
        }

        //для первого запуска
        if (Saving.Instance.data.Stages.Count == 0)
        {
            var stages = Content.GetComponentsInChildren<UIStageUse>();
            stages[0].IsSelect = StateSelect.SELECT;
            stages[0].IsLock = StateLock.UNLOCK;
        }
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
        var Stages = Content.GetComponentsInChildren<UIStageUse>().ToList();
        foreach (UIStageUse s in Stages)
        {
            s.EventClickSelect -= ShopClickSelect;
        }
    }
}
