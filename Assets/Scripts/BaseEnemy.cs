using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// Base enemy class. 
/// Other classes of enemies should inherit from it and override
/// some of the variables and future methods.
/// Methods like "die", "jump" and things like that could be 
/// defined here.
public class BaseEnemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce;
    public float roundCheckRadius;
    public bool isGrounded;
    public int jumpsMax;
    public int health = 50; // Default health to prevent errors
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    public Rigidbody2D theRB;
    public Transform enemyTransform;
    public float rotationSpeed = 10f;
    public Vector3 upAxis = new Vector3(0f, 0f, -1f);


    void FixedUpdate()
    {
    }

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    }
}