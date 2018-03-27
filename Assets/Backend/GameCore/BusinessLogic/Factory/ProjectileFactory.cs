using UnityEngine;
public class ProjectileFactory : MonoBehaviour
{


    public GameObject Create(GameObject bullet, Transform bulletSpawn)
    {
        return Instantiate(
            bullet,
            bulletSpawn.position,
            bulletSpawn.rotation);
    }
}

