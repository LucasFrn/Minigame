using UnityEngine;
using UnityEngine.UI;

public class ItensManager : MonoBehaviour
{
    public Inventory playerInventory;

    void Start()
    {
        Item potion = new Item
        {
            itemName = "Potion",
            itemIcon = Resources.Load<Sprite>("PotionIcon"), // Substitua pelo caminho do sprite
            itemQuantity = 0
        };

        Item shovel = new Item
        {
            itemName = "Shovel",
            itemIcon = Resources.Load<Sprite>("ShovelIcon"), // Substitua pelo caminho do sprite
            itemQuantity = 0
        };
        

        // Adiciona itens ao inventário
        playerInventory.AddItem(potion);
        playerInventory.AddItem(shovel);

        // Atualiza a UI do inventário
        FindObjectOfType<InventoryUI>().UpdateUI();
        
    }       
}
 
