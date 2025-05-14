using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private GameObject FirePoint;
    [SerializeField] private float ReloadTime;

    private bool canShoot = true;

    private GameObject Player;

    private float angle;


    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }


    private void Update()
    {
        if (!canShoot) return;

        if (Player == null) return;

        angle = Mathf.Atan2(transform.position.y - Player.transform.position.y,
            transform.position.x - Player.transform.position.x) * Mathf.Rad2Deg;

        if (angle < 0 || angle > 180) return;

        canShoot = false;

        var bulletObj = Instantiate(BulletPrefab, FirePoint.transform.position, Quaternion.identity);
        bulletObj.GetComponent<Bullet>().MoveToTarget(Player.transform.position - FirePoint.transform.position, angle);

        StartCoroutine(Reload());
    }


    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(ReloadTime);

        canShoot = true;
    }
}
