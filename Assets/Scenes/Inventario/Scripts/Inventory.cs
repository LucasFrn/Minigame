using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // Lista de itens do invent�rio
    public int maxSlots = 20;                  // N�mero m�ximo de slots

    // M�todo para adicionar um item
    public bool AddItem(Item newItem)
    {
        if (items.Count >= maxSlots)
        {
            Debug.Log("Invent�rio cheio!");
            return false;
        }

        // Verifica se o item j� existe para aumentar a quantidade
        Item existingItem = items.Find(item => item.itemName == newItem.itemName);
        if (existingItem != null)
        {
            existingItem.itemQuantity += newItem.itemQuantity;
        }
        else
        {
            items.Add(newItem);
        }

        Debug.Log($"Item {newItem.itemName} adicionado!");
        return true;
    }

    // M�todo para remover um item
    public bool RemoveItem(string itemName, int quantity)
    {
        Item itemToRemove = items.Find(item => item.itemName == itemName);

        if (itemToRemove != null)
        {
            if (itemToRemove.itemQuantity > quantity)
            {
                itemToRemove.itemQuantity -= quantity;
                return true;
            }
            else
            {
                items.Remove(itemToRemove);
                return true;
            }
        }

        Debug.Log("Item n�o encontrado no invent�rio!");
        return false;
    }

    // M�todo para listar todos os itens
    public void ListItems()
    {
        foreach (var item in items)
        {
            Debug.Log($"{item.itemName} - Quantidade: {item.itemQuantity}");
        }
    }
}
