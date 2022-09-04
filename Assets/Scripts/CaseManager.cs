using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CaseManager : MonoBehaviour
{
    public TextMeshPro FinalText;
    public TextMeshProUGUI CardText;
    float b;
    public GameObject bearObj;
    //public bool isFinal;

    // Start is called before the first frame update
    private void Update()
    {
        FinalText.text = b.ToString();
        CardText.text = PlayerPrefs.GetFloat("CardCoin") + "";

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            b += other.gameObject.GetComponent<StackObject>().allCount;
            PlayerPrefs.SetFloat("Coin", PlayerPrefs.GetFloat("Coin") - other.gameObject.GetComponent<StackObject>().allCount);
            DestroyVase(other);
            DestroyVaseCoin(other);
            LeftObjectRemove();
            if (StackManager.instance.vaseCount == 0)
            {
                PlayerManager.instance.Speed = 0;
            }

            if (PlayerPrefs.GetFloat("Coin") == 0)
            {
                PlayerPrefs.SetFloat("MatValue", ((b / 100) * 2));
                bearObj.transform.GetComponent<FinalManager>().isFlag = true;
                PlayerPrefs.SetFloat("CardCoin", PlayerPrefs.GetFloat("CardCoin")+(PlayerPrefs.GetFloat("MatValue")*100)/2);

            }

            //---------------------DENEME------------------------------
            /*StackManager.instance.vaseObject.Remove(other.gameObject);
            StackManager.instance.vaseCount--;
            StackObject.instance.posZ -= 2.6f;*/
            //---------------------DENEME------------------------------

        }

    }
    public void LeftObjectRemove()
    {


        StackManager.instance.lastVaseStack = StackManager.instance.vaseObject[StackManager.instance.vaseObject.Count - 1].transform;
        StackManager.instance.vaseObject.RemoveAt(StackManager.instance.vaseObject.Count - 1);
        //lastVaseStack.gameObject.GetComponent<StackObject>().enabled = false;
        Destroy(StackManager.instance.lastVaseStack.GetComponent<Collider>());
        Destroy(StackManager.instance.lastVaseStack.gameObject.GetComponent<StackObject>());
        StackManager.instance.vaseCount--;
        StackManager.instance.vaseStack = null;
        //StackManager.instance.lastVaseStack = StackManager.instance.vaseObject[StackManager.instance.vaseObject.Count - 1].transform;
        //StackManager.instance.vaseStack = StackManager.instance.vaseObject[StackManager.instance.vaseObject.Count - 1].transform;


    }
    public void DestroyVase(Collider other)
    {
        for (int i = 0; i < other.gameObject.transform.childCount; i++)
        {
            if (other.gameObject.transform.GetChild(i).gameObject.activeSelf)
            {
                other.gameObject.transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);

                Debug.Log(other.gameObject.transform.GetChild(i).gameObject);
                for (int j = 1; j < other.gameObject.transform.GetChild(i).childCount; j++)
                {
                    other.gameObject.transform.GetChild(i).transform.GetChild(j).gameObject.SetActive(true);
                    other.gameObject.transform.GetChild(i).transform.GetChild(j).gameObject.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezeAll;


                    Collider[] colliders = Physics.OverlapSphere(other.transform.position, 5);
                    foreach (var item in colliders)
                    {
                        Rigidbody rb = item.GetComponent<Rigidbody>();

                        if (rb != null)
                        {
                            other.gameObject.transform.GetChild(i).transform.GetChild(j).gameObject.GetComponent<Rigidbody>().AddExplosionForce(250, transform.position, 4, 50F);

                        }

                    }
                    Destroy(other.gameObject.transform.GetChild(i).transform.GetChild(j).gameObject, 1f);
                }
                break;

            }
        }

    }

    public void DestroyVaseCoin(Collider other)
    {
        for (int i = 0; i < other.gameObject.transform.childCount; i++)
        {
            if (other.gameObject.transform.GetChild(i).gameObject.tag == "MultipleCoin")
            {
                Destroy(other.gameObject.transform.GetChild(i).gameObject);
            }

        }
    }
}
