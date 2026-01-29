using UnityEngine;

public class KeepUpright : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * speed);
    }
}
