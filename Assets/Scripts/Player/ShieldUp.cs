using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUp : MonoBehaviour
{
    public GameObject shield;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("shield up!");
            GameObject obj =  Instantiate(shield, other.transform.position, Quaternion.identity);
            obj.transform.SetParent(other.gameObject.transform);
            Destroy(this.gameObject);
        }
    }
}
