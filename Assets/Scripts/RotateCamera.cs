using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public Transform target;
    public void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.right * 8f * Time.deltaTime);
    }
}
