using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("General")]
    public float range = 20f;
    private Transform target = null;
    private Enemy targetEnemy;

    [Header("use Bullet(Default)")]
    private float fireCountdown = 0f;
    public float fireRate = 1f;
    public GameObject bulletPrefab;

    [Header("use Laser")]
    public bool WillUseLaser = false;
    public int damageOverTime = 30;
    public LineRenderer lineRenderer;
    public ParticleSystem laserImpactEffect;
    public Light laserImpactLight;
    public float slowAmount = 0.5f;

    [Header("Setup Fields")]
    public float turnSpeed = 10f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.25f);
    }

    void Update()
    {
        if (target == null)
        {
            if(WillUseLaser)
            {
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    laserImpactEffect.Stop();
                    laserImpactLight.enabled = false;
                }
            }
            return;
        }
        LockOnTarget();

        if (WillUseLaser)
        {
            laser();
        }
        else
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1 / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }
    void LockOnTarget()
    {
        Vector3 direction = target.position - this.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void laser()
    {

        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime );
        targetEnemy.Slow(slowAmount);
        if(!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            laserImpactEffect.Play();
            laserImpactLight.enabled = true;
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 laserImpactEffectDirection = firePoint.position - target.position;
        laserImpactEffect.transform.rotation = Quaternion.LookRotation(laserImpactEffectDirection);

        laserImpactEffect.transform.position = target.position + laserImpactEffectDirection.normalized;
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = target.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
