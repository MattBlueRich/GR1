using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Button : MonoBehaviour
{
    GameObject button;
    public GameObject door;

    void Start()
    {
        button = gameObject;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player1" || col.tag == "Player2")
        {
            button.SetActive(false);
            door.SetActive(false);
        }
    }
}
