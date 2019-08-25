using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NotiManager : MonoBehaviour
{
    public GameObject NotiPanel;
    private Text notiText;
    private CanvasGroup CG;
    private Button exitButton;
    Coroutine co;

    // Start is called before the first frame update
    void Start()
    {
        CG = NotiPanel.GetComponent<CanvasGroup>();
        notiText = NotiPanel.transform.Find("Notification").GetComponent<Text>();
        exitButton = NotiPanel.transform.Find("Button").GetComponent<Button>();

        exitButton.onClick.AddListener(stopNotification);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    startNotification(5,"HELLLLLLO");
        //}
    }

    public void startNotification(float delay,string text)
    {
        if(co != null)
        StopCoroutine(co);
        
        CG.alpha = 1;
        NotiPanel.SetActive(true);
        notiText.text = text;

        co = StartCoroutine(StartNot(delay));

    }
    public void stopNotification()
    {
        StopCoroutine(co);
        NotiPanel.SetActive(false);
    }

    IEnumerator StartNot(float delay)
    {
        yield return new WaitForSeconds(delay);

        while (CG.alpha >= 0)
        {
            CG.alpha -= 0.01f;
            yield return new WaitForEndOfFrame();
        }
        NotiPanel.SetActive(false);
        StopCoroutine(co);


    }

}
