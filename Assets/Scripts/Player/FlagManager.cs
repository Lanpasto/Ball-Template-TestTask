using UnityEngine;
using System.Collections.Generic;

public class FlagManager
{
    private GameObject flagPrefab;
    private List<GameObject> flagCollection = new List<GameObject>();

    public FlagManager(GameObject prefab)
    {
        flagPrefab = prefab;
    }

    public void PutFlag(Vector3 position)
    {
        GameObject flag = Object.Instantiate(flagPrefab, position, Quaternion.identity);
        flagCollection.Add(flag);
    }

    public void RemoveFlagsAtTarget(Vector3 target)
    {
        for (int i = flagCollection.Count - 1; i >= 0; i--)
        {
            if (flagCollection[i] != null && Vector3.Distance(flagCollection[i].transform.position, target) < 0.1f)
            {
                Object.Destroy(flagCollection[i]);
                flagCollection.RemoveAt(i);
            }
        }
    }

    public void RemoveAllFlags()
    {
        foreach (GameObject flag in flagCollection)
        {
            Object.Destroy(flag);
        }
        flagCollection.Clear();
    }
}
