using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject particle;
    public Vector3 directionRotation;
    private Vector2 dir;
    private Rigidbody2D rb;
    public float forceSpeed;
    public float DestroySpeed;

    public GameObject playerPrefab;
    private GameObject[] players;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length != 0)
        {
            playerPrefab = players[0].gameObject;
        }
        rb = GetComponent<Rigidbody2D>();
        dir = playerPrefab.transform.position - transform.position;
        rb.AddForce(new Vector3(dir.x, dir.y, 0) * forceSpeed / 100);
        StartCoroutine(WaitTime());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().GetDamage(damage);
            Debug.Log("hit Player");
        }
        if (collision.tag != "enemyProjectile")
        {
            if (particle != null)
            {
                Instantiate(particle, this.gameObject.transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(DestroySpeed);
        if (particle != null)
        {
            Instantiate(particle, this.gameObject.transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
}
