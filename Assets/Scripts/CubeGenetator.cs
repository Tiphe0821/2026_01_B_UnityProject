using UnityEngine;

public class CubeGenetator : MonoBehaviour
{
    public GameObject CubePreFab;
    public int totalCubes = 10;
    public float cubeSpacing = 1.0f;

   
    void Start()
    {
        GenCube();
    }

    public void GenCube()                       // 게임 안에서 무언가를 세팅할 때 사용
    {
        Vector3 myPosition = transform.position;
        GameObject firstCube = Instantiate(CubePreFab, myPosition, Quaternion.identity);

        for (int i = 1; i < totalCubes; i++)
        {
            // 네 위치에서 z축으로 일정 간격 떨어진 위치에 생성
            Vector3 position = new Vector3(myPosition.x, myPosition.y, myPosition.z + (i * cubeSpacing));
            Instantiate(CubePreFab, position, Quaternion.identity);
        }
    }
}