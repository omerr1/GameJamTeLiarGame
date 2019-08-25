using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ApplicationsManager : MonoBehaviour
{
    GameObject[] rows;
    PhoneMovement phone;

    List<string> availableApps = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        rows = GameObject.FindGameObjectsWithTag("Row");
        phone = GetComponent<PhoneMovement>();
        availableApps.Add("MakeInvisible");
        MakeAppsDisapper();
    }

    void MakeAppsDisapper()
    {
        for(int i =0; i < rows.Length; i++)
        {
            for(int j = 0; j < rows[i].transform.childCount; j++)
            {                
                if(!availableApps.Contains(rows[i].transform.GetChild(j).name))
                {
                    rows[i].transform.GetChild(j).GetComponent<CanvasGroup>().alpha = 0;
                    rows[i].transform.GetChild(j).GetComponent<Button>().enabled = false;
                }
                else
                {
                    rows[i].transform.GetChild(j).GetComponent<CanvasGroup>().alpha = 1;
                    rows[i].transform.GetChild(j).GetComponent<Button>().enabled = true;
                }
            }
        }
    }

    public void addApp(string app)
    {
        availableApps.Add(app);
        Debug.Log(availableApps.Count);
        MakeAppsDisapper();
    }

}
