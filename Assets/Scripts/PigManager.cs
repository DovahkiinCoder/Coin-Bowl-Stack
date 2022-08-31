using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PigManager : MonoBehaviour
{
    public Transform prefabToSpawn;
    public int objectCount = 50;
    public float spawnRadius = 5;
    public float spawnCollisionCheckRadius = 5;
    public GameObject spawn;

    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hammer")
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);

            StartCoroutine("DestroyPig");
            SpawnCoin();

        }
    }

    IEnumerator DestroyPig()
    {
        for (int i = 1; i < gameObject.transform.childCount; i++)
        {

            gameObject.transform.GetChild(i).gameObject.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezeAll;

            Destroy(gameObject.transform.GetChild(i).gameObject, 1f);
            yield return null;
            //gameObject.transform.GetChild(i).gameObject.SetActive(false);


        }

        
    }

    public void SpawnCoin()
    {
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 spawnPoint = spawn.transform.position + Random.insideUnitSphere * spawnRadius;
            if (!Physics.CheckSphere(spawnPoint, spawnCollisionCheckRadius))
            {
                //Debug.Log("debugs");
                Transform coinPreb = Instantiate(prefabToSpawn, spawnPoint, Quaternion.identity);

                coinPreb.DOJump(spawn.transform.position+ Random.insideUnitSphere * spawnRadius, 2f,2,.5f);
            }
        }


    }
}
