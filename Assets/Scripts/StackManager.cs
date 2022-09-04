using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackManager : MonoBehaviour
{
    public static StackManager instance;
    public int vaseCount;
    public GameObject player;
    public  Transform lastVaseStack;
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
    public void LeftObjectRemove()
    {
        for (int i = 0; i < vaseObject.Count-1; i++)
        {
                        
            /*vaseObject.RemoveAt(i);
            Destroy(vaseObject[i].gameObject.transform.GetComponent<StackObject>());
            vaseObject[i].transform.DOJump(new Vector3(vaseObject[i].transform.position.x, vaseObject[i].transform.position.y, transform.position.z + 10f),5,1,.5f);
            vaseObject[i].transform.GetComponent<BoxCollider>().isTrigger = true;


            /*if(i== (vaseObject.Count - 1))
                vaseStack = null;
                lastVaseStack = null;
                vaseCount = 0;
            {
            }*/

            StackManager.instance.lastVaseStack = StackManager.instance.vaseObject[StackManager.instance.vaseObject.Count - 1].transform;
            StackManager.instance.vaseObject.RemoveAt(StackManager.instance.vaseObject.Count - 1);
            //lastVaseStack.gameObject.GetComponent<StackObject>().enabled = false;
            Destroy(StackManager.instance.lastVaseStack.GetComponent<Collider>());
            Destroy(StackManager.instance.lastVaseStack.gameObject.GetComponent<StackObject>());
            StackManager.instance.vaseCount--;
            StackManager.instance.vaseStack = null;
        }


        //lastVaseStack = vaseObject[StackManager.instance.vaseObject.Count - 1].transform;
        //vaseObject.RemoveAt(vaseObject.Count - 1);
        //lastVaseStack.gameObject.GetComponent<StackObject>().enabled = false;
        //Destroy(StackManager.instance.lastVaseStack.GetComponent<Collider>());
        //
        //StackManager.instance.vaseCount--;
        //StackManager.instance.lastVaseStack = StackManager.instance.vaseObject[StackManager.instance.vaseObject.Count - 1].transform;
        //StackManager.instance.vaseStack = StackManager.instance.vaseObject[StackManager.instance.vaseObject.Count - 1].transform;


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
        if (other.gameObject.tag== "WallObstacle")
        {
            LeftObjectRemove();
            //other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}

