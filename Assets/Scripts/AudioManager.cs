using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource sfx;

    public AudioSource Sfx { get => sfx; set => sfx = value; }

    // Start is called before the first frame update
    public void ReproducirSonido(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
}
