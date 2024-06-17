using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Left")
        {
            transform.parent.GetComponent<EnemyMovement>().ChangeDirection(1); 
        }
        if(collision.name == "Right")
        {
            transform.parent.GetComponent<EnemyMovement>().ChangeDirection(-1);
        }
        if(collision.tag == "Bala")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
