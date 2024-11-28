using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;       // Referência ao inventário
    public Transform itemPanel;       // Painel onde os slots serão exibidos
    public GameObject itemSlotPrefab; // Prefab do slot de item

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        // Limpa os slots antigos
        foreach (Transform child in itemPanel)
        {
            Destroy(child.gameObject);
        }

        // Cria novos slots
        foreach (var item in inventory.items)
        {
            GameObject slot = Instantiate(itemSlotPrefab, itemPanel);

            // Localiza os componentes no prefab
            var itemName = slot.transform.Find("itemName");
            var itemQuantity = slot.transform.Find("itemQuantity");
            var itemIcon = slot.transform.Find("itemIcon");

            if (itemName == null || itemQuantity == null || itemIcon == null)
            {
                Debug.LogError("InventoryUI: Componentes esperados não encontrados no prefab!");
                continue;
            }

            // Verifica e atualiza o nome
            var nameText = itemName.GetComponent<Text>();
            if (nameText != null)
            {
                nameText.text = item.itemName;
            }
            else
            {
                Debug.LogError("InventoryUI: Componente 'Text' não encontrado em itemName!");
            }

            // Verifica e atualiza a quantidade
            var quantityText = itemQuantity.GetComponent<Text>();
            if (quantityText != null)
            {
                quantityText.text = $"x{item.itemQuantity}";
            }
            else
            {
                Debug.LogError("InventoryUI: Componente 'Text' não encontrado em itemQuantity!");
            }

            // Verifica e atualiza o ícone
            var iconImage = itemIcon.GetComponent<Image>();
            if (iconImage != null)
            {
                if (item.itemIcon != null)
                {
                    iconImage.sprite = item.itemIcon;
                }
                else
                {
                    Debug.LogWarning($"Item '{item.itemName}' não possui um ícone atribuído!");
                    iconImage.color = Color.clear; // Torna o ícone invisível
                }
            }
            else
            {
                Debug.LogError("InventoryUI: Componente 'Image' não encontrado em itemIcon!");
            }
        }
    }

}

