using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireConnection : MonoBehaviour
{
   private LineRenderer lineRenderer;

    public void DrawConnection(Vector3 startPoint, Vector3 endPoint, Color wireColor)
    {
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.widthMultiplier = 0.05f;
            lineRenderer.positionCount = 2;
            lineRenderer.numCapVertices = 5;
        }

        lineRenderer.startColor = wireColor;
        lineRenderer.endColor = wireColor;

        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }

    public void SetGlow(Color glowColor)
    {
        if (lineRenderer != null)
        {
            lineRenderer.material.EnableKeyword("_EMISSION");
            lineRenderer.material.SetColor("_EmissionColor", glowColor * 2f);
        }
    }
}
