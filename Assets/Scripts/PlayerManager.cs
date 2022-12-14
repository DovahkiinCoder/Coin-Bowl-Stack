using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{
    //--------------------------------------------
    [Header("Players Settings")]
    public static PlayerManager instance;
    public float Speed;
    public float swerveSpeed;       //sağa sola gitme hızı
    public float lerpSpeed;     //yumuşatma hızı (smoothing)
    //--------------------------------------------
    private int collectedCoin;
    public bool isStart;
    //--------------------------------------------
    public GameObject cameraPos;
    bool lastFinish;
    //--------------------------------------------
    








    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        PlayerPrefs.SetInt("Coin", 0);

    }


    void Update()
    {

        PlayerMove();
        PlayerDistance();
    }



    



    void PlayerDistance() 
    {
        if (transform.position.x < -6.47f)
        {
            transform.position = new Vector3(-6.47f + 0.01f, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 6.47f)
        {
            transform.position = new Vector3(6.47f - 0.01f, transform.position.y, transform.position.z);
        }
    }

    void PlayerMove()
    {
        if (isStart)
        {
            transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);
            //m_Rigidbody.AddForce(transform.forward * Speed * Time.deltaTime);
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                isStart = true;
                
            }
        }
    }
}