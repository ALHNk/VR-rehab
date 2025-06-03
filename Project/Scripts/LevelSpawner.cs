using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject[] Levels;
    void Start()
    {
        int random = Random.Range(0, Levels.Length);
        Levels[random].SetActive(true);
    }

}
