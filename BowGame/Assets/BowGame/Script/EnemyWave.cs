using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    
    public GameObject enemy;
    public Transform spawnPoint;
    public float spawnTime;
    public float min;
    public float max;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        //ポジションに数字を足して不規則に出現しているように見せる
        GameObject _enemy = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        _enemy.transform.position += new Vector3(0, Random.Range(min, max), 0);       
    }
}
