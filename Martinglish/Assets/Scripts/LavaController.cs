using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LavaController : MonoBehaviour
{
    [SerializeField] GameObject player;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            
            player.SetActive(false);
        }
    }
}
