using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public bool isMove;
    private GameObject playerPrefab;
    public GameObject[] players;
    public float speed;
    public float finalDistance;
    private bool isRotate;
    // Start is called before the first frame update
    void Start() { 
    players = GameObject.FindGameObjectsWithTag("Player");
	if(players.Length!=0){
	    playerPrefab = players[0].gameObject;
	}
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            float distance = Vector2.Distance(transform.position, playerPrefab.transform.position);
            if (distance > finalDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerPrefab.transform.position, speed * Time.deltaTime);
            }
            if (distance < finalDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerPrefab.transform.position, -1 * speed * Time.deltaTime);
            }
            if (playerPrefab.transform.position.x > this.transform.position.x && isRotate)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                isRotate = false;
            }
            else if (playerPrefab.transform.position.x < this.transform.position.x && !isRotate)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                isRotate = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "sleep")
        {
            isMove = true;
            Debug.Log("életre keltek!");
        }
    }
}
