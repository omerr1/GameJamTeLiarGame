using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayBtn()
    {
        SceneManager.LoadScene("NormalStage");
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    public void MakeInvisible()
    {
        
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("CubeNotVisible");

        for(int i = 0; i < cubes.Length; i++)
        {
            MeshRenderer d = cubes[i].GetComponent<MeshRenderer>();
            d.enabled = !d.enabled;
            d = null;
        }
    }

}
