using UnityEngine;

public class BotDisparo : MonoBehaviour
{
    [SerializeField] private GameObject balaPrefab;  
    [SerializeField] private Transform puntoDisparo; 
    [SerializeField] private float fuerzaDisparo = 10f; 
    [SerializeField] private float tiempoEntreDisparos = 1.5f; 
    private float tiempoUltimoDisparo;  

    private void Update()
    {
        if (Time.time > tiempoUltimoDisparo)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time + tiempoEntreDisparos;
        }
    }

    private void Disparar()
    {
        
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);

        
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
        if (rbBala != null)
        {
            
            Vector2 direccion = (GameObject.FindGameObjectWithTag("Player").transform.position - puntoDisparo.position).normalized;
            rbBala.linearVelocity = direccion * fuerzaDisparo;  
        }
    }
}