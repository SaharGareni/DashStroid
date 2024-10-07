using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    float speed = 8f;
    float screenHalfWidthInWorldUnits;
    float halfPlayerWidth => transform.localScale.x / 2;
    public event System.Action OnPlayerDeath;
    void Start()
    {
        screenHalfWidthInWorldUnits = Camera.main.orthographicSize * Camera.main.aspect;
    }

    
    void Update()
    {
        float inputX  = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(velocity * Time.deltaTime * Vector2.right);
        if (transform.position.x > screenHalfWidthInWorldUnits + halfPlayerWidth)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
        if (transform.position.x < -screenHalfWidthInWorldUnits - halfPlayerWidth)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Obstacle")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
           Destroy(gameObject);
        }
    }
}
