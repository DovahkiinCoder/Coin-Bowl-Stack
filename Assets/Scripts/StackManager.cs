using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackManager : MonoBehaviour
{
    public static StackManager instance;
    public int vaseCount;
    public GameObject player;
    public Transform lastVaseStack;
    public GameObject last;
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
        
        for (int i = vaseObject.Count-1; i>=0; i--)
        {
           Debug.Log(vaseObject.Count);
           Destroy(vaseObject[i].gameObject.transform.GetComponent<StackObject>());
           vaseObject[i].transform.GetComponent<BoxCollider>().isTrigger = true;
           vaseObject[i].transform.DOJump(last.transform.position + new Vector3(Random.Range(-0.5f,0.5f),0, Random.Range(-2, 2)) * 10, 5, 1, .5f);
           vaseObject.RemoveAt(i);
           vaseCount--;
           vaseStack = null;
           //lastVaseStack = vaseObject[vaseObject.Count - 1].transform;


            /*vaseObject[i].gameObject.transform.GetComponent<Collider>().enabled = false;
            //vaseObject[i].transform.GetComponent<BoxCollider>().isTrigger = true;
            Destroy(vaseObject[i].gameObject.transform.GetComponent<StackObject>());
            vaseObject[i].gameObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            vaseObject[i].gameObject.transform.GetComponent<Collider>().enabled = true;
            vaseCount--;
            //lastVaseStack = vaseObject[vaseObject.Count - 1].transform;
            //vaseStack = vaseObject[vaseObject.Count - 1].transform;           
             if (i == 0)
             {
                 break;
             }*/

        }


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
        if (other.gameObject.tag == "WallObstacle")
        {
            other.gameObject.GetComponent<Collider>().enabled = false;
            LeftObjectRemove();
            //other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }


   
    
}

