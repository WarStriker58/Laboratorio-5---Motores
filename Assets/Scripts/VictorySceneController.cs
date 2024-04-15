using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictorySceneController : MonoBehaviour
{
    //Metodo para cargar la escena del menu principal
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    //Metodo para cargar la escena del juego
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}