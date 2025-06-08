using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class UIManagement : MonoBehaviour
{
    //panel(which is wrote like panel) means menu Panel
    public GameObject panel, instructionPanel;
    private bool isPanelOpen = false, isInstructionPanelOpen = false;
    private int score;
    public Text scoreText, objectsText;
    public GameObject levelCompletedText;
    private int ObjectsQuantity;
    public Dropdown difficultyDropdown;

    public LevelDifficultyManager levelDifficultyManager;

    public PublicEnvironemnt publicEnvironemnt;
    void Start()
    {
        score = 0;
        difficultyDropdown.value = PlayerPrefs.GetInt("Difficulty");
        instructionPanel.SetActive(false);
        panel.SetActive(false);
        scoreText.text = "Score" + score.ToString();
        levelCompletedText.SetActive(false);
        ObjectsQuantity = PlayerPrefs.GetInt("ObjectsQuantity");
        setTextOfObjects();
    }


    public void setTextOfObjects()
    {
        objectsText.text = "OBJECTS IN LEVEL: " + ObjectsQuantity;
    }
    public void incScore()
    {
        score++;
        if (isPanelOpen)
        {
            scoreText.text = "SCORE " + score.ToString();
        }

    }


    public void SetDifficulty()
    {
        int diff = difficultyDropdown.value;
        PlayerPrefs.SetInt("Difficulty", diff);
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            levelDifficultyManager.FirstLevelSetDifficulty(diff);
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            levelDifficultyManager.SecondLevelSetDifficulty(diff);
        }
    }

    public void deQuantity()
    {
        ObjectsQuantity--;
        if (ObjectsQuantity < 1) levelCompleted();
    }
    public void incScore(int increment)
    {
        score += increment;
        if (isPanelOpen)
        {
            scoreText.text = "SCORE " + score.ToString();
        }

    }
    public void decScore()
    {
        score--;
        if (isPanelOpen)
        {
            scoreText.text = "SCORE " + score.ToString();
        }
    }
    public void setScore()
    {
        score += PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("Score", score);
    }
    public void PanelOpenClose()
    {
        if (isPanelOpen == true)
        {
            panel.SetActive(false);
            isPanelOpen = false;
            publicEnvironemnt.isPauesd = false;
        }
        else
        {
            panel.SetActive(true);
            isPanelOpen = true;
            scoreText.text = "SCORE " + score.ToString();
            publicEnvironemnt.isPauesd = true;

        }
    }

    public void GoHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void levelCompleted()
    {
        levelCompletedText.SetActive(true);
        scoreText.text = "SCORE " + score.ToString();
        setScore();
        panel.SetActive(true);
    }

    public void InstructionPanelOpenClose()
    {
        if (isInstructionPanelOpen == true)
        {
            instructionPanel.SetActive(false);
            isInstructionPanelOpen = false;
        }
        else
        {
            instructionPanel.SetActive(true);
            isInstructionPanelOpen = true;
        }
    }
    
}
