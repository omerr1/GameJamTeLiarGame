using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider Col)
    {
        if (Col.tag == "Player")
        {
            GameObject.Find("Manager").GetComponent<GameManager>().respawnPos = this.transform.position;
            saveNewRespawn(this.transform.position);
        }
    }
    void saveNewRespawn(Vector3 newPos)
    {
        PlayerPrefs.SetFloat("RespawnLocationX", newPos.x);
        PlayerPrefs.SetFloat("RespawnLocationY", newPos.y);
        PlayerPrefs.SetFloat("RespawnLocationZ", newPos.z);
    }

}
