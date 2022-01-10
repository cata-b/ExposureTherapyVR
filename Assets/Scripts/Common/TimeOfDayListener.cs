using UnityEngine;

public abstract class TimeOfDayListener : MonoBehaviour
{
    // Receives the time of day as a value between 0 and 1,
    // 0 meaning after 0:00, 1 meaning before 0:00
    public abstract void UpdateTime(float time01);
}