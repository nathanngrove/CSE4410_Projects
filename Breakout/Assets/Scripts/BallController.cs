using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    GameController cont;

    Rigidbody2D ballRigidbody;

    public float speed;
    public float randomUp;

    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        cont = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        Invoke("PushBall", 1f);
    }

    void PushBall()
    {
        int dir = Random.Range(0, 2);
        float x;
        if (dir == 0)
            x = speed;
        else
            x = -speed;

        ballRigidbody.AddForce(new Vector2(x, -randomUp));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Vector2 vel;
            vel.y = ballRigidbody.velocity.y;
            vel.x = ballRigidbody.velocity.x / 2 + collision.collider.attachedRigidbody.velocity.x / 2;
            ballRigidbody.velocity = vel;
        }
        if(collision.gameObject.CompareTag("Brick"))
        {
            cont.HitBrick();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {
            cont.LoseLive();
            ballRigidbody.velocity = Vector2.zero;
            transform.position = startPosition;
            Invoke("PushBall", 2f);
        }
    }

}
