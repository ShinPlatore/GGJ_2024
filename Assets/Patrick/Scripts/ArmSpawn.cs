using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class ArmSpawn : MonoBehaviour
{
    private GameObject _armPrefab;
    [SerializeField] private GameObject _armForwardPrefab; 
    [SerializeField] private GameObject _armUpPrefab; 
    [SerializeField] private GameObject _armDownPrefab;
    [SerializeField] private GameObject _armVerticalPrefab;

    private EHandDirection _armDirection = EHandDirection.Forward;

    [SerializeField] private float distanceBetweenSegments = 1.5f; // Distance between each arm segment

    public List<GameObject> armSegments = new List<GameObject>();
    [SerializeField] private Transform handTransform;
    [SerializeField] private float distanceToSpawnNewArm;
    private int armLifetime;
    [SerializeField] private float _lifeTimer;

    public EHandDirection ArmDirection
    {
        get { return _armDirection; }
        set { _armDirection = value; }

    }


    void Start()
    {
        handTransform = transform; // Assuming the hand sprite is attached to the same GameObject

        SpawnArmSegment();
    }

    void Update()
    {
        // Check if the last arm segment is too far from the hand and spawn a new arm segment
        if (armSegments.Count > 0)
        {
            float distanceToLastArm = Vector2.Distance(handTransform.position, armSegments[armSegments.Count - 1].transform.position);
            if (distanceToLastArm > distanceToSpawnNewArm)
            {
                SpawnArmSegment();
            }
        }

        _lifeTimer += Time.deltaTime;
        if (_lifeTimer > 0.5f)
        {
            _lifeTimer = 0f;
            DestroyLastArmSegment();
        }

    }

    void DestroyLastArmSegment()
    {
            GameObject lastArmSegment = armSegments[0];
            armSegments.RemoveAt(0);
            Destroy(lastArmSegment);
    }


    void SpawnArmSegment()
    {
        // Calculate the position of the new arm segment
        Vector3 position = handTransform.position - Vector3.right * distanceBetweenSegments;

        switch (_armDirection)
        {
            case EHandDirection.Forward:
                _armPrefab = _armForwardPrefab;
                break;

            case EHandDirection.Up:
                _armPrefab = _armUpPrefab;
                break;

            case EHandDirection.Down:
                _armPrefab = _armDownPrefab;
                break;

            default:
                _armPrefab = _armForwardPrefab;
                break;

        }

        // Instantiate a new arm segment
        GameObject newArmSegment = Instantiate(_armPrefab, position, Quaternion.identity);
        armSegments.Add(newArmSegment);

    }
}
