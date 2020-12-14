using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> inventory;
    [SerializeField] float maxWeight;
    [SerializeField] float currentWeight;  
    [SerializeField] GameObject pickUpOption;
    [SerializeField] Slot[] slots;
    [SerializeField] Text inventoryMessageText;
    [SerializeField] Text weightText;
    bool canPickUp;
    GameObject collectibleObject;
    int slotCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<Item>();
        canPickUp = false;
        weightText.text = "Weight:\n" + currentWeight + "/" + maxWeight;
    }

    private void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            if (slotCounter >= slots.Length)
            {
                StartCoroutine(DisplayInventoryMessage("Your inventory is full!"));
            }
            else
            {
                foreach (Item item in collectibleObject.GetComponent<CubePickUp>().items)
                {
                    AddItem(item);
                }
            }
        }
    }

    public void AddItem(Item item)
    {       
        if (currentWeight + item.weight > maxWeight)
        {
            StartCoroutine(DisplayInventoryMessage("It weights too much!"));
        } 
        else
        {
            inventory.Add(item);
            slots[slotCounter].itemName = item.name;
            slots[slotCounter].image.sprite = item.itemImage;
            slots[slotCounter].item = item;

            currentWeight += item.weight;
            weightText.text = "Weight:\n" + currentWeight + "/" + maxWeight;
            canPickUp = false;
            ShowPickUpOption(false);
            slotCounter++;

            Destroy(collectibleObject);
            collectibleObject = null;
        }
    }

    public void ShowPickUpOption(bool isActive)
    {
        pickUpOption.SetActive(isActive);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            canPickUp = true;
            collectibleObject = other.gameObject;
            ShowPickUpOption(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            canPickUp = false;
            collectibleObject = null;
            ShowPickUpOption(false);
        }
    }

    IEnumerator DisplayInventoryMessage(string message)
    {
        inventoryMessageText.text = message;
        inventoryMessageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        inventoryMessageText.gameObject.SetActive(false);
    }
}
