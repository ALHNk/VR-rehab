using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeUIManagement : MonoBehaviour
{
    public Text ScoreText;
    public Dropdown QuanityDropdown;
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
    }
    public void setTextOfObjects()
    {
        objectsText.text = "OBJECTS IN LEVEL: " + PlayerPrefs.GetInt("ObjectsQuantity");
    }

    public void SetObjectsQuantity()
    {
        int index = QuanityDropdown.value;
        int quanityFromDropDown = int.Parse(QuanityDropdown.options[index].text);
        PlayerPrefs.SetInt("ObjectsQuantity", quanityFromDropDown);
    }
    public void playLevel(int levelIndex)
    {
        SceneManager.LoadScene("Level" + levelIndex.ToString());
    }

}
