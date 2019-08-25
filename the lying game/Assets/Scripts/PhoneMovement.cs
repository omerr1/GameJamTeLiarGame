using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PhoneMovement : MonoBehaviour
{
    private Animator anim;
    public bool isPhoneOut;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isPhoneOut", true);
        isPhoneOut = anim.GetBool("isPhoneOut");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !anim.GetBool("isPhoneOut"))
        {
            anim.SetBool("isPhoneOut", true);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && anim.GetBool("isPhoneOut"))
        {
            anim.SetBool("isPhoneOut", false);
        }
        //this is for apps to execute if this is true;
        isPhoneOut = anim.GetBool("isPhoneOut");
    }

}
