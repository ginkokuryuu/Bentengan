using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb2d;
    private float xAxis = 0f;
    private float yAxis = 0f;
    Vector2 velocityVector = new Vector2();



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        velocityVector.Set(xAxis, yAxis);
        velocityVector = velocityVector * moveSpeed;
    }

    private void FixedUpdate()
    {
        rb2d.velocity = velocityVector;
    }
}
