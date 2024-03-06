using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Level01Controller level01Controller;

    [SerializeField] private int _currentHealth = 3;

    [SerializeField] private Shootable _shootable;
    private AudioSource audioSource;
    public AudioClip damageSound;

    /*
    //Variables used to make damage flash effect
    MeshRenderer meshRenderer;
    Color origColor;
    float flashTime = .15f;
    */

    private void OnEnable()
    {
        //watch Shot event
        if (_shootable != null)
        {
            _shootable.Shot.AddListener(TakeDamage);
        }
    }

    private void OnDisable()
    {
        if (_shootable != null)
        {
            //stop watching shot event
            _shootable.Shot.RemoveListener(TakeDamage);
        }
    }

    private void Awake()
    {
        level01Controller = FindObjectOfType<Level01Controller>(); //Find Level01Controller in scene
        audioSource = GetComponent<AudioSource>();
    }

    //Object can take damage and eventually trigger Die()
    public void TakeDamage(int damageAmount)
    {
        AudioSource.PlayClipAtPoint(damageSound, transform.position, 1);
        _currentHealth -= damageAmount;
        Debug.Log("Health remaining: " + _currentHealth);
        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        level01Controller.IncreaseScore(10);
        transform.parent.gameObject.SetActive(false);
    }
}
