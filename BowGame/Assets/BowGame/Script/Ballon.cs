using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    Animator anim;
    AudioSource sfx;
    public float speed = 1f;

    public Score score;
    public Timer time;
    public int dropScore;
    public int bounsTime;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Arrow")
        {
            anim.SetTrigger("Break");
            sfx.Play();
            score.SetScore(dropScore);
            time.GetBouns(bounsTime);
            Destroy(gameObject,0.5f);
        }
    }
}
