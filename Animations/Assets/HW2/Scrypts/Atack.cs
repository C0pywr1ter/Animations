using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    public bool hit;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && Input.GetKey(KeyCode.Mouse0))
        {
            hit = true;
          
           


        }


    }
}
