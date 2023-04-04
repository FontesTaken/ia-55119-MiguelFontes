using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeLerp : MonoBehaviour
{
    public GameObject initialPos;
    public GameObject finalPos;
    public float speed = 0.5f;
    public float maxDistance = 0;

    private bool isInRange;
    private bool isMoving = false;

    void Update()
    {
        // Check if the player is in range and looking at the object and the E key is pressed
        if (isInRange && Input.GetKeyDown(KeyCode.E) && !isMoving)
        {
            // Perform the interaction logic
            Debug.Log("Interacting with object");

            isMoving = true;

            // Move the bridge towards the final position
            StartCoroutine(MoveBridge(finalPos.transform.position, finalPos.transform.rotation, finalPos.transform.localScale));
        }
    }

    IEnumerator MoveBridge(Vector3 targetPosition, Quaternion targetRotation, Vector3 targetScale)
    {
        Transform startPos = initialPos.transform;
        float distance = Vector3.Distance(startPos.position, targetPosition);
        float startTime = Time.time;
        float journeyTime = distance / speed;

        while (Vector3.Distance(startPos.position, targetPosition) > maxDistance)
        {
            // Move the bridge using Lerp
            float fracJourney = (Time.time - startTime) / journeyTime;
            startPos.position = Vector3.Lerp(startPos.position, targetPosition, fracJourney);
            startPos.rotation = Quaternion.Slerp(startPos.rotation, targetRotation, fracJourney);
            startPos.localScale = Vector3.Lerp(startPos.localScale, targetScale, fracJourney);

            yield return null;
        }

        isMoving = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Range"))
        {
            Debug.Log("isInRange = true");
            isInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Range"))
        {
            Debug.Log("isInRange = false");
            isInRange = false;
        }
    }
}
