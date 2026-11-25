using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed = 2.0f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
