using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityChan;

public class GemBehaviour : MonoBehaviour
{
    public GameObject scoreBox;
    public AudioSource collectSound;
    public int rotateSpeed = 2;
    public int gemScore;
    public bool isPowerUp;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.timeScale, 0, Space.World);
    }

    void OnTriggerEnter()
    {
        if (isPowerUp) UnityChanControlScriptWithRgidBody.numberOfJumps = 2;
        GlobalScore.currentScore += gemScore;
        collectSound.Play();
        Destroy(gameObject);
    }
}
