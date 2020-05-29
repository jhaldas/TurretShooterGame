using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject target;

    public GameObject bloodSplat;

    public float speed = 20f;

    public float damage = 1f;

    public void Seek(GameObject _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            target.GetComponent<EnemyStats>().TakeDamage(damage);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject blood = Instantiate(bloodSplat, transform.position, transform.rotation);
        Destroy(blood, 0.5f);
        Destroy(gameObject);
    }
}
