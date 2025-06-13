using UnityEngine;

public class bots : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private GameObject balaPrefab;
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private float fuerzaDisparo = 10f;
    [SerializeField] private int vida = 3;
    [SerializeField] private float rangoVision = 10f;
    [SerializeField] private float tiempoEntreDisparos = 1.5f;

    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Transform jugador;
    private float tiempoUltimoDisparo;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();   
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        PerseguirJugador();
    }

    private void Update()
    {
        float distancia = Vector2.Distance(transform.position, jugador.position);
        if (distancia < rangoVision && Time.time > tiempoUltimoDisparo)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time + tiempoEntreDisparos;
        }
    }

    private void PerseguirJugador()
    {
        if (jugador == null) return;

        Vector2 direccion = (jugador.position - transform.position).normalized;
        rig.linearVelocity = direccion * velocidad;

        anim.SetFloat("Camina", rig.linearVelocity.magnitude);

        // Voltear sprite
        spriteRenderer.flipX = direccion.x < 0;
    }

    private void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);

        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
        if (rbBala != null)
        {
            Vector2 direccion = (jugador.position - puntoDisparo.position).normalized;
            rbBala.linearVelocity = direccion * fuerzaDisparo;
        }
    }

    public void RecibirDaño(int daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        // Puedes poner animación, partículas, sonido aquí
        Destroy(gameObject);
    }
}
