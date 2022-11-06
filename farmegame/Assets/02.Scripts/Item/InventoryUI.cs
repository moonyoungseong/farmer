using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool activelnventory = false;
    
    void Start()
    {
        inventoryPanel.SetActive(activelnventory);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            activelnventory = !activelnventory;
            inventoryPanel.SetActive(activelnventory);
        }
    }
}
