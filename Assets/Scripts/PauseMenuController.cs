using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;//Es el objeto que representa el menú de pausa

    //Metodo para pausar el juego
    public void PauseGame()
    {
        Time.timeScale = 0f;//Pone el tiempo del juego en pausa
        pauseMenuUI.SetActive(true);//Activa el menu de pausa
    }

    //Metodo para reanudar el juego desde el menú de pausa
    public void ResumeGame()
    {
        Time.timeScale = 1f;//Reanuda el tiempo del juego
        pauseMenuUI.SetActive(false);//Desactiva el menu de pausa
    }

    //Metodo para reiniciar el nivel
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//Carga la escena actual de nuevo
        Time.timeScale = 1f; //Se asegura de que el tiempo del juego se reanude
    }

    //Metodo para cargar el menu principal
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenuScene");//Carga la escena del menu principal
        Time.timeScale = 1f;//Se asegura de que el tiempo del juego se reanude
    }

    //Metodo para salir del juego
    public void QuitGame()
    {
        Application.Quit();//Cierra el juego
    }
}