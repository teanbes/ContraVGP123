using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Projectile : MonoBehaviour
{
    public float lifetime;

    [HideInInspector]
    public float speed;
    public float speedUp;

    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0)
            lifetime = 2.0f;
        
        GetComponent<Rigidbody2D>().velocity = new Vector3(speed, speedUp);
        Destroy(gameObject, lifetime);    

    }

    
}
 