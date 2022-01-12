using UnityEngine;

public class ToggleFlashlight : MonoBehaviour
{
    [SerializeField] private Light light;
    [SerializeField] private AudioSource source;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ToggleFlashlight"))
        {
            light.enabled = !light.enabled;
            source.Play();
        }
    }
}
