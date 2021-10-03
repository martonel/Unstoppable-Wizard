using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontalMove;
    private float vertivalMove;
    private Rigidbody2D rb;
    public float speed;

    private Vector2 direction;
    private bool isRotate;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        vertivalMove = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0f);


        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(direction.x > this.transform.position.x && isRotate)
        {
            transform.localRotation *= Quaternion.Euler(0, 180, 0);
            isRotate = false;
        }
        else if(direction.x < this.transform.position.x && !isRotate)
        {
            transform.localRotation *= Quaternion.Euler(0, 180, 0);
            isRotate = true;
        }
    }
}
