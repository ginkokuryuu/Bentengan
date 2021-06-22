using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb2d;
    private float xAxis = 0f;
    private float yAxis = 0f;
    Vector2 velocityVector = new Vector2();
    PhotonView photonView;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
            return;
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        velocityVector.Set(xAxis, yAxis);
        velocityVector = velocityVector * moveSpeed;
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine)
            return;
        rb2d.velocity = velocityVector;
    }
}
