using UnityEngine;

public class KillTarget : MonoBehaviour
{
    public GameObject[] targets;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public float timeToSelect = 3.0f;
    public int score;

    Transform camera;
    private float countDown;
    private int targetIndex;

    void Start()
    {
        camera = Camera.main.transform;
        score = 0;
        countDown = timeToSelect;
    }

    void Update()
    {
        bool isHitting = false;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            for (int i = 0; i < targets.Length; i++)
            {
                if(hit.collider.gameObject == targets[i])
                {
                    targetIndex = i;
                    isHitting = true;
                    break;
                }
            }

            //if (hit.collider.gameObject == targets[targetIndex])
            //{
            //    isHitting = true;
            //}
        }

        if (isHitting)
        {
            if (countDown > 0.0f)
            {
                // on target 
                countDown -= Time.deltaTime;
                hitEffect.transform.position = hit.point;
                if (hitEffect.isStopped)
                {
                    hitEffect.Play();
                }
            }
            else
            {
                // killed 
                Instantiate(killEffect, targets[targetIndex].transform.position, targets[targetIndex].transform.rotation);
                score += 1;
                countDown = timeToSelect;
                SetRandomPosition();
            }
        }
        else
        {
            // reset 
            countDown = timeToSelect;
            hitEffect.Stop();
        }
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        targets[targetIndex].transform.position = new Vector3(x, 0.0f, z);
    }
}