using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : InteractiveObj
{
    [SerializeField] private DoorsController doorsController;

    public override void Interac()
    {

        if (doorsController.isOpen)
        {
            doorsController.Close();
        }
        else
        {
            doorsController.Open();
        }
    }
}
