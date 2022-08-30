using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerManager : MonoBehaviour
{
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
            
            GameObject money = Instantiate(Resources.Load<GameObject>("1cent"), other.transform.position, Quaternion.identity);
            StartCoroutine(TimeBig(money));
            money.transform.SetParent(other.gameObject.transform);

        }
    }

    IEnumerator TimeBig(GameObject other)
    {
        for (int i = 0; i < other.transform.childCount; i++)
        {
            other.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(.1f);
        }
    }
}
