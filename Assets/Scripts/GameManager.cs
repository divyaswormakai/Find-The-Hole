using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Maze mazePrefab;
    private Maze mazeInstance;

    // Start is called before the first frame update
    void Start()
    {
        BeginGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            RestartGame();
        }
    }

    void BeginGame()
    {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        StartCoroutine(mazeInstance.Generate());
    }

    void RestartGame()
    {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        BeginGame();
    }

}
