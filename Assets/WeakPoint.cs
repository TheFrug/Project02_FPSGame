using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    public GameObject mainScreen;


    private void Awake()
    {
        mainScreen = transform.Find("Screen").gameObject;
    }

    private void Update()
    {
    }
}
