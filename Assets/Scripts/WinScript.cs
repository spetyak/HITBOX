using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{

    public GameObject Player1;
    public GameObject Player2;

    // Update is called once per frame
    public void Update()
    {

        if (Player1.GetComponent<BoxMove1>().health == 0 || Player1.transform.position.y < 0)
        {
            SceneManager.LoadScene("Player2Wins");
        }
        else if (Player2.GetComponent<BoxMove2>().health == 0 || Player2.transform.position.y < 0)
        {
            SceneManager.LoadScene("Player1Wins");
        }

    }

}
