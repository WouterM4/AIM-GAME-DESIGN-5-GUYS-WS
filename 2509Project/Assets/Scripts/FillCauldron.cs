using System;
using UnityEngine;

public class FillCauldron : MonoBehaviour
{
    private int amountOfItemsCollected;
    public int totalItems;
    public GameObject potion;
    //public static event Action<PickableItem> OnInteract;
    
    private void Start()
    {
        amountOfItemsCollected = 0;
    }

    void AddItemToCauldron(PickableItem item)
    {
        amountOfItemsCollected++;
        if (amountOfItemsCollected >= totalItems)
        {
            Instantiate(potion, new Vector3(-2, 1.5f, 5), Quaternion.Euler(0, 0, 0));
        }
    }
}
