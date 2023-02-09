using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnakeBehaviour : MonoBehaviour
{
    public Vector2 _direction = Vector2.right;
    public Vector2 _lastdirection = Vector2.right;
    public GameObject sprite;

    private List<Transform> _segments = new List<Transform>();

    public Transform segmentPrefab;
    public int initialSize = 4;
  

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
            sprite.transform.eulerAngles = new Vector3(90, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
            sprite.transform.eulerAngles = new Vector3(180, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }
    }

    private void FixedUpdate()
    {
        if (_direction == -_lastdirection) _direction = _lastdirection;

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        
        }

        this.transform.position = new Vector3(
            this.transform.position.x + _direction.x,
            this.transform.position.y + _direction.y,
            0.0f
             );
        _lastdirection = _direction;
    }

    private void Grow() 
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void ResetState() 
    {
        for (int i = 1; i < _segments.Count; i++) 
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 0; i < initialSize; i++) 
        {
            _segments.Add(Instantiate(this.segmentPrefab));

        }

        this.transform.position = Vector3.zero;
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food") Grow();
        else if (other.tag == "Obstacle") ResetState();
        
    }


}
