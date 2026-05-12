using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject prefabBalik; // Eklenmek istenen balýðýn prefab'ý
    public Transform spawnParent;  // Balýklarýn içine ekleneceði obje (opsiyonel)
    public Vector2 spawnMin = new Vector2(-8f, -4f);
    public Vector2 spawnMax = new Vector2(8f, 4f);

    public void BalikEkle()
    {
        Vector2 spawnPos = new Vector2(Random.Range(spawnMin.x, spawnMax.x), Random.Range(spawnMin.y, spawnMax.y));
        GameObject yeniBalik = Instantiate(prefabBalik, spawnPos, Quaternion.identity);

        if (spawnParent != null)
        {
            yeniBalik.transform.SetParent(spawnParent);
        }
    }
}
