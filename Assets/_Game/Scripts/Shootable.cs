using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shootable : MonoBehaviour
{
    public UnityEvent Shot;

    public void Shoot()
    {
        Shot?.Invoke();
    }

}
