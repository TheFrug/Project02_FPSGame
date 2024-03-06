using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public void Break()
    {
        //TODO add crumbly particles
        //TODO add screenshake
        gameObject.SetActive(false);
    }
}
