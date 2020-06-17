using UnityEngine;

public class SimpleExample : MonoBehaviour
{

    public Vector3 startPos;
    public Vector3 endPos;
    public Color color;
    public float size = 0.05f;


    void Update()
    {
        Draw.DrawLine(startPos, endPos, color, size);
    }
}
