using System.Collections.Generic;
using UnityEngine;

/// <summary>Simple draw tool that can be used like Debug.DrawLine()</summary>
public class Draw : MonoBehaviour
{
    public GameObject rLine;
    static List<GameObject> rLines = new List<GameObject>();
    static List<Line> lines = new List<Line>();
    static bool changed = false;
    private void Awake()
    {
        rLines = new List<GameObject>();
        lines = new List<Line>();
    }

    private void Update()
    {
        if (!changed)
            return;
        changed = false;
        if (lines.Count > rLines.Count)
        {
            for (int i = rLines.Count; i < lines.Count; i++)
            {
                GameObject tmp = Instantiate(rLine, new Vector3(0, 0, 0), Quaternion.identity, transform);
                rLines.Add(tmp);
                //Debug.Log("added line");
            }
        }
        else if (lines.Count < rLines.Count)
        {
            for (int i = lines.Count; i < rLines.Count; i++)
            {
                Destroy(rLines[i]);
                //Debug.Log("removed line");
            }
            int n = rLines.Count - lines.Count;
            rLines.RemoveRange(rLines.Count - n, n);
        }

        for (int i = 0; i < lines.Count; i++)
        {
            LineRenderer lr = rLines[i].GetComponent<LineRenderer>();
            lr.positionCount = 2;
            lr.SetPosition(0, lines[i].startPos);
            lr.SetPosition(1, lines[i].endPos);
            lr.material.color = lines[i].color;
            lr.startWidth = lines[i].size;
            lr.endWidth = lines[i].size;
        }
        lines = new List<Line>();
    }
    /// <summary>DrawLine can be used in place of Debug.DrawLine. You can also specify size of the line.</summary>
    public static void DrawLine(Vector3 start, Vector3 end, Color color, float size = 0.05f)
    {
        changed = true;
        lines.Add(new Line(start, end, color, size));
    }
}
