using UnityEngine;

public class MyCharacter : MonoBehaviour
{
    public int Health = 100;                // 체력을 선언한다. (변수 정수 표현)
    public float Timer = 1.0f;              // 타이머를 설정한다. (변수 실수 표현)


    void Start()
    {
        Health += 100;                      // 첫 시작 할때 100의 체력을 추가한다
    }

    void Update()
    {
        Timer = Timer - Time.deltaTime;     // 시간을 매 프레임마다 감소시킨다. (deltaTime은 프레임간의 시간 간격을 의미한다)

        if(Timer <= 0 )                     // 만약 Timer 의 수치가  이하로 내려갈 경우
        {
            Timer = 1.0f;                   // 다시 1초로 변경 시켜 준다 
            Health = Health - 20;           // 체력이 20 줄어든다
        }
    
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Health = Health + 2;
        }

        if(Health <= 0)                     // 체력이 0 이하가 될 경우 
        {
            Destroy(this.gameObject);       // 이 오브젝트를 없엔다
        }
    }
}
