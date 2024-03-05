using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UseShoot : MonoBehaviour
{
    [SerializeField] private LayerMask _layersToShoot = -1; //Defaulting to -1 results in it defaulting to every layer
    [SerializeField] private float _shootDistance = 30; //How far shoot projectile flies
    [SerializeField] private Camera _camera;

	public void OnShoot(InputValue value)
	{
        if (value.isPressed)
        {
            Shoot();
        }
	}

    private void Shoot()
    {
        Vector3 rayStartPos = _camera.transform.position;
        Vector3 rayDirection = _camera.transform.forward;
        Debug.DrawRay(rayStartPos, rayDirection * _shootDistance, 
            Color.cyan, 1); //Draws line in scene view
        
        RaycastHit hitInfo;

        if(Physics.Raycast(rayStartPos, rayDirection, out hitInfo,
            _shootDistance, _layersToShoot))
        {
            Debug.Log("Shoot!");
        }
    }
}
