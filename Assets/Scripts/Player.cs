using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class Player: MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    private int spriteIndex = 0;
    private Vector3 direction;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float strength = 4f;
    [SerializeField] private float rotationRate = 100f;
    [SerializeField] private GameController controller;

    public float Gravity {  get { return gravity; } set {  gravity = value; } }
    public float Strength { get { return strength; } set {  strength = value; } }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }
    // Update is called once per frame
    void Update()
    {
        gravity += -0.1f * Time.deltaTime;
        strength += Time.deltaTime * 0.1f * 4/9.8f;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * strength;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis
            (rotationRate * direction.y * Time.deltaTime, Vector3.forward);
    }
    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //FindObjectOfType<GameController>().GameOver();
            controller.GameOver();
        } else if (collision.gameObject.CompareTag("Scoring"))
        {
            //FindObjectOfType<GameController>().IncreaseScore();
            controller.IncreaseScore();
        }
    }
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;
        direction = Vector3.zero;
    }
}
