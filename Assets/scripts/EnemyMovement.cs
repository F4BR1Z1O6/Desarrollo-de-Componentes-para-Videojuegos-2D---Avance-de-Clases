using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float fallUnits;
    private int direction = 1;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(speed * direction, 0);    
    }

    public void ChangeDirection(int value)
    {
        direction = value;
        transform.position = new Vector2(transform.position.x, transform.position.y - fallUnits);
    }
}
