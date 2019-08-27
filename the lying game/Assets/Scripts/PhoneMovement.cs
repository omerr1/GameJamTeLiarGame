using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using System.Runtime.InteropServices;


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
            CursorBack();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && anim.GetBool("isPhoneOut"))
        {
            anim.SetBool("isPhoneOut", false);
            
                CursorToPhone();
            
        }
        //this is for apps to execute if this is true;
        isPhoneOut = anim.GetBool("isPhoneOut");
    }
    void CursorToPhone()
    {
        Camera.main.GetComponent<CursorController>().canUpd = false;
        Camera.main.GetComponent<CameraController>().canUpd = false;
        Cursor.lockState = CursorLockMode.None;
        SetCursorPos(Screen.width / 2, Screen.height / 2);
    }
    void CursorBack()
    {
        Camera.main.GetComponent<CursorController>().canUpd = true;
        Camera.main.GetComponent<CameraController>().canUpd = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);

}
