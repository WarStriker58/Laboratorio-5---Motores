using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //Botones para iniciar y salir del juego.
    public Button playButton;
    public Button exitButton;

    void Start()
    {
        //Se añaden los listeners a los botones para detectar los clics
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    //Metodo para llamar a la escena del juego.
    void PlayGame()
    {
        SceneManager.LoadScene("GameScene");//Llama a la escena del juego.
    }

    //Metodo para salir del juego
    void ExitGame()
    {
        Application.Quit();//Sale deL juego
    }
}