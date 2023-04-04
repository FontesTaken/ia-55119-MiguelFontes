using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishLevel : MonoBehaviour
{

    public GameObject levelMusic;
    public AudioSource levelComplete;
    public GameObject levelTimer;
    public GameObject timeLeft;
    public GameObject livesLeft;
    public GameObject theScore;
    public GameObject totalScore;
    public int timeCalc;
    public int livesCalc;
    public int scoreCalc;
    public int totalScored;
    public GameObject levelBLocker;
    public GameObject FadeOut;

    void OnTriggerEnter()
    {
        GetComponent<BoxCollider>().enabled = false;
        levelBLocker.GetComponentInChildren<BoxCollider>().isTrigger = false;
        levelBLocker.transform.parent = null;
        timeCalc = GlobalTimer.extendScore * 100;
        livesCalc = GlobalLives.currentLives * 1000;
        timeLeft.GetComponent<TextMeshProUGUI>().text = "Time Left: " + GlobalTimer.extendScore + " x 100";
        livesLeft.GetComponent<TextMeshProUGUI>().text = "Number of lives: " + GlobalLives.currentLives + " x 1000";
        theScore.GetComponent<TextMeshProUGUI>().text = "Score: " + GlobalScore.currentScore;
        totalScored = GlobalScore.currentScore + timeCalc + livesCalc;
        totalScore.GetComponent<TextMeshProUGUI>().text = "Total Score: " + totalScored;
        int bestScore = PlayerPrefs.GetInt("LevelScore");
        if (bestScore != 0 && totalScored > bestScore) PlayerPrefs.SetInt("LevelScore", totalScored);
        levelMusic.SetActive(false);
        levelTimer.SetActive(false);
        levelComplete.Play();
        StartCoroutine(CalculateScore());
    }

    IEnumerator CalculateScore()
    {
        timeLeft.SetActive(true);
        yield return new WaitForSeconds(1);
        livesLeft.SetActive(true);
        yield return new WaitForSeconds(1);
        theScore.SetActive(true);
        yield return new WaitForSeconds(1);
        totalScore.SetActive(true);
        yield return new WaitForSeconds(2);
        FadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        Cursor.visible = true;
        SceneManager.LoadScene(1);
    }
}