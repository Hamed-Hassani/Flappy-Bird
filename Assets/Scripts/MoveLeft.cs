using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;

    BoxCollider2D box;
    float groundWith;

    float pipeWith;
    void Start()
    {
        if (gameObject.CompareTag("Ground"))
        {
            box = GetComponent<BoxCollider2D>();
            groundWith = box.size.x;
        }
        else if (gameObject.CompareTag("Column"))
        {

            pipeWith = GameObject.FindGameObjectWithTag("Pipe").GetComponent<BoxCollider2D>().size.x;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver == false)
        {
           transform.position = new Vector2(
           transform.position.x - speed * Time.deltaTime,
           transform.position.y);
        }

        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundWith)
            {
                transform.position = new Vector2(
                    transform.position.x + 2 * groundWith,
                    transform.position.y);
            }
        }

        else if (gameObject.CompareTag("Column"))
        {
            if(transform.position.x<GameManager.bottomLeft.x - pipeWith)
            {
                Destroy(gameObject);
            }
        }
       
    }
}
