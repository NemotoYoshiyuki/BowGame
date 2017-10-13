using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public int startTime;
    static float countDown;
    public float time { get { return countDown; } set { countDown = value; } }
    static float gameOverTime;
    public float GameOverTime { get { return gameOverTime; } set { gameOverTime = value; } }

    // Use this for initialization
    void Start()
    {
        timer = GetComponent<Text>();
        countDown = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;

        timer.text = "Time:" + (int)countDown;
        if (countDown < 0)
        {
            countDown = 0;
        }

        gameOverTime += Time.deltaTime;
    }

    public void GetBouns(float bounsTime)
    {
        countDown += bounsTime;
    }
}
