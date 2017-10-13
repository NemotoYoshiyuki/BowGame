using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
   public Text scoreText;
    static int score;
    public Transform bow;
    public GameObject risingText;
    public GameObject[] Star;
    public Sprite star;
    // Use this for initialization
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + score;
    }

    //敵を倒したときスコアの更新をする
    public void SetScore(int getScore)
    {
        score += getScore;
        GameObject rt = (GameObject)Instantiate(risingText, bow.transform.position + new Vector3(-1, 1, 0), Quaternion.identity);
        rt.GetComponent<TextMesh>().text = "+" + getScore;
        scoreText.text = "Score:" + score;
    }

    public void evaluate()
    {
        int n = 100;
             
        for (int i = 0; i < Star.Length; i++)
        {
            if (score >= n*(i+1))
            {
                Star[i].GetComponent<Image>().sprite = star;
            }
        }
    }

    public int GetScore()
    {
        return score;
    }
}
