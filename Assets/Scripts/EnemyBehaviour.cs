using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    public int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f;

    public GameObject youFell;
    public GameObject levelAudio;
    public GameObject fadeOut;
    public GameObject player;

    private void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            Random rnd = new Random();
            currentWaypointIndex = rnd.Next(0, waypoints.Length);
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(YouFellOff());
        }
    }

    IEnumerator YouFellOff()
    {
        player.SetActive(false);
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