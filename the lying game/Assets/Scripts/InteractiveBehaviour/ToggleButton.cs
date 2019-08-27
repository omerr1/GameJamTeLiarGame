using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : InteractiveObj
{

    private bool state;

    public ToggleButton()
    {
        isGrabbable = false;
        state = false;
    }

    public override void Interac()
    {
        state = !state;
        Debug.Log("Button State" + state);
    }
}
