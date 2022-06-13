using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class PartidoA5 : MonoBehaviour
{
    //variables de texto e imagenes

    public Text textoGanadorFinal;

    [SerializeField] Text j1,j2;

    public Image imagenGanador;
    public Image imagenGanador2;

    public Image imagenJugador1;
    public Image imagenJugador2;
    public Image realmadrid;
    public Image spotify;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //el update recorre en cada frame o cada fotograma del juego
        if (j1.text == "5" || j2.text == "5")
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
            else
            {
                textoGanadorFinal.text = "EMPATE!!";
            }
            textoGanadorFinal.gameObject.SetActive(true);
            Time.timeScale = 0;
            
        }
        
    }

}
