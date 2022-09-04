using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalManager2 : MonoBehaviour
{
    public GameObject finalPos;
    public GameObject cameraPos;
    public GameObject Player;
    bool lastFinish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lastFinish)
        {
            SwerveMovement.instance.swerveSpeed = 0;            
            Player.transform.position = Vector3.Lerp(Player.transform.position, new Vector3(finalPos.transform.position.x, Player.transform.position.y, Player.transform.position.z), 3f * Time.deltaTime);
            Camera.main.GetComponent<CameraController>().enabled = false;

            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(finalPos.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z), 3f * Time.deltaTime);
            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, Quaternion.Euler(finalPos.transform.rotation.x, finalPos.transform.rotation.y, finalPos.transform.rotation.z), Time.deltaTime * 1.5f);



        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            lastFinish = true;
            //Ortala(other);
            //PlayerManager.instance.Speed = 0;

        }
    }

    
}
