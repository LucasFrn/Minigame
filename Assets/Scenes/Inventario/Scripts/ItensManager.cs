using UnityEngine;

public class ItensManager : MonoBehaviour
{
    public Inventory playerInventory;

    void Start()
    {
        Item potion = new Item
        {
            itemName = "Potion",
            itemIcon = Resources.Load<Sprite>("PotionIcon"), // Substitua pelo caminho do sprite
            itemQuantity = 5
        };

        Item shovel = new Item
        {
            itemName = "Shovel",
            itemIcon = Resources.Load<Sprite>("ShovelIcon"), // Substitua pelo caminho do sprite
            itemQuantity = 1
        };

        // Adiciona itens ao invent�rio
        playerInventory.AddItem(potion);
        playerInventory.AddItem(shovel);

        // Atualiza a UI do invent�rio
        FindObjectOfType<InventoryUI>().UpdateUI();
    }

}
