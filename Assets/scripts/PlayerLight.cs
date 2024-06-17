using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; 

public class PlayerLight : MonoBehaviour
{
    public Light2D flashlight;
    private Vector3 mousePos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (flashlight.intensity == 0) flashlight.intensity = 1; 
            else if (flashlight.intensity == 1) flashlight.intensity = 0;
        }

        //Convertir la posicion del mouse en pantalla en una posicion en el mundo de juego
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Determinar la distancia entre el cursor del mouse y el player
        Vector3 distance = mousePos - transform.position;

        //Obtengo el valor de los grados de rotacion en base al vector de distancia 
        float rotZ = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;

        //Hago que la linterna rote al valor que he obtenido de los grados
        flashlight.transform.rotation = Quaternion.Euler(0, 0, rotZ - 90);
    }
}
