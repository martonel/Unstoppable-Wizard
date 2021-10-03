using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int health;
    public Slider slider;
    public bool isEnemy;
    public GameObject particle;
    public Animator EndAnim;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void PlusHealth(int number)
    {
        if (health + number > maxHealth)
        {
            health += number;
        }
        else
        {
            health = maxHealth;
        } 
        slider.value = health;

    }
    public int GetHealth()
    {
        return health;
    }
    public void GetDamage(int number)
    {
        Debug.Log(health - number);
        if (health-number <= 1)
        {
            if (isEnemy)
            {
                if (particle != null)
                {
                    Instantiate(particle, this.gameObject.transform.position, Quaternion.identity);
                }
                if (EndAnim != null)
                {
                    EndAnim.Play("YouWinAnim");
                }
                Destroy(this.gameObject);
            }
            else
            {
                EndAnim.Play("RestartAnim");
                Time.timeScale = 0.0f;
                Debug.Log("gameOver");
                health = 0;
            }

        }
        else
        {
            health--;
        }
        slider.value = health;
    }


}
