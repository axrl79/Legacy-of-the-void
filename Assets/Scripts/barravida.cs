using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class barravida : MonoBehaviour
{
    public Image rellenoBarraVida; 
    private Personaje personaje;   
    private float vidaMaxima;

    void Start()
    {
        personaje = GameObject.Find("personaje").GetComponent<Personaje>(); 
        vidaMaxima = personaje.vida;  
    }

    public void ActualizarBarraVida(int vidaActual)
    {
        rellenoBarraVida.fillAmount = (float)vidaActual / vidaMaxima;
    }
}