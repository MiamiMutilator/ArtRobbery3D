using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public float pickingUp = 0;
    public bool canPickUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Jewel"))
        {
            
            if (Input.GetKey(KeyCode.E))
            {
                canPickUp = true;
                pickingUp += .1f;
                if(pickingUp >= 10)
                {
                    Destroy(other.gameObject);
                }
            }
            else
            {
                pickingUp = 0;
            }
            
        }
    }
}
