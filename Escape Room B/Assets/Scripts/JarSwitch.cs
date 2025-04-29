using UnityEngine;

[RequireComponent(typeof(Collider))]
public class JarSwitch : MonoBehaviour
{
    [Tooltip("Assign the Light component from each of your 7 jar GameObjects here")]
    [SerializeField] private Light[] jarLights = new Light[7];

    private bool lightsOn = false;

    private void Start()
    {
        // Ensure they start off
        SetLights(false);
    }

    private void OnMouseDown()
    {
        // Flip state
        lightsOn = !lightsOn;
        SetLights(lightsOn);
    }

    private void SetLights(bool on)
    {
        foreach (var l in jarLights)
            if (l != null)
                l.enabled = on;
    }
}
