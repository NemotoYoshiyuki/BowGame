using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour {
    bool play;
    bool audioPlay;
    Image image;
    public Sprite playImage;
    public Sprite stopImage;
    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
    }

    //ゲームのポーズと再開の切り替え
    public void PlayButton()
    {
        if (play)
        {
            image.sprite = playImage;
            Time.timeScale = 1f;
            play = false;
        }
        else
        {
            image.sprite = stopImage;
            Time.timeScale = 0f;
            play = true;
        }
    }

    //ゲームの音量の有無の切り替え
    public void AudioButton()
    {
        if (audioPlay)
        {
            image.sprite = playImage;
            AudioListener.volume = 1;
            audioPlay = false;
        }
        else
        {
            AudioListener.volume = 0;
            image.sprite = stopImage;
            audioPlay = true;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
