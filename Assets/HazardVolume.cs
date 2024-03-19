using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HazardVolume : MonoBehaviour
{
    public UnityEvent OnEnter;

    // TODO: Add audio/visual feedback that player exploded lol
    public void Enter()
    {
        OnEnter?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Enter();
        }
    }
}
