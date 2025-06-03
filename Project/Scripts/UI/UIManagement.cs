using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    public GameObject panel;
    private bool isPanelOpen = false;
    private int score;
    public Text scoreText, objectsText;
    public GameObject levelCompletedText;
    private int ObjectsQuantity;
    void Start()
    {
        score = 0;
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
        }
        else
        {
            panel.SetActive(true);
            isPanelOpen = true;
            scoreText.text = "SCORE " + score.ToString();

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
}
