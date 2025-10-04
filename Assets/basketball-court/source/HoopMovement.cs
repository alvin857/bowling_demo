using UnityEngine;

public class HoopMovement : MonoBehaviour
{
    public Transform hoop;
    public Transform stand;
    public Transform orb;

    public float speed = 3f;
    public float range = 3f;

    private Vector3 hoopStartPos;
    private Vector3 standStartPos;
    private Vector3 orbStartPos;

    void Start()
    {
        if (hoop != null) hoopStartPos = hoop.position;
        if (stand != null) standStartPos = stand.position;
        if (orb != null) orbStartPos = orb.position;
    }

    void Update()
    {
        MoveObject(hoop, hoopStartPos);
        MoveObject(stand, standStartPos);
        MoveObject(orb, orbStartPos);
    }

    void MoveObject(Transform obj, Vector3 startPos)
    {
        if (obj != null)
            obj.position = startPos + new Vector3(0, 0, Mathf.Sin(Time.time * speed) * range);
    }
}