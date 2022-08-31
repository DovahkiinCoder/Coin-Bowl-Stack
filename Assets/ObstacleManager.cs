using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {

            DestroyVase(other);
            DestroyVaseCoin(other);
            //---------------------DENEME------------------------------
            /*StackManager.instance.vaseObject.Remove(other.gameObject);
            StackManager.instance.vaseCount--;
            StackObject.instance.posZ -= 2.6f;*/
            //---------------------DENEME------------------------------

        }
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
