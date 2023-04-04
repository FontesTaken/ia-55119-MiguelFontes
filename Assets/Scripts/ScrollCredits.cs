using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollCredits : MonoBehaviour
{

    public GameObject creditsRun;


    void Start()
    {
        StartCoroutine(RollCreds());
    }

    IEnumerator RollCreds()
    {
        creditsRun.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
}