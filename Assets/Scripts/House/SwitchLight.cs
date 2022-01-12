using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    [SerializeField] private Light light;
    [SerializeField] private GameObject switchObject;
    private bool inside = false;
    private float _offAngle = -64.298f;
    private float _onAngle = -4f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SwitchLights") && inside)
        {
            light.enabled = !light.enabled;
            var rotation = switchObject.transform.rotation.eulerAngles;
            if (light.enabled)
                rotation.x = _onAngle;
            else
                rotation.x = _offAngle;

            switchObject.transform.rotation = Quaternion.Euler(rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inside = false;
    }
}
