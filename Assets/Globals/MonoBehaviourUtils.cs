using UnityEngine;
public class MonoBehaviourUtils : MonoBehaviour
{
    #region Singleton

    private static MonoBehaviourUtils _instance;

    public static MonoBehaviourUtils Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MonoBehaviourUtils();
            }
            return _instance;
        }
    }

    #endregion

    public GameObject Create(GameObject bullet, Transform bulletSpawn)
    {
        return Instantiate(
            bullet,
            bulletSpawn.position,
            bulletSpawn.rotation);
    }
    
    public GameObject CreateAndThenDestroy(GameObject bullet, Transform bulletSpawn, float lifeSpanTime_s)
    {
        var instantiatedBullet = Instantiate(
            bullet,
            bulletSpawn.position,
            bulletSpawn.rotation);
        
        Destroy(instantiatedBullet, lifeSpanTime_s);

        return instantiatedBullet;
    }

    public GameObject Destroy(GameObject gameObject)
    {
        return Destroy(gameObject);
    }
}

