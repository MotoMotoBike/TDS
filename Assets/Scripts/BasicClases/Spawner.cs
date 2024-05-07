using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab;
    [SerializeField] private Vector2[] positions;
    [SerializeField] [Range(0, 100)] float delay;
    [SerializeField] [Range(0, 100)] int maxEntities;
    [SerializeField] private float safeArea;

    private List<GameObject> entities = new List<GameObject>();

    private void Start()
    {
        Invoke(nameof(Spawn),delay);
    }

    void Spawn()
    {
        entities.RemoveAll(e=>e == null);
        var posId = UnityEngine.Random.Range(0,positions.Length);
        var hits = Physics2D.OverlapCircleAll(positions[posId], safeArea);
        var player = hits.Where(h => h.CompareTag("Player")).Select(h => h.GetComponent<Health>()).FirstOrDefault();
        if (player == null && entities.Count < maxEntities)
        {
            entities.Add(
                Instantiate(prefab[UnityEngine.Random.Range(0,prefab.Length)],
                positions[posId],
                Quaternion.identity));
        }
        Invoke(nameof(Spawn),delay);
    }

    private void OnDrawGizmosSelected()
    {
        foreach (var pos in positions)
        {
            Gizmos.DrawWireSphere(pos,safeArea);
        }
    }
}