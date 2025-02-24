using System.Collections.Generic;
using UnityEngine;

public class BulletManager: MonoBehaviour
{
    private static List<Bullet> activeBullets;

    public static BulletManager s_this;
    [SerializeField] public GameObject[] _bulletPrefabs;
    private static GameObject[] bulletPrefabs;
    [SerializeField] public Transform _bulletField;
    private static Transform bulletField;
    
    private static int[] poolSizes;
    private static Queue<Bullet>[] bulletPools;


    private void Awake()
    {
        if (s_this == null) { s_this = this; }
        else { Destroy(this); }

        activeBullets = new List<Bullet>();
        bulletField = _bulletField;
        bulletPrefabs = _bulletPrefabs;

        int maxIndex = bulletPrefabs.Length;
        poolSizes = new int[maxIndex];
        bulletPools = new Queue<Bullet>[maxIndex];

        for(int i = 0; i < maxIndex; i++)
        {
            poolSizes[i] = 100;
            bulletPools[i] = new Queue<Bullet>();

            GameObject copyObject;
            for (int j = 0; j < 100; j++)
            {
                copyObject = Instantiate(bulletPrefabs[i], bulletField);
                copyObject.SetActive(false);
                bulletPools[i].Enqueue(copyObject.GetComponent<Bullet>());
            }
        }
    }

    public static void ProcessBullets()
    {
        foreach (Bullet bullet in activeBullets) bullet.Move();
    }

    public static Bullet GetBullet(int index)
    {
        Bullet ret;
        if (bulletPools[index].Count > 0)
        {
            ret = bulletPools[index].Dequeue();
            activeBullets.Add(ret);
            return ret;
        }
        else
        {
            poolSizes[index]++;
            ret = Instantiate(bulletPrefabs[index], bulletField).GetComponent<Bullet>();
            activeBullets.Add(ret);
            return ret;
        }
    }
    public static void ReturnBullet(int index, Bullet bullet)
    {
        activeBullets.Remove(bullet);
        bullet.gameObject.SetActive(false);
        bulletPools[index].Enqueue(bullet);
    }
}   
