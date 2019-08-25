using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppTrigger : MonoBehaviour
{
    ApplicationsManager appManager;
    NotiManager noti;

    public string appName;

    // Start is called before the first frame update
    void Start()
    {
        noti = GameObject.FindGameObjectWithTag("Manager").GetComponent<NotiManager>();
        appManager = GameObject.FindGameObjectWithTag("Phone").GetComponent<ApplicationsManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name.Equals("Player"))
        {
            Debug.Log("add app called " + appName);
            appManager.addApp(appName);
            noti.startNotification(3f,"New Notification called " + appName);
            StartCoroutine(DestroyObj());
        }
    }


    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
