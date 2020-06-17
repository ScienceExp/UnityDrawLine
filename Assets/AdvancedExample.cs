using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedExample : MonoBehaviour
{
    float angle;
    float angle2;

    private void Start()
    {
        Draw.DrawLine(new Vector3(0, 0, 0), new Vector3(1, 1, 0), Color.blue);
    }

    void Update()
    {
        angle += 90f*Time.deltaTime;
        if (angle >= 360f)
            angle = 0;
        FollowCircle(angle, Color.red);
        angle2 -= 90f * Time.deltaTime;
        if (angle2 <= 0f)
            angle2 = 360f;
        FollowCircle(angle2, Color.green);

        Draw.DrawLine(new Vector3(0, 0, 0), new Vector3(10, 10, 0), Color.blue);
    }

    void FollowCircle(float ang, Color c)
    {
        float scale = 4f;
        Vector3 endPos = new Vector3(
            Mathf.Cos(ang * Mathf.Deg2Rad) * scale, 
            Mathf.Sin(ang * Mathf.Deg2Rad) * scale, 
            0f);
        Draw.DrawLine(new Vector3(0, 0, 0), endPos, c);
    }
}
