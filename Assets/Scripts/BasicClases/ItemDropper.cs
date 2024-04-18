using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    [SerializeField] [Range(0, 100)] private int chance;

    public void Drop()
    {
        if (Random.Range(0, 100) > 100 - chance)
        {
            Instantiate(items[Random.Range(0,items.Length)],transform.position,Quaternion.identity);
        }
    }
}
