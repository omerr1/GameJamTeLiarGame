using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    NotiManager noti;
    public string Message;
    public float delay;
    Coroutine destroyObj;

    private void Awake()
    {
        noti = GameObject.FindGameObjectWithTag("Manager").GetComponent<NotiManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name.Equals("Player"))
        {
            noti.startNotification(delay, Message);
            this.gameObject.GetComponent<DialogueTrigger>().enabled = false;
            StartCoroutine(DestroyObj());
        }
    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }

}
