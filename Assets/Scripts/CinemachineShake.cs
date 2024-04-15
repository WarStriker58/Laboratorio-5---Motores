using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }//Instancia que permite acceder a este codigo desde otros codigos

    private CinemachineVirtualCamera cinemachineVirtualCamera;//Referencia a la camara virtual de Cinemachine
    private float shakeTimer;//Tiempo restante de la sacudida
    private float shakeTimerTotal;//Duracion total de la sacudida
    private float startingIntesity;//Intensidad inicial de la sacudida

    private void Awake()
    {
        Instance = this;//Establece esta instancia como la instancia unica y accesible desde otros codigos
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>(); // Obtiene el componente CinemachineVirtualCamera adjunto a este GameObject.
    }

    // Método para sacudir la cámara con una intensidad y duración específicas.
    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); //Obtiene el componente CinemachineBasicMultiChannelPerlin para ajustar la sacudida

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;//Establece la intensidad de la sacudida

        startingIntesity = intensity;//Guarda la intensidad inicial
        shakeTimerTotal = time;//Establece el tiempo total de la sacudida
        shakeTimer = time;//Reinicia el temporizador de la sacudida
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;//Reduce el tiempo de la sacudida
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();//Obtiene el componente CinemachineBasicMultiChannelPerlin

            //Interpola suavemente entre la intensidad inicial y cero a medida que pasa el tiempo
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain =
                Mathf.Lerp(startingIntesity, 0f, 1 - (shakeTimer / shakeTimerTotal));
        }
    }
}