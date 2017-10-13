using UnityEngine;

public class GameMnager : MonoBehaviour
{
    [Header("GameOver")]
    public Timer timer;
    public GameOver gameOver;
    public GameObject gameOverObj;

    // Update is called once per frame
    void Update()
    {
        if (timer.time <= 0)
        {
            gameOverObj.SetActive(true);
        }
    }
}
