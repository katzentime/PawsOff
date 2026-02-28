using UnityEngine;

// ReSharper disable Unity.PerformanceCriticalCodeInvocation

public class PawScript : MonoBehaviour
{
    [SerializeField] GameObject dishPrefab;
    [SerializeField] GameObject tableObject;
    [SerializeField] float speed;
    [SerializeField] int health;
    GameObject _dishObject;
    Camera _camera;

    void Awake() => _camera = Camera.main;

    void Update()
    {
        if (IsHiding)
        {
            transform.position += new Vector3(-0.1f, 0, 0);
            if (IsOverlappingWithTable)
                return;

            _dishObject = SpawnDishOnTable();
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!IsOverlappingWithMouse)
                return;

            health--;
            if (health > 0)
                return;
            Destroy(this);
            return;
        }

        if (IsOverlappingWithDish)
        {
            _dishObject.transform.SetParent(transform);
            _dishObject.SetActive(false);
            _dishObject = null;

            return;
        }

        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _dishObject.transform.position, step);
    }

    bool IsOverlappingWithMouse =>
        GetComponent<Collider2D>().OverlapPoint(_camera.ScreenToWorldPoint(Input.mousePosition));

    bool IsOverlappingWithDish => _dishObject.GetComponent<Collider2D>().IsTouching(GetComponent<Collider2D>());
    bool IsOverlappingWithTable => GetComponent<Collider2D>().IsTouching(tableObject.GetComponent<Collider2D>());
    bool IsHiding => _dishObject == null;

    GameObject SpawnDishOnTable()
    {
        var tableRenderer = tableObject.GetComponent<SpriteRenderer>();
        var dishRenderer = dishPrefab.GetComponent<SpriteRenderer>();

        var tableBounds = tableRenderer.bounds;
        var dishExtents = dishRenderer.bounds.extents * 0.8f;

        var spawnPosition = new Vector3
        (
            Random.Range(tableBounds.min.x + dishExtents.x, tableBounds.max.x - dishExtents.x),
            Random.Range(tableBounds.min.y + dishExtents.y, tableBounds.max.y - dishExtents.y),
            tableBounds.center.z
        );

        return Instantiate(dishPrefab, spawnPosition, Quaternion.identity);
    }
}