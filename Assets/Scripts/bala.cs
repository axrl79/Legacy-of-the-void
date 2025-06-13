using UnityEngine;

public class bala : MonoBehaviour
{
    [SerializeField] private float velocidad = 10f;      
    [SerializeField] private float tiempoVida = 3f;      

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = transform.right * velocidad;  

        Destroy(gameObject, tiempoVida);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Debug.Log("¡Impacto al enemigo!");
            collision.gameObject.GetComponent<bots>().RecibirDaño(1);  
            Destroy(gameObject);  
        }
        
        else if (collision.CompareTag("Player"))
        {
            Debug.Log("¡Impacto al jugador!");
            // Hacer daño al jugador
            collision.gameObject.GetComponent<Personaje>().RecibirDaño(1);  
            Destroy(gameObject);  
        }
        
        else
        {
            Destroy(gameObject);
        }
    }
}