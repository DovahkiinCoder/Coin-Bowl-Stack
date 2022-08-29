using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwerveInputSystem _swerveInputSystem;
    [SerializeField] public float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;
    float swerveAmount;

    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
    }

    private void Update()
    {
        if (PlayerManager.instance.isStart)
        {
            float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
            //transform.position = Vector3.Lerp(transform.position, new Vector3(swerveAmount, transform.position.y, transform.position.z), 3f * Time.deltaTime);
            transform.Translate(swerveAmount, 0, 0);
        }
        else
        {

            if (Input.GetMouseButtonDown(0))
            {

                PlayerManager.instance.isStart = true;
            }

        }
        
    }
}