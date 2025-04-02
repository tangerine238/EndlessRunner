using UnityEngine;

public class ObstacleScript : MonoBehaviour
{

    public ObstacleGeneratorScript obstacleGenerator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * obstacleGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            obstacleGenerator.GenerateNextObstacleWithGap();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}
