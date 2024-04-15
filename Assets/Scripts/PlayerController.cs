using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7.5f;
    public int maxLives = 15;
    private int currentLives;
    public Text livesText;
    private Rigidbody2D rb;
    private bool isGrounded;
    public int score = 0;
    public Text scoreText;
    public CinemachineShake cinemachineShake;

    //Declaración de eventos
    public delegate void HealthUpdateEventHandler(int newHealth);
    public static event HealthUpdateEventHandler OnHealthUpdated;
    public delegate void ScoreUpdateEventHandler(int newScore);
    public static event ScoreUpdateEventHandler OnScoreUpdated;
    public delegate void DefeatEventHandler();
    public static event DefeatEventHandler OnDefeat;
    public delegate void VictoryEventHandler();
    public static event VictoryEventHandler OnVictory;

    public float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//Obtiene el componente Rigidbody2D
        currentLives = maxLives;//Inicia las vidas actuales con el maximo
        UpdateLivesText(currentLives);//Actualiza el texto de vidas
        OnHealthUpdated += UpdateLivesText;//Permite suscribirse al evento de actualizacion de vidas
        OnScoreUpdated += UpdateScoreText;//Permite suscribirse al evento de actualizacion de puntaje
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);//Calcula el movimiento
        rb.velocity = movement;//Aplica el movimiento
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<float>();//Obtiene la entrada horizontal del jugador
    }

    public void OnJump(InputAction.CallbackContext context)//Metodo que permite realizar el salto
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)//Verifica si se presiona la tecla de salto y si el jugador está en el suelo
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);//Aplica una velocidad vertical para el salto
        }
    }

    void OnCollisionEnter2D(Collision2D other)//Metodo que se ejecuta cuando se produce una colision
    {
        if (other.gameObject.CompareTag("Ground"))//Verifica si la colision es con el suelo
        {
            isGrounded = true;//Establece que el jugador esta en el suelo
        }
        else if (other.gameObject.CompareTag("Enemy 1"))
        {
            TakeDamage(1);
        }
        else if (other.gameObject.CompareTag("Enemy 2"))
        {
            TakeDamage(2);
        }
        else if (other.gameObject.CompareTag("FireBlue"))//Verifica si la colision es con el objeto de victoria
        {
            //Ejecuta la funcion de victoria
            PlayerWins();
            Victory();
        }
        else if (other.gameObject.CompareTag("LifePickup"))//Verifica si la colision es con una vida
        {
            GainLife(1);//Aumenta la cantidad de vidas
            Destroy(other.gameObject);//Destruye el objeto de vida
        }
        else if (other.gameObject.CompareTag("Coin"))//Verifica si la colision es con una moneda
        {
            AddScore(100);//Aumenta el puntaje.
            Destroy(other.gameObject);//Destruye la moneda.
        }
    }

    void OnCollisionExit2D(Collision2D other)//Metodo que se ejecuta cuando el jugador sale de una colision
    {
        if (other.gameObject.CompareTag("Ground"))//Verifica si la colision era con el suelo
        {
            isGrounded = false;//Indica que el jugador ya no esta en el suelo
        }
    }

    void TakeDamage(int damageAmount)
    {
        currentLives -= damageAmount;

        //Determina la intensidad del Screenshake basado en la cantidad de daño recibido
        float shakeIntensity = 0.5f; //Por defecto, el ScreenShake es leve

        if (damageAmount == 2)
        {
            shakeIntensity = 1.0f;//Cambia el ScreenShake a fuerte si el daño es 2
        }

        //Llama a la funcion ShakeCamera del CinemachineShake con la intensidad calculada y una duración de 1 segundo
        cinemachineShake.ShakeCamera(shakeIntensity, 1.0f);

        //Asegurarse de que las vidas no sean negativas
        currentLives = Mathf.Max(currentLives, 0);

        //Actualiza el texto de vidas
        UpdateLivesText(currentLives);

        //Verifica si el jugador ha perdido todas las vidas
        if (currentLives <= 0)
        {
            PlayerLoses();
            Die();
        }
    }

    void GainLife(int lifeAmount)//Metodo para aumentar la cantidad de vidas del jugador
    {
        currentLives += lifeAmount;//Aumenta la cantidad de vidas
        currentLives = Mathf.Min(currentLives, maxLives);// Asegurarse de que las vidas no excedan el maximo
        OnHealthUpdated?.Invoke(currentLives);//Invoca el evento de actualizacion de vidas
    }

    void AddScore(int scoreAmount)//Metodo para aumentar el puntaje del jugador
    {
        score += scoreAmount;//Aumenta el puntaje
        OnScoreUpdated?.Invoke(score);//Invoca el evento de actualizacion de puntaje
    }

    void Victory()//Metodo que carga la escena de victoria
    {
        SceneManager.LoadScene("VictoryScene");
    }

    void Die()//Metodo que carga la escena de derrota
    {
        SceneManager.LoadScene("DefeatScene");
    }

    void UpdateLivesText(int newHealth)//Metodo para actualizar el texto de vidas
    {
        if (livesText != null)//Verifica si el texto de vidas no es nulo
        {
            livesText.text = "Lives: " + newHealth.ToString();//Actualiza el texto de vidas.
        }
    }

    void UpdateScoreText(int newScore)//Metodo para actualizar el texto de puntaje
    {
        if (scoreText != null)//Verifica si el texto de puntaje no es nulo
        {
            scoreText.text = "Score: " + newScore.ToString();//Actualiza el texto de puntaje
        }
    }

    public void PlayerWins()//Metodo que invoca el evento de victoria
    {
        OnVictory?.Invoke();
    }

    public void PlayerLoses()//Metodo que invoca el evento de derrota
    {
        OnDefeat?.Invoke();
    }
}