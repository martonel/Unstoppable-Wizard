using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Animator anim;
    public bool isRestart;

    private void Awake()
    {
        if (!isRestart)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void SetStart()
    {
        anim.Play("StartAnim");
        Time.timeScale = 1.0f;
    }

}
