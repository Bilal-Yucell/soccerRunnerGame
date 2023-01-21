using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {
        //kamera pozisyonu = player pozisyonu;
        Vector3 newPosition = new Vector3( transform.position.x, transform.position.y, offset.z + target.position.z);
        transform.position = newPosition;   
    }
}
