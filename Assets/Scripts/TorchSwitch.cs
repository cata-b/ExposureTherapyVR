using UnityEngine;

[ExecuteAlways]
public class TorchSwitch : MonoBehaviour
{
    [SerializeField] private bool on;

    private ParticleSystem[] torchFires;
    private Light[] torchLights;

    private void Start()
    {
        torchFires = GetComponentsInChildren<ParticleSystem>();
        torchLights = GetComponentsInChildren<Light>();
        UpdateTorches();
    }
    
    private void UpdateTorches()
    {
        if (on)
            foreach (var fire in torchFires)
                fire.Play();
        else
            foreach (var fire in torchFires)
                fire.Stop();
        foreach (var torchLight in torchLights)
            torchLight.enabled = on;
    }

    private void Update()
    {
        if (Application.isPlaying)
        {
            if (!Input.GetButtonDown("SwitchLights")) return;
            on = !on;
            UpdateTorches();
        }
        else UpdateTorches();
    }
}