using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenuFunction : MonoBehaviour
{

    public AudioSource buttonPress;
    public int bestScore;
    public GameObject bestScoreDisplay;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("LevelScore");
        bestScoreDisplay.GetComponent<TextMeshProUGUI>().text = "Best: " + bestScore;
    }

    public void PlayGame()
    {
        buttonPress.Play();
        RedirectToLevel.redirectToLevel = 3;
        GlobalLives.currentLives = 3;
        Cursor.visible = false;
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayCreds()
    {
        buttonPress.Play();
        SceneManager.LoadScene(4);
    }
}
