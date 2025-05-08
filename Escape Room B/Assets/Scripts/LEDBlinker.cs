using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LEDBlinker : MonoBehaviour
{
    //sets the time between blinks
    [SerializeField] private float blinkInterval = 0.5f;

    private Light _light;

    
    void Awake()
    {
        _light = GetComponent<Light>();
    }

    void Start()
    {
        //starts the blinking loop
        StartCoroutine(BlinkRoutine());
    }
    //keeps it going forever 
    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            _light.enabled = !_light.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
