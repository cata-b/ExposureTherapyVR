using UnityEngine;

public class InteriorLightScript : TimeOfDayListener
{

    [SerializeField] private Gradient gradient;
    [SerializeField] private float intensityMultiplier = 1;
    // Start is called before the first frame update
    public override void UpdateTime(float time01)
    {
        var intensity = gradient.Evaluate(time01).r * intensityMultiplier;

        gameObject.GetComponent<Light>().intensity = intensity;
    }
}
