using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 1f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Rigidbody2D _characterRigidbody = null;
    private Vector2 _movement;
    [SerializeField] private ArmSpawn _armSpawn = null;

    [SerializeField] private GameObject segmentPrefab;
    private List<GameObject> segments = new List<GameObject>();
    private Transform handTransform;
    [SerializeField] private Transform[] _transforms = null;

    [SerializeField] private GameObject _handObject;
    [SerializeField] private SpriteRenderer _armSprite;
    [SerializeField] private Sprite _straightSprite;
    [SerializeField] private Sprite _downSprite;
    [SerializeField] private Sprite _upSprite;

    // Start is called before the first frame update
    void Start()
    {
        handTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {

        // Input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // Movement
        _movement = new Vector2(moveHorizontal, moveVertical);

        if (moveVertical > 0)
        {
            MoveUpAction();

        }
        else if (moveVertical < 0) 
        {
            MoveDownAction();
        }

        else
        {
            moveForward();
        }

    }

    private void FixedUpdate()
    {
        _characterRigidbody.velocity = new Vector2(-0.5f, 0f);

        _characterRigidbody.velocity = _movement * _speed;

        
    }

    void AddSegment()
    {
        GameObject newSegment = Instantiate(segmentPrefab, _transforms[0].position, Quaternion.identity);
        segments.Add(newSegment);

        // Update positions of all segments except the first one
        /*if (segments.Count > 1)
        {
            for (int i = segments.Count - 1; i > 0; i--)
            {
                // Set the position of the current segment to the position of the segment before it
                segments[i].transform.position = segments[i - 1].transform.position;
            }
        }*/
    }

    void MoveSegments()
    {
        Vector3 prevPosition = handTransform.position;
        foreach (GameObject segment in segments)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.transform.position = prevPosition;
            prevPosition = tempPosition;
        }
    }

    private void MoveDownAction()
    {
        _handObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        _armSpawn.ArmDirection = EHandDirection.Down;
    }

    private void MoveUpAction()
    {
        _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        _armSpawn.ArmDirection = EHandDirection.Up;
    }

    private void moveForward()
    {
        _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        _armSpawn.ArmDirection = EHandDirection.Forward;
    }

}
