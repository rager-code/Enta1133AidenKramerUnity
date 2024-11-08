using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Dictionary<Direction, int> _rotationByDirection = new()
    { 
    
        // ask about where the enum is in code
        { Direction.North, 0 }, // also 360
        { Direction.East, 90 },
        { Direction.South, 180 },
        { Direction.West, 270 }

    };
    private CharacterController controller;
    private float playerSpeed = 2.0f;
    private bool groundedPlayer;
    private Vector3 playerVelocity;

    private bool isWalking = false;
    private float walkSpeed = 20f;
    private float walkTime = 0.5f;
    private float walkTimer = 0f;
    private Vector3 previousPosition;
    private float walkingdistance = 1f;

    public float speed = 1f;
    private float MoveForward;

    private Direction _facingDirection;
    private bool _isRotating = false;

    [SerializeField] private float RotationTime = 0.5f;
    private float _rotationTimer = 0.0f;
    private Quaternion _previousRotation;
    public void Setup()
    {
        // Simple array of all directions
        Direction[] directions = new Direction[] { Direction.North, Direction.East, Direction.South, Direction.West };
        //roll a random direction
        _facingDirection = directions[UnityEngine.Random.Range(0, directions.Length)];
        // Update the transform
        SetFacingDirection();
    }

    private void SetFacingDirection()
    {
        // Note: transform.rotation is type "Quaternion", we hate working with these, and i mean straight up despise
        // Get the transorm's rotation, use eulerAnglers for easier math (Vector3)
        Vector3 facing = transform.rotation.eulerAngles;
        // Set the y value
        facing.y = _rotationByDirection[_facingDirection];
        // Save the rotation back, converting it to a Quaternion first
        transform.rotation = Quaternion.Euler(facing);
    }

    // Update is called once per frame

    public void TurnLeft()
    {
        switch (_facingDirection)
        {
            case Direction.North:
                _facingDirection = Direction.West;
                break;
            case Direction.South:
                _facingDirection = Direction.East;
                break;
            case Direction.East:
                _facingDirection = Direction.North;
                break;
            case Direction.West:
                _facingDirection = Direction.South;
                break;

        }
        StartRotating();

    }
    public void TurnRight()
    {
        switch (_facingDirection)
        {
            case Direction.North:
                _facingDirection = Direction.East;
                break;
            case Direction.South:
                _facingDirection = Direction.West;
                break;
            case Direction.East:
                _facingDirection = Direction.South;
                break;
            case Direction.West:
                _facingDirection = Direction.North;
                break;

        }
        StartRotating();

    }
    private void StartRotating()
    {
        _previousRotation = transform.rotation;
        _isRotating = true;

    }

    public void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }
    public void Update()
    {
        if (_isRotating)
        {

            Quaternion currentRotation = Quaternion.Slerp(
            _previousRotation,
            Quaternion.Euler(new Vector3(0, _rotationByDirection[_facingDirection])),
            _rotationTimer / RotationTime);

            transform.rotation = currentRotation;

            _rotationTimer += Time.deltaTime;

            if (_rotationTimer > RotationTime)
            {
                _isRotating = false;
                _rotationTimer = 0.0f;
                SetFacingDirection();

            }

        }
        else if (isWalking)
        {
            Vector3 endPosition = walkingdistance * transform.forward + previousPosition;
            Vector3 currentPosition = Vector3.Lerp(previousPosition, endPosition,
                walkTimer / walkTime);
            transform.localPosition = currentPosition;
            walkTimer += Time.deltaTime;
            if (walkTimer > walkTime)
            {
                isWalking = false;
                walkTimer = 0f;
                transform.localPosition = endPosition;

            }


        }
        else
        {

            bool rotateLeft = Input.GetKeyDown(KeyCode.A);
            bool rotateRight = Input.GetKeyDown(KeyCode.D);

            if (Input.GetKeyDown(KeyCode.W))
            {
                StartWalking();


            }  
            if (rotateLeft && !rotateRight)
            {

                   TurnLeft();

            }
            else if (!rotateLeft && rotateRight)
            {
                   TurnRight();
            }
                
                /*
                groundedPlayer = controller.isGrounded;
                if (groundedPlayer && playerVelocity.y < 0)
                {
                    playerVelocity.y = 0f;
                }
                
                
                Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                controller.Move(move * Time.deltaTime * playerSpeed);

                if (move != Vector3.zero)
                {
                    gameObject.transform.forward = move;
                }

                bool moveForwards = Input.GetKeyDown(KeyCode.W);
                bool movebackwards = Input.GetKeyDown(KeyCode.S);
                */

        }
            
    }
    private void StartWalking()
    {
        previousPosition = transform.localPosition;
        isWalking = true;


    }
}
    
   
