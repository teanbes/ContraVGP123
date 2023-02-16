using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public enum PickupType
    {
        Powerup,
        Life,
        Speed,
        Weapon
    }

    public PickupType currentPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerController temp = collision.gameObject.GetComponent<PlayerController>();

            switch(currentPickup) 
            {
                case PickupType.Powerup:
                    temp.StartJumpForceChange();
                    break;
                case PickupType.Life:
                    temp.lives++;
                    break;
                case PickupType.Speed:
                    temp.StartspeedChange();
                    break;
                case PickupType.Weapon:
                    temp.StartScaleChange();
                    break;

            
            }
            Destroy(gameObject);
        }
        

    }


}
