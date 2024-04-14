using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public void PauseGame()
    {
        Time.timeScale = 0f; // Reanuda el tiempo en el juego
        pauseMenuUI.SetActive(true); // Desactiva el menú de pausa
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Reanuda el tiempo en el juego
        pauseMenuUI.SetActive(false); // Desactiva el menú de pausa
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Carga la escena actual
        Time.timeScale = 1f; // Asegura que el tiempo esté reanudado
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenuScene"); // Carga la escena del menú principal
        Time.timeScale = 1f; // Asegura que el tiempo esté reanudado
    }

    public void QuitGame()
    {
        Application.Quit(); // Cierra la aplicación
    }
}