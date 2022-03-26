using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject impactEffect;
    private bool collided;
    private void OnCollisionEnter(Collision co) 
    {
        if(co.gameObject.tag != "Bullet" && co.gameObject.tag != "Player" && !collided)
        {
            collided = true;
            Instantiate(impactEffect, this.gameObject.transform.position, Quaternion.identity);
            Destroy (gameObject);
        }
    }
}
