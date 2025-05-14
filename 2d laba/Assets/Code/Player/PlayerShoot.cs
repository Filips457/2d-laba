using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private float ReloadTime;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private GameObject LaserPrefab;

    private bool canShoot = true;


    private void Update()
    {
        if (Input.GetMouseButton(1) && canShoot)
        {
            canShoot = false;

            Instantiate(LaserPrefab, FirePoint.position, Quaternion.identity);

            StartCoroutine(Reload());
        }
    }


    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(ReloadTime);

        canShoot = true;
    }
}
