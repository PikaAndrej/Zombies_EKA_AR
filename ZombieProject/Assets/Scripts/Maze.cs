using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Maze : MonoBehaviour
{
    private InputAction turn;
    public GameObject maze;
    public float turnSpeed;
    void Start()
    {
        turn = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Vector2 turnValue =  turn.ReadValue<Vector2>();
        Vector3 turnVector = new Vector3(-turnValue.x, 0, -turnValue.y) * turnSpeed * Time.deltaTime;
        maze.transform.Rotate(turnVector);
        //Debug.Log("Turn value X: " + turnValue.x + ", Y: " + turnValue.y);
    }
}
