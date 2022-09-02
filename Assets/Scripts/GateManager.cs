using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GateManager : MonoBehaviour
{
    public enum UpgradeVase {Bigger,Smaller};
    public UpgradeVase VaseUpgrade;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            //GameObject Vases = other.transform.GetChild(index).gameObject;
            switch (VaseUpgrade)
            {
                case UpgradeVase.Bigger:
                    StartCoroutine(VaseLevelBigger(other.gameObject));

                    break;
                case UpgradeVase.Smaller:
                   StartCoroutine(VaseLevelSmaller(other.gameObject));


                    break;
                default:
                    break;
            }
        }
    }
    IEnumerator VaseLevelBigger(GameObject other)
    {
        for (int i = 0; i < other.transform.childCount; i++)
        {
            if (i < 2)
            {
                if (other.transform.GetChild(i).gameObject.activeSelf)
                {
                    other.transform.GetChild(i).gameObject.SetActive(false);
                    other.transform.GetChild(i + 1).gameObject.SetActive(true);
                    break;
                }

            }



            yield return null;
           
        }
    }

    IEnumerator VaseLevelSmaller(GameObject other)
    {
        for (int i = 0; i < other.transform.childCount; i++)
        {
            if (other.transform.GetChild(i).gameObject.activeSelf)
            {
                if (i != 0)
                {
                    if (i < 3)
                    {
                        BoolControl(other);
                        other.transform.GetChild(i).gameObject.SetActive(false);
                        other.transform.GetChild(i - 1).gameObject.SetActive(true);
                    }
                }
                break;
            }




            yield return null;

        }
    }

    public void BoolControl(GameObject other)
    {
        if (other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().alt == true && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().orta == true && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().üst == true)
        {
            if (other.gameObject.transform.GetChild(2).gameObject.activeSelf)
            {
                other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().üst = false;
                for (int i = 0; i < other.gameObject.transform.childCount; i++)
                {
                    if (i == other.gameObject.transform.childCount - 1)
                    {
                        Destroy(other.gameObject.transform.GetChild(i).gameObject);
                    }
                }
            }
           
        }
        if (other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().alt == true && other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().orta == true && other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().üst == false)
        {
            if (other.gameObject.transform.GetChild(1).gameObject.activeSelf)
            {
                other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().orta = false;
                for (int i = 0; i < other.gameObject.transform.childCount; i++)
                {
                    if (i == other.gameObject.transform.childCount - 1)
                    {
                        Destroy(other.gameObject.transform.GetChild(i).gameObject);
                    }
                }
            }

        }


    }

    


}
