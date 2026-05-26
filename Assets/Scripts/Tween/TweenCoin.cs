using DG.Tweening;
using NUnit.Framework.Constraints;
using UnityEngine;

public class TweenCoin : MonoBehaviour
{
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // 코인이 생성되었을 때 살짝 랜덤한 위치로 튀도록 목표 위치를 만든다

        Vector3 randomPosition = transform.position + new Vector3(
            Random.Range(-1f, 1f),
            0f,
            Random.Range(-1f, 1f)
        );
        // 코인이 바닥에 떨어지는 것처럼 점프 이동한다

        // DOJump (목표 위치, 점프 높이, 점프 획수, 시간)
        transform.DOJump(randomPosition, 1.2f, 1, 0.4f).SetLink(gameObject);
        // SetLink는 오브젝트가 사라질 때 Tween 도 사라지도록 해준다

        // 코인이 떨어질 때 한바퀴 돌아가게 한다
        transform.DORotate(new Vector3(0f, 360f, 0f), 0.4f, RotateMode.FastBeyond360).SetLink(gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
