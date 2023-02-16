using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectibles : MonoBehaviour
{
    public List<GameObject> collectibles;
   
    // Start is called before the first frame update
    void Start()
    {
        if(collectibles.Count > 0) 
        {
            int index = Random.Range(0, collectibles.Count);
            Instantiate(collectibles[index], transform.position, transform.rotation);
                
         }
    }
}
