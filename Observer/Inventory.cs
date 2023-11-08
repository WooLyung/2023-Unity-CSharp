using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public interface Observer
    {
        void OnRegister((string, uint)[] inventory);
        void OnSlotChanged(int slot, string name, uint count);
    }

    private (string, uint)[] inventory = new (string, uint)[10];
    private List<Observer> observers = new();

    public void ChangeSlot(int slot, string name, uint count)
    {
        inventory[slot] = (name, count);
        foreach (Observer observer in observers)
            observer.OnSlotChanged(slot, name, count);
    }

    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
        observer.OnRegister(inventory);
    }
}
