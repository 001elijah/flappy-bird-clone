using System;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool isBirdAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isBirdAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }

        if (transform.position.y > 14 || transform.position.y < -14)
        {
            logic.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        logic.GameOver();
        isBirdAlive = false;
    }
}