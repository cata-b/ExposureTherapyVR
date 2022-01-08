using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private LightingPreset lightingPreset;
    [SerializeField] private float lightControlSpeed = 100;
    [SerializeField] private Light sun;
    [SerializeField, Range(0, 24)] private float timeOfDay;

    private void OnValidate()
    {
        if (sun != null)
            return;
        if (RenderSettings.sun != null)
            sun = RenderSettings.sun;
        else
        {
            var lights = FindObjectsOfType<Light>();
            foreach (var l in lights)
            {
                if (l.type != LightType.Directional) continue;
                sun = l;
                return;
            }
        }
    }

    private void UpdateLighting(float time01)
    {
        RenderSettings.ambientLight = lightingPreset.ambientColor.Evaluate(time01);
        RenderSettings.fogColor = lightingPreset.fogColor.Evaluate(time01);
        if (sun != null)
        {
            sun.color = lightingPreset.directionalColor.Evaluate(time01);
            sun.transform.localRotation = Quaternion.Euler(new Vector3(time01 * 360.0f - 90.0f, 170.0f, 0));
        }
        
        foreach (var timeOfDayListener in FindObjectsOfType<TimeOfDayListener>())
            timeOfDayListener.UpdateTime(time01);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (lightingPreset == null)
            return;
        if (Application.isPlaying)
        {
            timeOfDay += Input.GetAxis("Mouse ScrollWheel") * lightControlSpeed * Time.deltaTime;
            timeOfDay %= 24;
        }
        UpdateLighting(timeOfDay / 24);
    }
}
