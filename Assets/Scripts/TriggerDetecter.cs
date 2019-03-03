using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TriggerDetecter : MonoBehaviour
{
    public AudioSource _fightMusic;
    public AudioSource _softMusic;

    public AudioMixerSnapshot _fightSnapshot;
    public AudioMixerSnapshot _softSnapshot;     

    private void OnTriggerEnter(Collider other)
    {
        _fightSnapshot.TransitionTo(1.0f);
    }

    private void OnTriggerExit(Collider other)
    {
        _softSnapshot.TransitionTo(1.0f);
    }
}
