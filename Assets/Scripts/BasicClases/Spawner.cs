using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab;
    [SerializeField] [Range(0, 100)] float delay;
    [SerializeField] private float safeArea;

    private void Start()
    {
        Invoke(nameof(Spawn),delay);
    }

    void Spawn()
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, safeArea);
        var player = hits.Where(h => h.CompareTag("Player")).Select(h => h.GetComponent<Health>()).FirstOrDefault();
        if (player == null)
        {
            Instantiate(prefab[Random.Range(0,prefab.Length)],transform.position,Quaternion.identity);
        }
        Invoke(nameof(Spawn),delay);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,safeArea);
    }
}