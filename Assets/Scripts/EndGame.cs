using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player1" || col.tag == "Player2")
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
