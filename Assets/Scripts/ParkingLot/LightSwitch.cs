using System.Linq;
using ParkingLot;
using UnityEngine;

[ExecuteAlways]
public class LightSwitch : MonoBehaviour
{
    [SerializeField] private bool on;

    private Light[] _lights;
    private GameObject[] _emissionCylinders;

    private void Start()
    {
        _emissionCylinders = GetComponentsInChildren<StreetlightEmission>().Select(x => x.gameObject).ToArray();
        _lights = GetComponentsInChildren<Light>();
        UpdateLights();
    }

    private void UpdateLights()
    {
        foreach (var torchLight in _lights)
            torchLight.enabled = on;
        foreach (var emissionCylinder in _emissionCylinders)
            emissionCylinder.SetActive(on);
    }

    private void Update()
    {
        if (Application.isPlaying)
        {
            if (!Input.GetButtonDown("SwitchLights")) return;
            on = !on;
            UpdateLights();
        }
        else
        {
            _lights = GetComponentsInChildren<Light>();
            UpdateLights();
        }
    }
}