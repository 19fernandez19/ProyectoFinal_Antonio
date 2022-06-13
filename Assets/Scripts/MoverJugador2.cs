using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverJugador2 : MonoBehaviour
{

    public float velocidad2;
    public float fuerzaSalto2;
    public int saltosMaximos2;
    public LayerMask capaSuelo2;

    private Rigidbody2D rigidbody2;
    private BoxCollider2D boxCollider2;
    private bool mirandoDerecha2 = true;
    private int saltosRestantes2;

    public KeyCode botonSaltar2;
    public KeyCode botonDerecha2;
    public KeyCode botonIzquierda2;

    private Animator animator2;


    private void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        boxCollider2 = GetComponent<BoxCollider2D>();
        saltosRestantes2 = saltosMaximos2;
        animator2 = GetComponent<Animator>();
    }

    // El metodo update son los metodos donde se van a ejecutar mientras el juego este funcionando
    void Update()
    {
        procesarMovimiento2();
        procesarSalto2();
    }

    //Para devolver una respuesta de verdadero o falso de si el jugador esta pisando o no
    bool estaEnSuelo2()
    {
        RaycastHit2D rayCastHit = Physics2D.BoxCast(boxCollider2.bounds.center, new Vector2(boxCollider2.bounds.size.x, boxCollider2.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo2);
        return rayCastHit.collider != null;
    }

    void procesarSalto2()
    {
        if (estaEnSuelo2())
        {
            saltosRestantes2 = saltosMaximos2;
        }

        //cuando presiones el espacio y tengas mas de 0 saltos
        if (Input.GetKeyDown(botonSaltar2) && saltosRestantes2 > 0) 
        {
            //cada vez que le des al espacio tienes un salto menos
            saltosRestantes2 = saltosRestantes2 - 1;
            rigidbody2.velocity = new Vector2(rigidbody2.velocity.x, 0);
            //Esta parte significa que cuando le des al espacio cuanto quieres que suba el jugador para arriba
            rigidbody2.AddForce(Vector2.up * fuerzaSalto2, ForceMode2D.Impulse);
        }
    }

    void procesarMovimiento2() {

        //Logica de movimiento, es decir se movera izquierda a derecha y al reves
        float inputMovimiento2 = Input.GetKey(botonIzquierda2) ?-1:0;
        inputMovimiento2 += Input.GetKey(botonDerecha2) ? +1 : 0;

        if (inputMovimiento2 != 0f)
        {
            animator2.SetBool("isRunning", true); //el valor que le queremos asignar
        }
        else
        {
            animator2.SetBool("isRunning", false);
        }

        //la velocidad con la que quieres que se mueva tu personaje
        rigidbody2.velocity = new Vector2(inputMovimiento2 * velocidad2, rigidbody2.velocity.y);

        //llamas aqui al metodo para que cada vez que cambies de tecla se gire el jugador
        gestionarOrientacion2(inputMovimiento2);
    }

    //metodo que hace que se gire el jugador a la izquierda o derecha
    void gestionarOrientacion2(float inputMovimiento2)
    {
        //Si el jugador esta mirando a la derecha y pulsa la tecla <-, que la orientación es negativa (-1) al pulsar <- 
        //se girara el jugador a la izquierda y lo mismo al mirar a la izquierda
        if ((mirandoDerecha2 == true && inputMovimiento2 > 0) || (mirandoDerecha2 == false && inputMovimiento2 < 0))
        {
            //si cumple cualquier condicion hara justamente lo contrario 
            mirandoDerecha2 = !mirandoDerecha2;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);        
        }
    }
}
