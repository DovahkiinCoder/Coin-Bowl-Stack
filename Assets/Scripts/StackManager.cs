using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public static StackManager instance;
    public int vaseCount;
    public GameObject player;
    public Transform vaseStack;
    public List<GameObject> vaseObject = new List<GameObject>();
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {


            //Destroy(other.GetComponent<Collider>());
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            vaseCount++;
            if (!vaseStack)
            {
                other.gameObject.AddComponent<StackObject>().nodePos = transform;
                vaseStack = other.transform;
            }
            else
            {
                other.gameObject.AddComponent<StackObject>().nodePos = vaseStack;
                vaseStack = other.transform;
            }
            vaseObject.Add(other.gameObject);
            if (vaseCount > 0)
            {
                other.gameObject.GetComponent<StackObject>().posZ = 1.5f;
            }
            

        }
    }
}

