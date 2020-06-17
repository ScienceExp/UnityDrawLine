using UnityEngine;

public class Line
{
    public Vector3 startPos;
    public Vector3 endPos;
    public Color color;
    public float size;
    public Line(Vector3 StartPos, Vector3 EndPos, Color c, float Size)
    {
        startPos = StartPos;
        endPos = EndPos;
        color = c;
        size = Size;
    }
}
