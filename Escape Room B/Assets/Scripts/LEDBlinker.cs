using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LEDBlinker : MonoBehaviour
{
    [Tooltip("Blink interval in seconds")]
    [SerializeField] private float blinkInterval = 0.5f;

    private Light _light;

    void Awake()
    {
        _light = GetComponent<Light>();
    }

    void Start()
    {
        StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            _light.enabled = !_light.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
