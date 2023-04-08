using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController<T> where T : Item
{
  private List<T> itemCollection = new List<T>();

    public void AddItem(T item)
    {
        itemCollection.Add(item);
    }
    //searches item in list with given name
    public T GetItem(string name)
    {
        foreach(T item in itemCollection)
        {
            if (item.itemName == name)
            {
                return item;
            }
        }
        return null;
    }

    public void UseItem(string name)
    {
        foreach (T item in itemCollection)
        {
            if (item.itemName == name)
            {
                item.Use();
            }
        }
    }
}
