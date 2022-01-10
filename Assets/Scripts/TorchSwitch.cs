using UnityEngine;

[ExecuteAlways]
public class TorchSwitch : MonoBehaviour
{
    [SerializeField] private bool on;

    private ParticleSystem[] _torchFires;
    private Light[] _torchLights;
    private AudioSource[] _torchSounds;

    private void Start()
    {
        _torchFires = GetComponentsInChildren<ParticleSystem>();
        _torchLights = GetComponentsInChildren<Light>();
        _torchSounds = GetComponentsInChildren<AudioSource>();
        UpdateTorches();
    }

    private void UpdateTorches()
    {
        if (on)
        {
            foreach (var fire in _torchFires)
                fire.Play();
            if (Application.isPlaying)
                foreach (var sound in _torchSounds)
                    sound.Play();
        }
        else
        {
            foreach (var fire in _torchFires)
                fire.Stop();
            foreach (var sound in _torchSounds)
                sound.Stop();
        }

        foreach (var torchLight in _torchLights)
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
        else
        {
            _torchFires = GetComponentsInChildren<ParticleSystem>();
            _torchLights = GetComponentsInChildren<Light>();
            _torchSounds = GetComponentsInChildren<AudioSource>();
            UpdateTorches();
        }
    }
}