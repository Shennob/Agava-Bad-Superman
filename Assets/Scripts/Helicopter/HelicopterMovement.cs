using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Transform _body;

    private int _maxWantedLevel = 5;
    private float _maxPlayerDistance = 100f;
    private float _speed = 0.5f;
    private WantedLevel _player;
    private Transform _clossestWaypoint;

    private void Start()
    {
        _player = FindObjectOfType<WantedLevel>();
        _clossestWaypoint = _waypoints[0];
        _body.gameObject.SetActive(false);
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.gameObject.transform.position);

        if (_player.CurrentWantedLevel >= _maxWantedLevel)
        {
            _body.gameObject.SetActive(true);
            if (distance > _maxPlayerDistance)
            {
                SetClosestWaypoint();
            }
        }

        Move();
        Rotate();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _clossestWaypoint.position, _speed);
    }

    private void Rotate()
    {
        transform.LookAt(_player.gameObject.transform);
        var rotation = Mathf.Clamp(transform.eulerAngles.x, 0, 35);
        transform.eulerAngles = new Vector3(rotation, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    private void SetClosestWaypoint()
    {
        for (int i = 0; i < _waypoints.Length; i++)
        {
            float distanceToPlayer = Vector3.Distance(_waypoints[i].position, _player.gameObject.transform.position);

            if (distanceToPlayer <= _maxPlayerDistance)
            {
                _clossestWaypoint = _waypoints[i];
            }
        }
    }
}
