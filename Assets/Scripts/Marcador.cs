using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marcador : MonoBehaviour
{
    //Objetos para reproducir el audio de GOL cuando toque la pelota la porteria
    public AudioManager audioManager;
    public AudioClip sonidoGol;

    Vector2 velocidadInicial;
    // Start is called before the first frame update
    void Start()
    {
        //Aqui lo que hago es que la pelota al resetearla se queda en velocidad "0"
        velocidadInicial = pelota.GetComponent<Rigidbody2D>().velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] private GameObject pelota;
    [SerializeField] private GameObject jugador1;
    [SerializeField] private GameObject enemigo;

    [SerializeField] private int goles;
    [SerializeField] private Text totalGoles;



    //Este metodo lo que hace es cuando ha entrado un objeto dentro del collider de otro, en este caso que la pelota entre/toque la porteria
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Cuando toque la pelota la porteria que sume un gol, que se vea en el marcador, que se reseteen los jugadores y la pelota y que suene el audio del gol
        if(collision.gameObject.tag == "pelota")
        {
            goles++;
            totalGoles.text = goles.ToString();
            resetearPelota();
            resetearJugadores();
            audioManager.reproducirSonido(sonidoGol);
        }
    }

    public int getGoles()
    {
        return goles;
    }

    void resetearPelota()
    {
        //Que la pelota se ponga en la posición inicial
        pelota.transform.position = new Vector2(0, -2);
        //Y esto es para que la pelota no se quede con la ultima velocidad de cuando se ha marcado el gol si no que se quede quieto
        pelota.GetComponent<Rigidbody2D>().velocity = velocidadInicial;

    }

    void resetearJugadores()
    {
        //Que los jugadores se reseteen en esas coordenadas
        jugador1.transform.position = new Vector2(4, 1);
        enemigo.transform.position = new Vector2(-4,1);
    }
}
