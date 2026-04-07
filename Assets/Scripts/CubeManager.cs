using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public CubeGenetator[] genetatedCubed = new CubeGenetator[5];

    public float timer = 0;
    public float interval = 3.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            RandomizeCubeActivation();
            timer = 0.0f;
        }
    }

    public void RandomizeCubeActivation()
    {
        for (int i = 0; i < genetatedCubed.Length; i++)
        {
            int ranfomNum = Random.Range(0, 2);

            if (ranfomNum == 0)
            {
                genetatedCubed[i].GenCube();                
            }
        }
    }
}
