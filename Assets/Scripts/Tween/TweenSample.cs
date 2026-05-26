using UnityEngine;
using DG.Tweening;
using TMPro;

public class TweenSample : MonoBehaviour
{
    [Header("핀치 스케일 예시")]
    public RectTransform punchUITarget;                       // UI 타겟
    public GameObject punchTarget;                            // 오브젝트 타겟

    [Header("숫자 연출 예시")]
    public TMP_Text countText;                                  // 카운트 연출용
    public int currentValue;
    public int addValue;

    private int targetValue;

    [Header("색 변경 연출 예시")]
    public Color flashColor = Color.yellow;

    private Color originalColor;

    [Header("페이드 UI 그룹")]
    public CanvasGroup fadeTarget;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalColor = countText.color;
        fadeTarget.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayPunchUIScale();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayPunchObjectScale();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayUIShake();
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {

        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            PlayCoundUP();
        }
        if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            PlayColorFlash();
        }
        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            PlayFade();
        }
    }

    public void PlayPunchUIScale()
    {
        if (punchUITarget == null)
            return;

        // 이전 실행중이던 Tween 이 있으면 정리한다
        punchUITarget.DOKill();                         // 이전 실행중인 Tween 이 있으면 삭제
        punchUITarget.localScale = Vector3.one;         // 크기가 이상하게 남아있을 수 있으므로 기본 크기로 초기화한다
        punchUITarget.DOPunchScale(Vector3.one * 0.3f, 0.25f, 8, 1.0f); // 방향 크기, 시간, 진동, 횟수, 탄성


    }
    public void PlayPunchObjectScale()
    {
        if (punchTarget == null)
            return;

        // 이전 실행중이던 Tween 이 있으면 정리한다
        punchTarget.transform.DOKill();                         // 이전 실행중인 Tween 이 있으면 삭제
        punchTarget.transform.localScale = Vector3.one;         // 크기가 이상하게 남아있을 수 있으므로 기본 크기로 초기화한다
        punchTarget.transform.DOPunchScale(Vector3.one * 0.3f, 0.25f, 8, 1.0f); // 방향 크기, 시간, 진동, 횟수, 탄성


    }

    public void PlayUIShake()
    {
        if(punchUITarget == null) 
            return;

        punchUITarget.DOKill();
        punchUITarget.DOShakeAnchorPos(0.3f, 20f, 20, 90f);     // 시간, 강도, 진동 횟수, 랜덤성
    }
    public void PlayObjectShake()
    {
        if(punchTarget == null) 
            return;

        punchTarget.transform.DOKill();
        //punchTarget.DOShakeAnchorPos(0.3f, 20f, 20, 90f);     // 시간, 강도, 진동 횟수, 랜덤성
    }

    public void PlayCoundUP()
    {
        if (countText == null) return;

        targetValue += addValue;      // 목표 숫자

        DOTween.Kill("CountTween", true);

        DOTween.To(
            () => currentValue,                                   // 현재 값
            value =>                                            // 중간 값이 바뀔때 실행되는 부분
            {
                currentValue = value;
                countText.text = currentValue.ToString();
            },
            targetValue,                                        // 목표 값
            0.5f                                                // 걸리는 시간
        )
        .SetEase(Ease.OutQuad)
        .SetId("CountTween");
    }

    public void PlayColorFlash()
    {
        if (countText == null) return;

        countText.DOKill();

        countText.color = originalColor; // 이전 Tween 중간 색상이 남아있을 수 있으니 원래 색으로 초기화

        countText.DOColor(flashColor, 0.1f)
            .OnComplete(() =>
            {
                countText.DOColor(originalColor, 0.2f);     // 완료되면 원래 색으로 되돌린다
            });
    }

    public void PlayFade()
    {
        if(fadeTarget == null) return;

        fadeTarget.DOKill();        // 이전 연출 정리
        fadeTarget.alpha = 0f;          // 처음에는 안보이게 설정

        Sequence seq = DOTween.Sequence();      // 시쿼스 생성

        seq.Append(fadeTarget.DOFade(1f, 0.2f)); // 0.2초동안 나타난다
        seq.AppendInterval(0.5f);               // 0.5초동안 유지한다.
        seq.Append(fadeTarget.DOFade(0f, 0.3f)); // 0.3초동안 사라진다

    }
}
