using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPreFabs;
    public GameObject misslePreFabs;

    [Header("스폰 타이밍 설정")]
    public float minSpawnInterval = 0.5f;
    public float maxSpawnInterval = 2.0f;

    [Header("동전 스폰 확률 설정")]
    [Range(0f, 100f)]
    public int coinSpawnChance = 50;                // 동전 생성 확률

    public float timer = 0.0f;                      // 다음 생성 시간
    public float nextSpawnTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetNextSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;            // 시간이 0에서 점점 증가 

        if (timer > nextSpawnTime)
        {
            SpawnObject();
            timer = 0;
            SetNextSpawnTime();
        }
    }

    private void SpawnObject()
    {
        Transform spawnTransform = transform;
        int randomvalue = Random.Range(0, 100);
        if(randomvalue < coinSpawnChance)
        {
        Instantiate(coinPreFabs, spawnTransform.position, spawnTransform.rotation);
        }
        else
        { 
        Instantiate(misslePreFabs, spawnTransform.position, spawnTransform.rotation);
        }

    }
    private void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
    }
}
