using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverJugador : MonoBehaviour
{
    //variables para como quieres que se mueva tu jugador
    public float velocidad;
    public float fuerzaSalto;
    public int saltosMaximos;

    //Donde se va a apoyar el jugador
    public LayerMask capaSuelo;

    //Objetos para que el jugador pueda moverse (RIGIDBODY) y que se pueda chocar (BOXCOLLIDER)
    private new Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;

    //Variables
    private bool mirandoDerecha = true;
    public int saltosRestantes;

    //Botones para que se pueda mover el personaje
    public KeyCode botonSaltar;
    public KeyCode botonDerecha;
    public KeyCode botonIzquierda;

    //Animación del personaje
    private Animator animator;


    private void Start()
    {
        //Que el objeto, en este caso el jugador, se pueda mover, se pueda chocar, pueda saltar y tenga la animación desde un principio
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        //al empezar el juego que tenga todos los saltos disponibles
        saltosRestantes = saltosMaximos;
        animator = GetComponent<Animator>();
    }

    // El metodo update son los metodos donde se van a ejecutar mientras el juego este funcionando
    void Update()
    {
        procesarMovimiento();
        procesarSalto();
    }

    //Para devolver una respuesta de verdadero o falso de si el jugador esta pisando o no
    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }
    public bool estaenelsuelito;
    void procesarSalto()
    {
        estaenelsuelito = EstaEnSuelo();
        if (EstaEnSuelo())
        {
            saltosRestantes = saltosMaximos;
        }

        //cuando presiones el espacio y tengas mas de 0 saltos
        if (Input.GetKeyDown(botonSaltar) && saltosRestantes > 0) 
        {
            //cada vez que le des al espacio tienes un salto menos
            saltosRestantes = saltosRestantes - 1;
            //el rigidbody se encarga de las fisicas del personaje
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
            //Esta parte significa que cuando le des al espacio cuanto quieres que suba el jugador para arriba
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    void procesarMovimiento() {  

        //Logica de movimiento, es decir se movera izquierda a derecha y al reves
        float inputMovimiento = Input.GetKey(botonIzquierda) ?-1:0;
        inputMovimiento += Input.GetKey(botonDerecha) ? +1 : 0;

        if (inputMovimiento != 0f)
        {
            animator.SetBool("isRunning", true); //el valor que le queremos asignar
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        //la velocidad con la que quieres que se mueva tu personaje
        rigidbody.velocity = new Vector2(inputMovimiento * velocidad, rigidbody.velocity.y);

        //llamas aqui al metodo para que cada vez que cambies de tecla se gire el jugador
        gestionarOrientacion(inputMovimiento);
    }

    //metodo que hace que se gire el jugador a la izquierda o derecha
    void gestionarOrientacion(float inputMovimiento)
    {
        //Si el jugador esta mirando a la derecha y pulsa la tecla <-, que la orientación es negativa (-1) al pulsar <- 
        //se girara el jugador a la izquierda y lo mismo al mirar a la izquierda
        if ((mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0))
        {
            //si cumple cualquier condicion hara justamente lo contrario 
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);        
        }
    }
}
