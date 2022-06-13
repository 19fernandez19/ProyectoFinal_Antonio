using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class Reloj : MonoBehaviour
{
    //esta clase se usa en el partido clasico, ya que es el unico modo que se usa el cronometro/reloj
    public Image realmadrid2;
    public Image spotify2;
    public Image simboloIgual;

    //el tiempo que le quieres poner al cronometro/reloj y a la velocidad que quieres que vaya, la normal es 1 si le pones 2 iria el doble de rapido
    [Tooltip("Tiempo inicial en segundos")]
    public int tiempoInicial;
    [Tooltip("Escala del tiempo del reloj")]
    [Range(-10.0f,10.0f)]
    public float escalaDeTiempo = 1;

    //Objetos de imagen
    public Image imagenGanador;
    public Image imagenGanador2;

    public Image imagenJugador1;
    public Image imagenJugador2;
    public Image realmadrid;
    public Image spotify;

    private Text myText;
    private float tiempoDelFrameConTimeScale = 0f;
    private float tiempoAMostrarEnSegundos = 0f;
    private float escalaDelTiempoAlPausar, escalaDelTiempoInicial;
    private bool estaPausado = false;

    [SerializeField] Marcador j1,j2;


    // Start is called before the first frame update
    void Start()
    {
        //Establecer la escala de tiempo original
        escalaDelTiempoInicial = escalaDeTiempo;

        //obtener el componente text
        myText = GetComponent<Text>();

        //Inicializamos la variable que acumula los tiempos de cada frame con el tiempo inicial
        tiempoAMostrarEnSegundos = tiempoInicial;

        ActualizarReloj(tiempoInicial);
    }

    // Update is called once per frame
    void Update()
    {
        //el update recorre en cada frame o cada fotograma del juego
        if (!estaPausado)
        {
            //La siguiente variable representa el tiempo de cada frame considerando la escala de tiempo
            tiempoDelFrameConTimeScale = Time.deltaTime * escalaDeTiempo;
            //La siguiente variable va acumulando el tiempo transcurrido para luego mostrarlo en el reloj
            tiempoAMostrarEnSegundos += tiempoDelFrameConTimeScale;
            ActualizarReloj(tiempoAMostrarEnSegundos);

            if (tiempoAMostrarEnSegundos <= 0f)
            {
                if (j1.getGoles() > j2.getGoles())
                {
                    
                    imagenGanador.gameObject.SetActive(true);
                    imagenGanador2.gameObject.SetActive(true);
                    imagenJugador2.gameObject.SetActive(true);
                    spotify.gameObject.SetActive(true);
                    
                    
                }else if (j1.getGoles() < j2.getGoles())
                {
                    
                    imagenGanador.gameObject.SetActive(true);
                    imagenGanador2.gameObject.SetActive(true);
                    imagenJugador1.gameObject.SetActive(true);
                    realmadrid.gameObject.SetActive(true);
                }
                else
                {
                    imagenGanador2.gameObject.SetActive(true);
                    spotify2.gameObject.SetActive(true);
                    realmadrid2.gameObject.SetActive(true);
                    simboloIgual.gameObject.SetActive(true);
                }

                //textoGanadorFinal.gameObject.SetActive(true);
                //Parar el partido
                Time.timeScale = 0;
            }
        }
        
    }

    public void ActualizarReloj(float tiempoEnSegundos)
    {
        int minutos = 0;
        int segundos = 0;
        string textoDelReloj;

        //Asegurar que el tiempo no sea negativo
        if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

        //Calcular minutos y segundos
        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;

        //Crear la cadena de caracteres con 2 dígitos para los minutos y segundos, separados por ":"
        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00");

        //Actualizar el elemento text de UI con la cadena de caracteres
        myText.text = textoDelReloj;
    }

}
