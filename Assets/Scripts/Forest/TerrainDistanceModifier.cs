using UnityEngine;

[ExecuteInEditMode]
public class TerrainDistanceModifier : MonoBehaviour
{
    public float distance = 250;
    Terrain _terrain;

    void Start()
    {
        _terrain = GetComponent<Terrain>();
        if (_terrain == null)
        {
            Debug.LogError("This gameobject is not terrain, disabling forced details distance", gameObject);
            enabled = false;
        }
    }

    // WARNING: this runs update loop inside editor, you dont need this if you dont change the value
    void Update()
    {
        _terrain.detailObjectDistance = distance;
    }
}