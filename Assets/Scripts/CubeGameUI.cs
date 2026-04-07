using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CubeGameUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;               // ui 선언
    public float timer;                             // timer 선언
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;                                            // 타이머 시간이 늘어난다
        timerText.text = "생존 시간 : " + timer.ToString("0.00");            // 문자열 형태로 변환하여 보여준다
    }
}
