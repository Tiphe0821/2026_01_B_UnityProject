using UnityEngine;

public class ZAxisMover : MonoBehaviour
{
    public float speed = 5.0f;              // 이동 속도 
    public float timer = 5.0f;              // 타이머 설정

    void Update()
    {
        // z축 방향으로 앞으로 이동
        transform.Translate(0, 0, speed * Time.deltaTime);

        timer -= Time.deltaTime;            // 시간 카운트다운

        if( timer < 0 )
        {
            Destroy(gameObject);            // 자기 자신을 파괴한다
        }
    }
}
