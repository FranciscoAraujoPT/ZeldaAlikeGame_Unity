using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMap : SceneTransition
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            playerStorage.initialValue = playerPosition;
            StartCoroutine(FadeCo());
        }
    }
}
