using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dict : MonoBehaviour
{
    public static Dictionary<string, GameObject> mapObject;
    public static Dictionary<string, GameObject> bulletObject;

    [SerializeField] GameObject[] mapObjectPrefab;
    [SerializeField] GameObject[] bulletPrefab;


}
