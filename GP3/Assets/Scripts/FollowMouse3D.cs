using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowMouse3D : MonoBehaviour
{
    Vector3 pos;
    public float offset = 3f;
    public GameObject stick;

    void Update()
    {
        pos = Input.mousePosition;
        pos.z = offset;
        stick.transform.position = Camera.main.ScreenToWorldPoint(pos);
    }
}
