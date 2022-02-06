using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Health : MonoBehaviour
{
    public Player player;
    public bool once = false;
    private float inWallTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (player.health <= 0 && !once)
        {
            once = true;
            GameManager.Instance.EndRound(player);
        }

        int posX = Mathf.RoundToInt(transform.position.x);
        int posY = Mathf.RoundToInt(transform.position.y);
        
        if (GameManager.Instance.mapCellsLayer[posX][posY].GetInstantiateGameObject() != null)
        {
            if (GameManager.Instance.mapCellsLayer[posX][posY].GetInstantiateGameObject().CompareTag("UnbreakableWall"))
            {
                player.health = 0;    
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            player.health--;
        }
    }
}
