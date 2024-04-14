using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeDisplay : MonoBehaviour
{
    public Text timeText; // Referencia al componente Text donde mostrar el tiempo del juego

    private float gameTime = 0f; // Tiempo de juego acumulado

    void Update()
    {
        // Actualiza el tiempo de juego acumulado
        gameTime += Time.deltaTime;

        // Convierte el tiempo de juego acumulado a un formato legible (minutos:segundos)
        string minutes = Mathf.Floor(gameTime / 60).ToString("00");
        string seconds = (gameTime % 60).ToString("00");

        // Actualiza el texto mostrado con el tiempo de juego
        timeText.text = "Time: " + minutes + ":" + seconds;
    }
}