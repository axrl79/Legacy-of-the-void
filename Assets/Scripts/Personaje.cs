using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private GameObject balaPrefab;
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private float fuerzaDisparo = 10f;

    public int vida = 3;  

    public barravida barraVidaScript;

    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();   
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); 
    }

    private void FixedUpdate()
    {
        Mover();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Disparar();
        }

        if (barraVidaScript != null)
        {
            barraVidaScript.ActualizarBarraVida(vida);
        }
    }

    private void Mover()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(horizontal, vertical);
        rig.linearVelocity = movimiento * velocidad;

        anim.SetFloat("Camina", Mathf.Abs(movimiento.magnitude));

        if (horizontal > 0)
            spriteRenderer.flipX = false;
        else if (horizontal < 0)
            spriteRenderer.flipX = true;
    }

    private void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);

        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
        if (rbBala != null)
        {
            Vector2 direccion = spriteRenderer.flipX ? Vector2.left : Vector2.right;
            rbBala.linearVelocity = direccion * fuerzaDisparo;
        }
    }

    public void RecibirDaño(int daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            vida = 0;
        }
    }
}