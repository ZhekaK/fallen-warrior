using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrulEnemy : MonoBehaviour
{
    public float speed;
    public float positionOfPatrul;
    public Transform point;
    bool moviengRight;
    bool facingRight;

    Transform player;
    public float stoppingDistance;
    bool chill = false;
    bool angry = false;
    bool goBack = false;

    public float move;
    public float hhh;
    public float crya;
    public float cryaa;

    public bool running;
    public Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        move = transform.position.x;
        crya = speed;
        cryaa = speed;
    }


    void Update()
    {
        speed = cryaa;
        move = transform.position.x;
        if(Vector2.Distance(transform.position, point.position) < positionOfPatrul && angry == false)
        {
            chill = true;
        }
        if(Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }

        if(chill == true)
        {
            Chill();
        }
        else if(angry == true)
        {
            Angry();
        }
        else if(goBack == true)
        {
            GoBack();
        }
        hhh = move - transform.position.x;
        if(facingRight == false && hhh < 0)
        {
            Flip();
        }
        else if (facingRight == true && hhh > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Chill()
    {
        if(!running)
        {
            if(transform.position.x > point.position.x + positionOfPatrul)
            {
                moviengRight = false;
            }
            else if(transform.position.x < point.position.x - positionOfPatrul)
            {
                moviengRight = true;
            }
            if(moviengRight)
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            }
        }
        if(running)
        {
            if(transform.position.x > point.position.x + positionOfPatrul)
            {
                moviengRight = false;
            }
            else if(transform.position.x < point.position.x - positionOfPatrul)
            {
                moviengRight = true;
            }
            if(moviengRight)
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            }
            anim.SetBool("running", false);
        }
    }

    void Angry()
    {
        if(!running)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        if(running)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            anim.SetBool("running", true);
        }
    }

    void GoBack()
    {
        if(!running)
        {
            transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        }
        if(running)
        {
            transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
            anim.SetBool("running", true);
        }    
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            cryaa = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            cryaa = crya;
        }
    }
}
