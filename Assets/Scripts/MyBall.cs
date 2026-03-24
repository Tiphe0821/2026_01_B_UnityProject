using UnityEngine;

public class MyBall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " 와 충돌");                   // Gameobject.name 을 사용하면 이름을 출력할 수도 있다

        if (collision.gameObject.tag == "Ground")                           // 충돌한 게임 오브젝트의 태그를 확인할 수 있다
        {
            Debug.Log("땅과 충돌");                                          // 로그 출력
        }
    }

    private void OnTriggerEnter(Collider other)                             // isTrigger 가 켜진 콜리더 안에 들어왔을 때 
    {
        Debug.Log("트리거 안에 들어옴");
    }

    private void OnTriggerExit(Collider other)                              // isTrigger 가 켜진 콜리더 밖으로 나갔을 때
    {
        Debug.Log("트리거 밖으로 나감");
    }
}
