using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollition : MonoBehaviour
{
    // Start is called before the first frame update

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

  


}
