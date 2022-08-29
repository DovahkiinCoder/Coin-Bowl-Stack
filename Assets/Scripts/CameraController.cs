using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float lerpSpeed = 3f;

    public bool followPlayerX;


    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;      //set the target, player tagged gameobject
    }
    private void LateUpdate()
    {
        if (!followPlayerX)     //Is it active for the character to follow in the horizontal plane?
        {
            Vector3 lerpPos = new Vector3(0 + offset.x, 0 + offset.y, target.position.z + offset.z);        //following distance/offset
            transform.position = Vector3.Lerp(transform.position, lerpPos, lerpSpeed * Time.deltaTime);     //follow player
        }//Is it active for the character to follow in the horizontal plane?
        else
        {
            Vector3 lerpPos = new Vector3(target.position.x + offset.x, 0 + offset.y, target.position.z + offset.z);        //followPlayerX + offset
            transform.position = Vector3.Lerp(transform.position, lerpPos, lerpSpeed * Time.deltaTime);     //followPlayer
        }
    }
}