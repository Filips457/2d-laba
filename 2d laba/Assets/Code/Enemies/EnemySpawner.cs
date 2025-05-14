using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] EnemiesPrefabs;
    [SerializeField] private GameObject FirstPoint;
    [SerializeField] private GameObject LastPoint;
    [SerializeField] private float SpawnDelay;

    private bool IsReadyToSpawn = true;


    private void Update()
    {
        if (!IsReadyToSpawn) return;

        IsReadyToSpawn = false;

        Vector3 spawnPos = new Vector3(Random.Range(FirstPoint.transform.position.x, LastPoint.transform.position.x),
        FirstPoint.transform.position.y, 0);

        var instObj = Instantiate(EnemiesPrefabs[Random.Range(0, EnemiesPrefabs.Length)], spawnPos, transform.rotation);
        instObj.GetComponent<Rigidbody2D>().linearVelocity = Vector2.down;

        StartCoroutine(SpawnWaiting());
    }


    private IEnumerator SpawnWaiting()
    {
        yield return new WaitForSeconds(SpawnDelay);

        IsReadyToSpawn = true;
    }
}