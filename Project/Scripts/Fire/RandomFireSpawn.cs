using UnityEngine;

public class RandomFireSpawn : MonoBehaviour
{
    public GameObject[] fires;
    private int firesSize;
    void Start()
    {
        firesSize = fires.Length;
            foreach (GameObject fire in fires)
            {
                fire.SetActive(false);
            }
            spawn();
    }

     public void spawn()
    {
        int random = Random.Range(0, firesSize-1);
        fires[random].SetActive(true);
    }
}
