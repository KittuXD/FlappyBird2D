using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int _spriteIndex;

    private Vector3 _direction;
    private float _gravity = -11.8f;
    private float _strength = 5f;

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite),0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        _direction = Vector3.zero;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            _direction = Vector3.up * _strength;        
        }

        if (Input.touchCount > 0 )
        { 
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began)
            {
                _direction = Vector3.up * _strength;
            }
        }
        _direction.y += _gravity * Time.deltaTime;
        transform.position += _direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        _spriteIndex++;

        if (_spriteIndex >= sprites.Length)
        { 
            _spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[_spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        } 
        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }  
    }
}
