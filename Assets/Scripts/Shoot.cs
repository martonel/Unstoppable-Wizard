using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject spawnPos;
    private GameObject ward;
    public GameObject projectile;
    private GameObject originalProjectile;

    public float SpeedBetweenTwoShoot;
    private float OriginalSpeedBetweenTwoShoot;
    public float ShootSpeed;
    private bool isShoot;

    private float changeTimer=0;
    // Start is called before the first frame update
    void Start()
    {
        originalProjectile = projectile;
        OriginalSpeedBetweenTwoShoot = SpeedBetweenTwoShoot;
        ward = this.gameObject;
        isShoot = false;
        StartCoroutine(WaitTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (isShoot)
        {
            StartCoroutine(WaitTime());
            GameObject projectileInstance = Instantiate(projectile, spawnPos.transform.position, ward.transform.rotation);
            isShoot = false;
        }
        if (changeTimer >= 0)
        {
            changeTimer -= Time.deltaTime;
        }
        else
        {
            SpeedBetweenTwoShoot = OriginalSpeedBetweenTwoShoot;
            projectile = originalProjectile;
        }
    }


    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(SpeedBetweenTwoShoot);
        isShoot = true;
    }

    public void SetNewSpell(float speed, float timer)
    {
        SpeedBetweenTwoShoot = speed;
        changeTimer = timer;
    }
    public void SetProjectile(GameObject newProjectile)
    {
        projectile = newProjectile;
    }
}
