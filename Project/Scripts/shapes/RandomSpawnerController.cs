using UnityEngine;

public class RandomSpawnerController : MonoBehaviour
{
    public GameObject[] spawners;

    public void Start()
    {
        randomSpawn(-1);
    }
    public void randomSpawn(int extraNumber)
    {
        int index;
        do
        {
            index = Random.Range(0, spawners.Length);
        }
        while (index == extraNumber);

        ObjectSpawner spawner = spawners[index].GetComponent<ObjectSpawner>();
        spawner.spawn();
    }
}
