using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawnerScript : MonoBehaviour
{
    private Singleton _singletonManager;
    public GameObject greenPrefab;
    public GameObject bluePrefab;
    private GameObject bubblePrefab;
    public Transform bubbleHolder;

    private int bubbleCount = 0;
    public int maxCount = 20;
    public float maxTime = 5.0f;
    private float timer = 3.0f;
    private float bounds_XY = 4.2f;


    void Start() {
        _singletonManager = Singleton.Instance;
    } //-- start end

    void FixedUpdate() {
        // if(_singletonManager.gameState != Singleton.GameState.PlayState)
        //      return;
        // }

        if(timer > maxTime) {
            if(bubbleCount < maxCount) {
                int index = Random.Range(0, 2);
                if(index == 0) {
                    bubblePrefab = bluePrefab;
                } else {
                    bubblePrefab = greenPrefab;
                }

                GameObject bubble = Instantiate(bubblePrefab);
                bubble.transform.position = transform.position + new Vector3(Random.Range(bounds_XY, -bounds_XY), Random.Range(bounds_XY, -bounds_XY), 0);
                bubble.transform.parent = bubbleHolder;

                bubbleCount++;
                timer = 0;
            }
        }
        timer += Time.deltaTime;
    } //-- Update end

} //-- class end


/*
Project: 
Made by: 
*/

