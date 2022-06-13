using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creas un componente en el inspector que es el AudioSource
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //Coges el AudioSource al principio de la ejecución
        audioSource = GetComponent<AudioSource>();
    }

    //metodo para reproducir el sonido
    public void reproducirSonido(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
