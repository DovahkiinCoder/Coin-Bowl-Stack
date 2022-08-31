using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Animator buttonAnim;
    public Animator HammerAnim;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Cube")
        {
            buttonAnim.Play("ButtonAnim");
            HammerAnim.Play("HammerAnim");
        }
    }
}
