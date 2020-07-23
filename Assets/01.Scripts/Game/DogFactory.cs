using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DogFactory : MonoBehaviour
{
    private static DogFactory instance;

    [SerializeField]
    private Sprite[] sprites;
    private int dogMemory;

    public static bool MemoryContains(int mask)
    {
        return (instance.dogMemory & mask) == mask;
    }

    public static void SetRandomDog(Dog dog)
    {
        int index = Random.Range(0, instance.sprites.Length);
        dog.Image.sprite = instance.sprites[index];
        dog.Image.SetNativeSize();
        dog.Index = index;
    }

    public void RememberDog(Transform dogs)
    {
        dogMemory = 0;
        var list = Enumerable.Range(0, sprites.Length).ToList();

        for (int i = 0; i < dogs.childCount; i++)
        {
            int index = Random.Range(0, list.Count);
            int randomNum = list[index];
            var dogImage = dogs.GetChild(i).GetComponent<Image>();

            dogMemory |= 1 << randomNum;
            dogImage.sprite = sprites[randomNum];
            dogImage.SetNativeSize();

            list[index] = list.Last();
            list.RemoveAt(list.Count - 1);
        }
    }

    private void Awake()
    {
        instance = this;
    }
}
