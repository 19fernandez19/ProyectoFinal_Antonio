using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Manejo de escenas (para cambiar de escena)

public class Script : MonoBehaviour
{
    //Script para cambiar de escena
    public int numeroEscena;

    //buildsettings
    public void cambiarEscena(int nombreEscena)
    {
        //se pone esto ya que, cuando eches un partido el time.scale es 0 en todo el juego, es decir esta congelado todo el juego
        //entonces se pone 1 para que cuando vuelvas a cambiar de escena no este congelado
        Time.timeScale = 1;
        //cambiar de escena
        SceneManager.LoadScene(numeroEscena);
    }
  
        
}
