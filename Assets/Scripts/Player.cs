using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float PaddingLeft;
    [SerializeField] float PaddingRight;
    [SerializeField] float PaddingTop;
    [SerializeField] float PaddingBottom;
    Shooter shooter;

    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }
    void Start()
    {
        InitBounds();
    }
    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    void Move()
    {
        Vector2 move = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPose = new Vector2();
        newPose.x = Mathf.Clamp(transform.position.x + move.x,minBounds.x+PaddingLeft,maxBounds.x-PaddingRight);
        newPose.y = Mathf.Clamp(transform.position.y + move.y,minBounds.y+PaddingBottom,maxBounds.y-PaddingTop);
        transform.position = newPose;
    }

    void OnMove(InputValue value)
    {
        rawInput =value.Get<Vector2>();
        Debug.Log(rawInput);
    }
    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }

}
