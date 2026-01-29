using UnityEngine;

public class LookMoveTo : MonoBehaviour
{
    public GameObject ground;

    private Transform camera;

    void Start()
    {
        camera = Camera.main.transform;
    }

    void Update()
    {
        Ray ray;
        RaycastHit[] hits;
        GameObject hitObject;

        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100.0f);

        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            hitObject = hit.collider.gameObject;
            if (hitObject == ground)
            {
                transform.position = hit.point;
            }
        }
    }
}
