using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shootable : MonoBehaviour
{
    public UnityEvent<int> Shot; //Unity event needs an int to work

    public void GetShot(int damageAmount)
    {
        Debug.Log("Shot!");
        Shot?.Invoke(damageAmount); //Passes damage amount from player to object triggering event
    }
}