using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float DestroySpeed;
    public void Start()
    {
        StartCoroutine(WaitTime());

    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(DestroySpeed);
        Destroy(this.gameObject);
    }
}
