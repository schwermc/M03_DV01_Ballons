using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour, IMovement
{
    [SerializeField] float updateTime = 1f;
    [SerializeField] GameObject target;

    NavMeshAgent agent;

    public void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("Nav Mesh not found on " + gameObject.name);
            agent = gameObject.AddComponent<NavMeshAgent>();
        }

        StartCoroutine(GoToTarget());
    }

    public IEnumerator GoToTarget()
    {
        while (true)
        {
            agent.destination = target.transform.position;
            yield return new WaitForSeconds(updateTime);
        }
    }
}