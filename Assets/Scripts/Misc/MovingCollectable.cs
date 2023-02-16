using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCollectable : MonoBehaviour
{
    public float speed = 6.0f;
    private Rigidbody2D rb;
    private float bound = -11.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
       
       

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < bound)
            Destroy(this.gameObject);
        
    }
  
}
