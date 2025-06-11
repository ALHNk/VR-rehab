using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeUIManagement : MonoBehaviour
{
    public Text ScoreText;
	public Dropdown QuanityDropdown, DifficultyDropdown;
	public Text objectsText;
    public void Start()
    {
        if (!PlayerPrefs.HasKey("ObjectsQuantity"))
        {
            PlayerPrefs.SetInt("ObjectsQuantity", 5);
        }
        int localScore = PlayerPrefs.GetInt("Score");
        ScoreText.text = "YOUR SCORE: " + localScore.ToString();
	    setTextOfObjects();
	    setValueOfDifficultyDropdown();
    }
    public void setTextOfObjects()
    {
        objectsText.text = "OBJECTS IN LEVEL: " + PlayerPrefs.GetInt("ObjectsQuantity");
    }
	public void setValueOfDifficultyDropdown()
	{
		DifficultyDropdown.value = PlayerPrefs.GetInt("Difficulty");
	}

    public void SetObjectsQuantity()
    {
        int index = QuanityDropdown.value;
        int quanityFromDropDown = int.Parse(QuanityDropdown.options[index].text);
        PlayerPrefs.SetInt("ObjectsQuantity", quanityFromDropDown);
    }
	public void setDifficulty()
	{
		int diff = DifficultyDropdown.value;
		PlayerPrefs.SetInt("Difficulty", diff);
	}
    public void playLevel(int levelIndex)
    {
        SceneManager.LoadScene("Level" + levelIndex.ToString());
    }
	public void Treadmil()
	{
		SceneManager.LoadScene("Treadmil");
	}

}
