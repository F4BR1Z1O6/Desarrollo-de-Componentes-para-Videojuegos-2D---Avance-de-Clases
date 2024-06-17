using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHorizontalMover : MonoBehaviour
{
    public float speed, minX, maxX;
    private float axisX;
    public Rigidbody2D rb;
    public GameObject BalaPrefab;
    public Transform shooter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movimento Horizontal
        axisX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * axisX, 0);

        //Limitar Movimiento
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y);

        //Disparo
        if(Input.GetMouseButtonDown(0)) 
        {
            Instantiate(BalaPrefab, shooter.position, BalaPrefab.transform.rotation);
        }
    }
}
