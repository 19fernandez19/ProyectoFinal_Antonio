using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class GolDeOro : MonoBehaviour
{
    //Objetos de tipo Texto y Tipo Imagen
    public Text textoGanadorFinal;

    [SerializeField] Text j1,j2;

    public Image imagenGanador;
    public Image imagenGanador2;

    public Image imagenJugador1;
    public Image imagenJugador2;
    public Image realmadrid;
    public Image spotify;


    // Lo que quieres que pase al principio de la ejecución
    void Start()
    {
        
    }

    //Metodo UPDATE lo que hace es lo que quieres que ocurrar durante la ejecución
    //el update recorre en cada frame o cada fotograma del juego
    void Update()
    {
        //Condiciones para determinar el ganador
        if (j1.text == "1" || j2.text == "1")
        {
            if (int.Parse(j1.text) > int.Parse(j2.text))
            {
                textoGanadorFinal.text = "REAL MADRID CF!!";
                imagenGanador.gameObject.SetActive(true);
                imagenGanador2.gameObject.SetActive(true);
                imagenJugador1.gameObject.SetActive(true);
                realmadrid.gameObject.SetActive(true);
            }
            else if (int.Parse(j1.text) < int.Parse(j2.text))
            {
                textoGanadorFinal.text = "SPOTIFY CF!!";
                imagenGanador.gameObject.SetActive(true);
                imagenGanador2.gameObject.SetActive(true);
                imagenJugador2.gameObject.SetActive(true);
                spotify.gameObject.SetActive(true);
            }
       
            textoGanadorFinal.gameObject.SetActive(true);
            //cuando alguno de los dos jugadores marque gol que el juego se pare
            Time.timeScale = 0;
            
        }
        
    }

}
