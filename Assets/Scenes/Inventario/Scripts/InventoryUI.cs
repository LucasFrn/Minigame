using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;       // Refer�ncia ao invent�rio
    public Transform itemPanel;       // Painel onde os slots ser�o exibidos
    public GameObject itemSlotPrefab; // Prefab do slot de item

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (inventory == null)
        {
            Debug.LogError("InventoryUI: Refer�ncia ao invent�rio est� nula!");
            return;
        }

        if (itemPanel == null)
        {
            Debug.LogError("InventoryUI: Refer�ncia ao painel de itens est� nula!");
            return;
        }

        if (itemSlotPrefab == null)
        {
            Debug.LogError("InventoryUI: Prefab de slot de item est� nulo!");
            return;
        }

        // Limpa os slots antigos
        foreach (Transform child in itemPanel)
        {
            Destroy(child.gameObject);
        }

        // Cria novos slots
        foreach (var item in inventory.items)
        {
            GameObject slot = Instantiate(itemSlotPrefab, itemPanel);

            // Verifica componentes do prefab
            var itemName = slot.transform.Find("itemName");
            var itemQuantity = slot.transform.Find("itemQuantity");
            var itemIcon = slot.transform.Find("itemIcon");

            if (itemName == null || itemQuantity == null || itemIcon == null)
            {
                Debug.LogError("InventoryUI: O prefab n�o cont�m os componentes esperados!");
                continue;
            }

            itemName.GetComponent<Text>().text = item.itemName;
            itemQuantity.GetComponent<Text>().text = $"x{item.itemQuantity}";
            itemIcon.GetComponent<Image>().sprite = item.itemIcon;
        }
    }

}
