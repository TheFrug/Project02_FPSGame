using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UseShoot : MonoBehaviour
{
    [SerializeField] private LayerMask _layersToShoot = -1; //Defaulting to -1 results in it defaulting to every layer
    [SerializeField] private float _shootDistance = 30; //How far shoot projectile flies
    [SerializeField] private Camera _camera; 

    [SerializeField] private ParticleSystem _impactParticle;
    [SerializeField] private AudioSource _shootSound;

    private int _damageAmount = 1;

	public void OnShoot(InputValue value)
	{
        if (value.isPressed)
        {
            Shoot();
        }
	}

    private void Shoot() //Fire the laser and figure out if it triggers any shootabale objects
    {
        Vector3 rayStartPos = _camera.transform.position; //Saves camera position (which is also basically player position)
        Vector3 rayDirection = _camera.transform.forward; //Saves camera direction
        Debug.DrawRay(rayStartPos, rayDirection * _shootDistance, 
            Color.cyan, 1); //Draws line in scene view
        
        RaycastHit hitInfo;

        if(Physics.Raycast(rayStartPos, rayDirection, out hitInfo,
            _shootDistance, _layersToShoot))
        {
            //Debug.Log("Shoot!");
            //Play impact particle instance
            if(_impactParticle != null)
            {
                Instantiate //Spawns a particle burst at the point of impact
                    (_impactParticle, hitInfo.point, Quaternion.identity);
            }

            //Play shoot sound instance
            if(_shootSound != null)
            {
                AudioSource newSound = Instantiate 
                    (_shootSound, transform.position, Quaternion.identity);
                //Destroys newly created audio source after waiting for an amount of time equal to clip length (designer can change clip w/o problems
                Destroy(newSound.gameObject, newSound.clip.length);
            }

            //Search to see if hit object has component "shootable"
            Shootable shootableObject = 
                hitInfo.transform.GetComponent<Shootable>();
            if(shootableObject != null)
            {
                //TODO: If statement that detects a weak point and passes in a new damageAmount

                shootableObject.GetShot(_damageAmount); //Run GetShot method on target object
            }
        }
    }
}
