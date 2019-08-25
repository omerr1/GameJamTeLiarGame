using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector3 respawnPos = Vector3.zero;

    

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        setUpRespawnLoc();

    }
    void setUpRespawnLoc()
    {
        if (PlayerPrefs.HasKey("RespawnLocationX"))
        {

            respawnPos = new Vector3(PlayerPrefs.GetFloat("RespawnLocationX"),
                PlayerPrefs.GetFloat("RespawnLocationY"), PlayerPrefs.GetFloat("RespawnLocationZ"));
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Respawn();
        }
    }
    public void Respawn()
    {
        Player.transform.position = respawnPos;
    }

}
