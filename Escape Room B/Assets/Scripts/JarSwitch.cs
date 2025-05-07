using UnityEngine;

[RequireComponent(typeof(Collider))]
public class JarSwitch : MonoBehaviour
{
    //give us the 7 jars in the inspector tab
    [SerializeField] private Light[] jarLights = new Light[7];

    private bool lightsOn = false;

    private void Start()
    {
        // makes sure they start off
        SetLights(false);
    }

    private void OnMouseDown()
    {
        // turns the jars on
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
