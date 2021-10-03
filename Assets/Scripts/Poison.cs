using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public GameObject projectile;
    public float speed=0;
    public float timer = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (speed != 0) {
                other.transform.GetChild(0).GetComponent<Shoot>().SetNewSpell(speed, timer);
            }
            if (projectile != null)
            {
                other.transform.GetChild(0).GetComponent<Shoot>().SetProjectile(projectile);
            }
            Destroy(this.gameObject);
        }
    }
}
