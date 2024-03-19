using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;

    public enum State
    {
        Idle,
        Hostile
    }

    public State currentState = State.Idle;

    private void Update()
    {
        if(currentState == State.Hostile)
        {
            transform.LookAt(target);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Spotted!");
            currentState = State.Hostile;
            EnterHostileState();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Where'd they go?");
            currentState = State.Idle;
        }
    }

    private void EnterHostileState()
    {
        transform.LookAt(target);
    }
}
