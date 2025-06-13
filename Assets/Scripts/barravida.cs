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
        // Intenta obtener la vida del personaje si existe
        GameObject objPersonaje = GameObject.Find("personaje");
        if (objPersonaje != null)
        {
            personaje = objPersonaje.GetComponent<Personaje>();
            if (personaje != null)
            {
                vidaMaxima = personaje.vida;
            }
        }
    }

    public void ActualizarBarraVida(int vidaActual)
    {
        if (rellenoBarraVida != null && vidaMaxima > 0)
        {
            rellenoBarraVida.fillAmount = (float)vidaActual / vidaMaxima;
        }
    }

    // Método opcional para configurar vida desde otro script (por ejemplo, en enemigos)
    public void InicializarVidaMaxima(int vida)
    {
        vidaMaxima = vida;
        ActualizarBarraVida(vida); // Para que se vea llena al principio
    }
}
