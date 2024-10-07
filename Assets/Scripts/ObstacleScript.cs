using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float speed;
    public Vector2 minMaxSpeed;
    float halfObstacleHeight;
    void Start()
    {
        speed = Mathf.Lerp(minMaxSpeed.x, minMaxSpeed.y, Difficulty.GetDifficultyPercent());
        halfObstacleHeight = transform.localScale.y/2;
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y < -Camera.main.orthographicSize -halfObstacleHeight)
        {
            Destroy(gameObject);
        }
    }
}
