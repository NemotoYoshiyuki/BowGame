using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text timeText;
    public Text scoreText;
    public Score score;
    public Timer time;

    // Use this for initialization
    void Start()
    {
        this._GameOver();
    }

    public void _GameOver()
    {
        //UIを更新する
        gameObject.SetActive(true);
        timeText.text = "Time  " + (int)time.GameOverTime;
        scoreText.text = "Score  " + score.GetScore().ToString();
        score.evaluate();
        //敵をすべて削除する
        Time.timeScale = 0f;
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var item in enemys)
        {
            Destroy(item);
        }
    }
}
