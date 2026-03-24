using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;                                      // 이동 속도 변수 설정
    public float jumpForce = 5.0f;                                      // 점프 힘 값을 준다 
    public Rigidbody rb;                                                // 플레이어 강체 선언

    public bool isGrounded = true;                                      // 땅에 있는지 체크하는 변수

    public int coinCount = 0;                                           // 먹은 코인의 개수를 확인하는 변수

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 움직임 입력
        float moveHorizontal = Input.GetAxis("Horizontal");             // 수평 이동
        float moveVertical = Input.GetAxis("Vertical");                 // 수직 이동

        rb.linearVelocity = new Vector3(moveHorizontal * moveSpeed, rb.linearVelocity.y, moveVertical * moveSpeed);

        if(Input.GetButtonDown("Jump") && isGrounded)                   // && 두 값을 만족할 때 -> (스페이스 버튼을 눌렀을때와 isGrounded 가 True 일때
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);     // 위쪽으로 설정한 힘 만큼 물체에 힘을 준다 
            isGrounded = false;                                         // 점프를 하는 순간 땅에서 떨어졌기 때문에 false 로 한다
        }
    }

    private void OnCollisionEnter(Collision collision)                  // 충돌 처리 함수
    {
        if (collision.gameObject.tag == "Ground")                       // 충돌이 일어난 물체의 Tag가 Ground 인 경우
        {
            isGrounded = true;                                          // 땅과 충돌하면 True 가 된다
        }
    }

    private void OnTriggerEnter(Collider other)                         // 트리거 영역 안에 들어왔나를 검사하는 함수
    {
        if(other.CompareTag("Coin"))                                    // 코인 트리거와 충돌 하면
        {
            coinCount++;                                                // 코인 변수 1을 올린다
            Destroy(other.gameObject);                                  // 코인 오브젝트를 파괴한다
        }
    }
}
