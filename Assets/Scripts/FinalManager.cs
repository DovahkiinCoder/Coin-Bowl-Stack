using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalManager : MonoBehaviour
{
    private Material bearMat;
    float x = 0;
    private GameObject Player;
    public GameObject imgPos;
    public bool isFlag;
    public bool isFlag1;
    float lastPosy;
    public bool isFinal = false;
    public GameObject f1;

    // Start is called before the first frame update
    void Start()
    {
       
        bearMat = GetComponent<MeshRenderer>().sharedMaterial;
        PlayerPrefs.SetFloat("LA", 181 + PlayerPrefs.GetFloat("LastX"));        
        //bearMat.SetFloat("_GradientAngle", 181 + PlayerPrefs.GetFloat("LastAngle"));
        bearMat.SetFloat("_GradientAngle", PlayerPrefs.GetFloat("LA"));
        //StartCoroutine("ConstantlyIncrease");
        //bearMat.SetFloat("_GradientAngle", 181 + PlayerPrefs.GetFloat("MatValue"));
        //bearMat.SetFloat("_GradientAngle", 181 + PlayerPrefs.GetInt("MatValue"));
        //Debug.Log(PlayerPrefs.GetFloat("MatValue"));
        //bearMat.SetFloat("_GradientAngle", bearMat.GetFloat("_GradientAngle") + 0.082f);
        if (PlayerPrefs.GetFloat("PosY") ==0)
        {
            imgPos.transform.position = new Vector3(imgPos.transform.position.x, imgPos.transform.position.y + PlayerPrefs.GetFloat("PosY"), imgPos.transform.position.z);
        }
        else
        {
            imgPos.transform.position = new Vector3(imgPos.transform.position.x, PlayerPrefs.GetFloat("PosY"), imgPos.transform.position.z);

        }
    }

    // Update is called once per frame
    void Update()
    {
        //
        if (isFlag)
        {
            StartCoroutine(ConstantlyIncrease(PlayerPrefs.GetFloat("MatValue")));
            isFlag = false;
        }

       if (bearMat.GetFloat("_GradientAngle") >= 184.700f)
        {
            isFinal = true;
        }

        if (isFinal == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, f1.transform.position, 0.5f);
            Camera.main.GetComponent<RotateCamera>().enabled = true;
        }
    }


    public IEnumerator ConstantlyIncrease(float value)
    {
        while (true)
        {
            if (bearMat.GetFloat("_GradientAngle") < 185)
            {


                if (x < value)
                {
                    x += 0.082f;
                    bearMat.SetFloat("_GradientAngle", PlayerPrefs.GetFloat("LA") + x);
                    imgPos.transform.position = new Vector3(imgPos.transform.position.x, Mathf.Lerp(imgPos.transform.position.y, imgPos.transform.position.y + .41f, 1f), imgPos.transform.position.z);
                    yield return new WaitForSeconds(.1f);

                }
                else
                {
                    if (isFlag1 == false)
                    {
                        PlayerPrefs.SetFloat("LastX", x + PlayerPrefs.GetFloat("LastX"));

                        isFlag1 = true;
                    }
                    //PlayerPrefs.SetFloat("LA", PlayerPrefs.GetFloat("LastX"));
                    lastPosy = imgPos.transform.position.y;
                    PlayerPrefs.SetFloat("PosY", lastPosy);
                    yield return null;

                }

            }
            else
            {
                break;
            }
            
           
        }
    }
    

}
