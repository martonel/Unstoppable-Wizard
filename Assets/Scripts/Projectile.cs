using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject particle;
    public Vector3 directionRotation;
    private Vector2 dir;
    private Rigidbody2D rb;
    public float forceSpeed;
    public float DestroySpeed;
    public int damage;
    public bool isDestroyable = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rb.AddForce(new Vector3(dir.x,dir.y,0)*forceSpeed/100);
        StartCoroutine(WaitTime());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player" )
        {
            if (collision.gameObject.tag == "enemy")
            {
                collision.gameObject.GetComponent<PlayerHealth>().GetDamage(damage);
            }
            if (particle != null)
            {
                Instantiate(particle, this.gameObject.transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "sword" && collision.gameObject.tag != "shield")
        {
            if (collision.gameObject.tag == "enemy")
            {
                collision.gameObject.GetComponent<PlayerHealth>().GetDamage(damage);
            }
            if (particle != null)
            {
                Instantiate(particle, this.gameObject.transform.position, Quaternion.identity);
            }
            if (isDestroyable)
            {
                Destroy(this.gameObject);
            }
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
