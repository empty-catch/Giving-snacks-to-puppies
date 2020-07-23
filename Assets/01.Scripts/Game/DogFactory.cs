using System.Linq;
using UnityEngine;

public class DogFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Sprite[] dogs;

    private int dogMemory;

    public void RememberDog()
    {
        dogMemory = 0;
        var list = Enumerable.Range(0, dogs.Length).ToList();

        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, list.Count);
            dogMemory |= 1 << list[index];
            list[index] = list.Last();
            list.RemoveAt(list.Count - 1);
        }
    }
}
