using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;                        // 현재 생명력     
                
    public float invincibleTime = 1.0f;             // 피격 후 무적시간 
    public bool isinvincible = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Missile"))
        {
            currentLives--;
            Destroy(other.gameObject);
        }

        if(currentLives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameObject.SetActive(false);
        Invoke("RestartGame", 3.0f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
