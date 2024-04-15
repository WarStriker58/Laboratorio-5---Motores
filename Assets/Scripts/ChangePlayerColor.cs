using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerColor : MonoBehaviour
{
    public Material playerMaterial;//Material del jugador

    Color defaultColor = Color.white;//Color original del jugador

    //Metodo para cambiar el color del jugador a rojo
    public void ChangeToRed()
    {
        playerMaterial.color = Color.red;
    }

    //Metodo para cambiar el color del jugador a azul
    public void ChangeToBlue()
    {
        playerMaterial.color = Color.blue;
    }

    //Metodo para cambiar el color del jugador a amarillo
    public void ChangeToYellow()
    {
        playerMaterial.color = Color.yellow;
    }

    void Start()
    {
        //Color predeterminado del jugador (Blanco)
        playerMaterial.color = defaultColor;
    }
}