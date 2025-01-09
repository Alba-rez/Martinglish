using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed; // Velocidad de movimiento del jugador
    [SerializeField] float jumpSpeed; // Velocidad del salto

    Rigidbody2D rb; // Componente para la física 2D
    Collider2D col; // Componente para detectar colisiones
    Animator anim; // Componente para manejar las animaciones del jugador
    bool jump; // Flag para controlar si el jugador debe saltar
    float movex; // Variable para almacenar la entrada del movimiento horizontal

    // Referencia a la posición inicial del jugador
    public Vector3 startPosition;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

        // Guardar la posición inicial del jugador para poder reiniciar
        startPosition = transform.position;

    }

    void FixedUpdate()
    {
        Walk(); // caminar con el jugador
        Flip(); // cambiar de dirección
        Jump(); // saltar
    }


    void Update()
    {
        movex = Input.GetAxisRaw("Horizontal"); // Obtiene la entrada del jugador para el movimiento horizontal
        if (!jump && Input.GetButtonDown("Jump"))  // Si el jugador no está saltando y presiona el botón de salto, activa el salto

        {
            jump = true;
        }

    }
    void Walk()
    {
        Vector2 vel = new Vector2(movex * speed * Time.fixedDeltaTime, rb.velocity.y); // Calcula la velocidad horizontal con la entrada del jugador, y mantiene la velocidad vertical actual

        rb.velocity = vel;
        if (Mathf.Abs(rb.velocity.x) > Mathf.Epsilon) // Si el jugador se está moviendo, activa la animación de caminar

        {

            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);

        }

    }

    void Flip() // Método que maneja la rotación del jugador para que mire en la dirección del movimiento

    {
        float vx = rb.velocity.x;
        if (Mathf.Abs(vx) > Mathf.Epsilon) // Si el jugador se está moviendo, gira el sprite para que mire hacia la dirección del movimiento

        {
            transform.localScale = new Vector2(Mathf.Sign(vx), 1); // Invierte el eje X si es necesario
        }
    }
    void Jump()
    {
        if (!jump) return;// Si no se debe saltar, salimos del método


        jump = false; // Reseteamos la bandera de salto

        if (!col.IsTouchingLayers(LayerMask.GetMask("Terrain", "Platforms", "Traps"))) // Si el jugador no está tocando el terreno, las plataformas o las trampas, no puede saltar

            return;

        rb.velocity += new Vector2(0, jumpSpeed); // Si está tocando el suelo o una plataforma, le damos velocidad en el eje Y para hacer el salto

        anim.SetTrigger("isJumping");// Activa la animación de salto
    }





}
