using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public float speed;
    Animator animator;
    AudioSource sfx;
    public Score score;
    public Timer time;
    public int dropScore;
    public int bounsTime;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        sfx = GetComponent<AudioSource>();
        hp = Random.Range(hp, hp + 2);
        //10秒後に削除
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0, 0));
    }

    //void GetDamage(int damage)
    //{
    //    hp -= damage;
    //    animator.SetTrigger("Damage");
    //}

    void Deth()
    {
        sfx.Play();
        score.SetScore(dropScore);
        time.GetBouns(bounsTime);
        Destroy(gameObject, 0.3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hp -= 1;

        if (hp <= 0)
        {
            Deth();
        }

        if (animator == null)
        {
            return;
        }
        animator.SetTrigger("Damage");
        //ヒットストップ
        StartCoroutine(HitStop(0.5f));

    }

    public IEnumerator HitStop(float time)
    {
        speed = speed / 2;
        yield return new WaitForSeconds(time);
        speed = speed * 2;
    }
}
