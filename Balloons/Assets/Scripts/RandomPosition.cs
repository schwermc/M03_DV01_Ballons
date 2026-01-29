using System.Collections;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    [SerializeField] float distance = 5f;
    [SerializeField] float waitTime = 5f;

    private Transform _position;

    void Start()
    {
        _position = gameObject.transform;
        StartCoroutine(RePositionWithDelay());
    }

    IEnumerator RePositionWithDelay()
    {
        while (true)
        {
            SetRandomPosition();
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-distance, distance);
        float z = Random.Range(-distance, distance);
        transform.position = new Vector3(_position.position.x + x, _position.position.y, _position.position.z + z);
    }
}