using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackObject : MonoBehaviour
{
    public Transform nodePos;
    public float posZ;
    public GameObject hammer;
   
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

            StartCoroutine("MakeBiggerObj");
           

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
        if (other.gameObject.tag == "button")
        {
            other.gameObject.GetComponent<Animation>().Play();
            hammer.gameObject.GetComponent<Animation>().Play();
            other.gameObject.GetComponent<CapsuleCollider>().enabled = false;

        }
    }

    IEnumerator MakeBiggerObj()
    {
        for (int i = StackManager.instance.vaseObject.Count - 1; i >= 0; i--)
        {
            int index = i;
            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 1.5f;
            StackManager.instance.vaseObject[index].transform.DOScale(scale, 0.1f).OnComplete(() =>
             StackManager.instance.vaseObject[index].transform.DOScale(1, 0.1f));
            yield return new WaitForSeconds(0.05f);
        }
    }

}
