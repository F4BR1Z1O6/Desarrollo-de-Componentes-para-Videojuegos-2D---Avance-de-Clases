using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;
    private Renderer rnd;
    private float value;

    void Start()
    {
        rnd = GetComponent<Renderer>();
    }

    void Update()
    {
        value += (speed / 10 * Time.deltaTime);
        rnd.material.mainTextureOffset = new Vector2(value, 0);
    }
}
