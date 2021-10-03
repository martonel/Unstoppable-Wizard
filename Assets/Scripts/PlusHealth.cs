using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusHealth : MonoBehaviour
{
    public PlayerHealth health;
    public int plusHealth;
    private GameObject playerPrefab;
    private GameObject[] players;
    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length != 0)
        {
            playerPrefab = players[0].gameObject;
        }
        health = playerPrefab.GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            health.PlusHealth(plusHealth);
            Destroy(this.gameObject);
        }
    }
}
