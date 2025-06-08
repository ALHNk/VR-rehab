using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDifficultyManager : MonoBehaviour
{
    [HideInInspector] public int LevelDifficulty;
    //for the first level from here
    [SerializeField, Header("First Level")]
    private GameObject EasyLevel;

    [SerializeField]
    private GameObject MediumLevel;

    [SerializeField]
    private GameObject HardLevel;

    //for the first level to there
   
    //for the second level

    [SerializeField, Header("Second Level")]
    public MovingObjectScript[] MovingObjects;
    [SerializeField] GameObject HardLevelObjectSpawner;

    //Saved Values of Difficulty, 
    //0 - easy
    //1 - medium
    //2 - hard
    void Start()
    {
        if (!PlayerPrefs.HasKey("Difficulty"))
        {
            PlayerPrefs.SetInt("Difficulty", 0);
        }
        LevelDifficulty = PlayerPrefs.GetInt("Difficulty");

        if (SceneManager.GetActiveScene().name == "Level1") FirstLevelSetDifficulty(LevelDifficulty);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FirstLevelSetDifficulty(int diff)
    {
        if (diff == 0)
        {
            EasyLevel.SetActive(true);
            MediumLevel.SetActive(false);
            HardLevel.SetActive(false);
        }
        else if (diff == 1)
        {
            EasyLevel.SetActive(false);
            MediumLevel.SetActive(true);
            HardLevel.SetActive(false);
        }
        else if (diff == 2)
        {
            EasyLevel.SetActive(false);
            MediumLevel.SetActive(false);
            HardLevel.SetActive(true);
        }
    }

    public void SecondLevelSetDifficulty(int diff)
    {
        foreach (MovingObjectScript objecter in MovingObjects)
        {
            objecter.changeSpeedByDifficulty(diff);
        }
        if (diff == 2)
        {
            HardLevelObjectSpawner.SetActive(true);
        }
    }
}
