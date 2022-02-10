using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    int leftUp, rightUp;
    public float speed;
    public bool leftPlayer;

    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(leftPlayer)
        {
            if (Input.GetKey(KeyCode.W))
                leftUp = 1;
            if (Input.GetKey(KeyCode.S))
                leftUp = -1;

            rigidbody.AddForce(Vector2.up * leftUp * speed * Time.deltaTime);
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
                rightUp = 1;
            if (Input.GetKey(KeyCode.DownArrow))
                rightUp = -1;

            rigidbody.AddForce(Vector2.up * rightUp * speed * Time.deltaTime);
        }
    }
}
