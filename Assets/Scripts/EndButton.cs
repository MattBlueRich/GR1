using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour
{
    GameObject button;
    public GameObject end;

    void Start()
    {
        button = gameObject;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player1" || col.tag == "Player2")
        {
            button.SetActive(false);
            end.SetActive(true);
        }
    }
}
