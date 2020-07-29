using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogFactory : MonoBehaviour
{
    private static DogFactory instance;
    private static int randomCount;

    [SerializeField]
    private Sprite[] sprites;
    private List<int> dogMemory = new List<int>();

    public static bool MemoryContains(int index)
    {
        return instance.dogMemory.Contains(index);
    }

    public static void SetRandomDog(Dog dog)
    {
        int randomOfMemory = instance.dogMemory[Random.Range(0, instance.dogMemory.Count)];
        int randomOfAll = Random.Range(0, instance.sprites.Length);
        int index = randomCount < 2 ? randomOfMemory : randomOfAll;

        dog.Image.sprite = instance.sprites[index];
        dog.Image.SetNativeSize();
        dog.Index = index;
        randomCount++;
    }

    public void RememberDog(Transform allDogs)
    {
        dogMemory.Clear();
        var list = Enumerable.Range(0, sprites.Length).ToList();
        var dogs = allDogs.GetChild((int)GameManager.instance.StageDifficulty);

        for (int i = 0; i < dogs.childCount; i++)
        {
            int index = Random.Range(0, list.Count);
            int randomNum = list[index];
            var dogImage = dogs.GetChild(i).GetComponent<Image>();

            dogMemory.Add(randomNum);
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
