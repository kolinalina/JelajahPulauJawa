using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private bool checkTrigger;
    public float speed;
    public Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkTrigger)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
            if (transform.position.x > target.position.x)
            {
                //target is left
                transform.localScale = new Vector2(-1, 1);
            }
            else if (transform.position.x < target.position.x)
            {
                //target is right
                transform.localScale = new Vector2(1, 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            checkTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            checkTrigger = false;
        }
    }
}