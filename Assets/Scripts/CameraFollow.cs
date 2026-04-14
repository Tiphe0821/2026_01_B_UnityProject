using System.ComponentModel;
using UnityEngine;
using UnityEngine.Animations;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 offest = new Vector3(0, -5, 0);
    public float smoothSpeed = 0.125f;

    private void LateUpdate()
    {
        // 레이트 업데이트를 카메라가 플레이어의 이동을 모두 처리한 이후에 따라가게 하기 위해서

        Vector3 desirePosition = target.position + offest;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, -desirePosition, smoothSpeed);
        transform.position = smoothPosition;

        transform.LookAt(transform.position);
    }
}
