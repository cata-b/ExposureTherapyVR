using System;
using UnityEngine;

public abstract class TimeIntervalListener : TimeOfDayListener
{
    [SerializeField] private float startHour;
    [SerializeField] private float endHour;

    private bool? _inInterval;
    
    public override void UpdateTime(float time01)
    {
        time01 *= 24;
        var currentInInterval = time01 >= startHour && time01 <= endHour;
        
        if ((_inInterval == null || !(bool)_inInterval) && currentInInterval)
            OnEnterTimeInterval();
        else if ((_inInterval == null || (bool)_inInterval) && !currentInInterval)
            OnExitTimeInterval();
        _inInterval = currentInInterval;
    }

    protected abstract void OnEnterTimeInterval();
    protected abstract void OnExitTimeInterval();
}