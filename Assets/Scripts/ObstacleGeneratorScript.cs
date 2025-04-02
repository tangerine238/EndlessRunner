using UnityEngine;

public class ObstacleGeneratorScript : MonoBehaviour
{

    public GameObject Obstacle;
    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;
    public float SpeedMultiplier;

    void Awake()
    {
        currentSpeed = MinSpeed;
        generateObstacle();
    }

    public void GenerateNextObstacleWithGap(){
        float randomWait = Random.Range(0.1f,1.2f);
        Invoke("generateObstacle", randomWait);
    }

    public void generateObstacle()
    {
        GameObject ObstacleIns = Instantiate(Obstacle, transform.position, transform.rotation);
        ObstacleIns.GetComponent<ObstacleScript>().obstacleGenerator = this;

    }

    // Update is called once per frame 
    void Update()
    {
        if (currentSpeed < MaxSpeed){
            currentSpeed += SpeedMultiplier;
        }
    }
}
