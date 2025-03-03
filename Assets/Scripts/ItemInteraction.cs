using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteraction : MonoBehaviour
{
    public float pickingUp = 0;
    public bool canPickUp = false;
    public Text itemsGrabbed;
    public int itemsTaken;
    public GameObject guard;
    public GameObject winUI;
    public GameObject pauseMenuRef;
    // Start is called before the first frame update
    void Start()
    {
        itemsTaken = 0;
    }

    // Update is called once per frame
    void Update()
    {
        itemsGrabbed.text = "Items grabbed: " + itemsTaken;

        if (itemsTaken == 6)
        {
            itemsGrabbed.text = "All items grabbed! Escape!";
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ring"))
        {
            
            if (Input.GetKey(KeyCode.E))
            {
                canPickUp = true;
                pickingUp += .1f;
                if(pickingUp >= 1)
                {
                    Destroy(other.gameObject);
                    itemsTaken++;
                }
            }
            else
            {
                pickingUp = 0;
            } 
        }
        if (other.CompareTag("Necklace"))
        {

            if (Input.GetKey(KeyCode.E))
            {
                canPickUp = true;
                pickingUp += .1f;
                if (pickingUp >= 1)
                {
                    Destroy(other.gameObject);
                    itemsTaken++;
                }
            }
            else
            {
                pickingUp = 0;
            }
        }
        if (other.CompareTag("Slab"))
        {

            if (Input.GetKey(KeyCode.E))
            {
                canPickUp = true;
                pickingUp += .1f;
                if (pickingUp >= 3)
                {
                    Destroy(other.gameObject);
                    itemsTaken++;
                }
            }
            else
            {
                pickingUp = 0;
            }
        }
        if (other.CompareTag("Painting"))
        {

            if (Input.GetKey(KeyCode.E))
            {
                canPickUp = true;
                pickingUp += .1f;
                if (pickingUp >= 3)
                {
                    Destroy(other.gameObject);
                    itemsTaken++;
                }
            }
            else
            {
                pickingUp = 0;
            }
        }
        if (other.CompareTag("Moai"))
        {

            if (Input.GetKey(KeyCode.E))
            {
                canPickUp = true;
                pickingUp += .1f;
                if (pickingUp >= 5)
                {
                    Destroy(other.gameObject);
                    itemsTaken++;
                }
            }
            else
            {
                pickingUp = 0;
            }
        }
        if (other.CompareTag("NFT"))
        {

            if (Input.GetKey(KeyCode.E))
            {
                canPickUp = true;
                pickingUp += .1f;
                if (pickingUp >= 5)
                {
                    Destroy(other.gameObject);
                    itemsTaken++;
                }
            }
            else
            {
                pickingUp = 0;
            }
        }
        if (other.CompareTag("Win") && itemsTaken == 6)
        {
            Destroy(guard.gameObject);
            winUI.SetActive(true);
            pauseMenuRef.SetActive(false);
        }
    }
}
