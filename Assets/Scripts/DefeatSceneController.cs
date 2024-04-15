using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatSceneController : MonoBehaviour
{
    //Metodo para llamar a la escena del menú.
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene"); //Llama a la escena "MenuScene"
    }

    //Metodo para llamar a la escena del juego.
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");//Llama a la escena "GameScene"
    }
}