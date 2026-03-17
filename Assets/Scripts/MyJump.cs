using UnityEngine;
using UnityEngine.UI;

public class MyJump : MonoBehaviour
{
    public Rigidbody rigidbody;                                                 // 강체 (형태와 크기가 고정된 고체) 물리 현상이 동작하게 해주는 컴포넌트
    public float power = 200.0f;                                                   // 변수 힘을 선언 함
    public float timer = 0;
    public Text TextUI;

    void Start()
    {
    }

    void Update()
    {
        timer = timer + Time.deltaTime;                                         // 타이머를 상승시킨다
        TextUI.text = timer.ToString();                                         // 타이머 숫자가 상승함에 따라 UI의 숫자를 상승시킨다

        if (Input.GetKeyDown(KeyCode.Space))                                    // 스페이스 키를 눌렀을 떄
        {
            power = power + Random.Range(-100, 200);                            // Power를 랜덤으로 변경시킨다 
            rigidbody.AddForce(transform.up * power);                           // 변수(Power)의 위쪽으로 힘을 준다
        }

        if (this.gameObject.transform.position.y > 5 || this.gameObject.transform.position.y < -3)
        {
            // 이 오브젝트의 y 좌표 위치가 5보다 크거나 -3보다 작으면
            Destroy(this.gameObject); // 이 오브젝트를 제거한다
        }
    }
}
