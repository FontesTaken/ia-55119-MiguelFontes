using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalLives: MonoBehaviour
{

    public GameObject liveBox;
    public static int currentLives = 3;

    void Update()
    {
        liveBox.GetComponent<Text>().text = "Lives: " + currentLives;
    }

}

