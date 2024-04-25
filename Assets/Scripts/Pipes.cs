using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    private static float speed = 5f;
    private float leftEdge = -10.75f;
    
    private static float acceleration = 0.1f;
    
    [SerializeField] private GameController gameController; 
    
    // Start is called before the first frame update
    void Start()
    {
        //initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //gameController.Speed += Time.deltaTime * gameController.Acceleration;
        //speed = gameController.Speed;
        speed += acceleration * Time.deltaTime;
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
    public static float Speed {  get { return speed; } set { speed = value; } }
}
