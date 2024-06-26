using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController1 : MonoBehaviour
{
    public float moveSpeed = 3f;//Velocidad del enemigo 1
    public float leftLimit = -12.5f;//Limite izquierdo del enemigo 1
    public float rightLimit = 4.5f;//Limite derecho del enemigo 1
    private bool movingRight = true;//Indica si el enemigo est� movi�ndose hacia la derecha

    void Update()
    {
        //Si el enemigo se mueve hacia la derecha, lo desplaza hacia la derecha
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        //Si el enemigo se mueve hacia la izquierda, lo desplaza hacia la izquierda
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        //Si el enemigo alcanza el limite derecho, cambia la direccion a la izquierda
        if (transform.position.x >= rightLimit)
        {
            movingRight = false;
        }
        //Si el enemigo alcanza el limite izquierdo, cambia la direccion a la derecha
        else if (transform.position.x <= leftLimit)
        {
            movingRight = true;
        }
    }
}