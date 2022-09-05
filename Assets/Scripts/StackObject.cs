using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackObject : MonoBehaviour
{
    public static StackObject instance;
    public Transform nodePos;
    public float posZ;
    //public int allCount;
    


    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (StackManager.instance.vaseObject[0])
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PigCoin")
        {
            //
            BoolControl(other);
        }
    }



    public void BoolControl(Collision other)
    {
       
        if (gameObject.transform.GetChild(1).GetComponent<ControlManager>().alt == true && gameObject.transform.GetChild(1).GetComponent<ControlManager>().orta == false && gameObject.transform.GetChild(1).GetComponent<ControlManager>().üst == false)
        {
            if (gameObject.transform.GetChild(1).gameObject.activeSelf)
            {
                //gameObject.transform.GetChild(1).GetComponent<ControlManager>().orta = true;
                Coinssss(other.gameObject , 1);
                Destroy(other.gameObject);
            }

        }
        if (gameObject.transform.GetChild(2).GetComponent<ControlManager>().alt == true && gameObject.transform.GetChild(2).GetComponent<ControlManager>().orta == true && gameObject.transform.GetChild(2).GetComponent<ControlManager>().üst == false)
        {
            if (gameObject.transform.GetChild(2).gameObject.activeSelf)
            {
               // gameObject.transform.GetChild(2).GetComponent<ControlManager>().üst = true;
                Coinssss(other.gameObject, 2);
                Destroy(other.gameObject);

            }

        }


    }

    public void Coinssss(GameObject other , float pozY)
    {
        GameObject money = Instantiate(Resources.Load<GameObject>("5cent"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + pozY, gameObject.transform.position.z), Quaternion.identity);
        StartCoroutine(TimeBig(money));
        money.transform.SetParent(gameObject.transform);
    }

    IEnumerator TimeBig(GameObject other)
    {
        for (int i = 0; i < other.transform.childCount-8; i++)
        {
            other.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(.1f);
        }
    }



}
