using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private Outline _outline = null;
    private Vector2 _direction = Vector2.up;
    private Vector2 _startPos;
    private float _speed = .1f;

    public static Vector2 _lastCheckPointPos = new Vector2(-13,-4); // = new Vector2(x, x); Player Start Position

    private void Awake()
    {
        transform.position = _lastCheckPointPos;
    }

    private void Start()
    {
        //_startPos = transform.position;
        _outline.enabled = false;
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
        }else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
        }else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _direction = Vector2.left;
        }else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            _direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + _direction.x, Mathf.Round(this.transform.position.y) + _direction.y, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wall")
        {
            transform.position = _lastCheckPointPos;
        }
        if(other.tag == "Other")
        {
            _outline.enabled = true;
        }
        else{
            _outline.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Other")
        {
            _outline.enabled = false;
        }
    }
}
