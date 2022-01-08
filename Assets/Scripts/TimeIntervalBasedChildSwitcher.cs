using UnityEngine;

public class TimeIntervalBasedChildSwitcher : TimeIntervalListener
{
    [SerializeField] private GameObject inIntervalChild;
    [SerializeField] private GameObject outOfIntervalChild;

    private void Start()
    {
        inIntervalChild.SetActive(false);
        outOfIntervalChild.SetActive(false);
    }

    protected override void OnEnterTimeInterval()
    {
        inIntervalChild.SetActive(true);
        outOfIntervalChild.SetActive(false);
    }

    protected override void OnExitTimeInterval()
    {
        inIntervalChild.SetActive(false);
        outOfIntervalChild.SetActive(true);
    }
}