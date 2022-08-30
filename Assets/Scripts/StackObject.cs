using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackObject : MonoBehaviour
{
    public Transform nodePos;
    public float posZ;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (StackManager.instance.vaseObject[0].gameObject == gameObject)
        {
            transform.position = new Vector3(nodePos.position.x, nodePos.position.y, nodePos.position.z + posZ);

        }
        else
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, nodePos.position.x, Time.deltaTime * 20), nodePos.position.y, nodePos.position.z + posZ);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {


            //Destroy(other.GetComponent<Collider>());
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            StackManager.instance.vaseCount++;
            if (!StackManager.instance.vaseStack)
            {
                other.gameObject.AddComponent<StackObject>().nodePos = transform;
                StackManager.instance.vaseStack = other.transform;
            }
            else
            {
                other.gameObject.AddComponent<StackObject>().nodePos = StackManager.instance.vaseStack;
                StackManager.instance.vaseStack = other.transform;
            }
            StackManager.instance.vaseObject.Add(other.gameObject);
            if (StackManager.instance.vaseCount > 0)
            {
                other.gameObject.GetComponent<StackObject>().posZ = 2.6f;
            }

        }
    }

}
