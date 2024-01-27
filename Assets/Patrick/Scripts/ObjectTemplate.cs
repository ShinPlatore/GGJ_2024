using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTemplate : MonoBehaviour
{
    [SerializeField] private EObjectType _objectType = EObjectType.Slapable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollideFonction(TestMovement character)
    {
        switch (_objectType)
        {
            case EObjectType.Slapable:
                PunchAction(character);
                break;

            case EObjectType.Obstacle:

                break;

            case EObjectType.InteractObject:

                break;

            case EObjectType.EndObject:

                break;

        }

    }

    private void PunchAction(TestMovement character)
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForceAtPosition(new Vector3(Random.Range(100, 200), Random.Range(-250, 250), 0f), character.transform.position);

    }

}
