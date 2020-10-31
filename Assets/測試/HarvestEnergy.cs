using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestEnergy : MonoBehaviour
{
    int player;

    void Start()
    {
        player = LayerMask.NameToLayer("player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == player)
        {
                gameObject.SetActive(false);
        }
    }
}
