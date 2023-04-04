using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDeath : MonoBehaviour
{

    public GameObject youFell;
    public GameObject levelAudio;
    public GameObject fadeOut;

    void OnTriggerEnter()
    {
        StartCoroutine(YouFellOff());
    }

    IEnumerator YouFellOff()
    {
        youFell.SetActive(true);
        levelAudio.SetActive(false);
        yield return new WaitForSeconds(2);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        GlobalLives.currentLives--;
        GlobalScore.currentScore = 0;
        if (GlobalLives.currentLives == 0)
        {
            Cursor.visible = true;
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }

}