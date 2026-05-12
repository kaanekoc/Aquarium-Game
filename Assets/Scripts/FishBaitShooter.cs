using UnityEngine;

public class FishBaitShooter : MonoBehaviour
{
    public GameObject yemPrefab;        // Atýlacak yem prefabý
    private bool yemModuAktif = false;  // Yem atma modu açýk mý?

    
    void Update()
    {
        // Yem modu aktifse ve mouse'a sol týklanýrsa
        if (yemModuAktif && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(yemPrefab, mousePos, Quaternion.identity);
        }
    }

    // Butona baðlanacak fonksiyon
    public void ToggleYemModu()
    {
        yemModuAktif = !yemModuAktif;  // Aç-kapa modu
        Debug.Log("Yem Modu: " + (yemModuAktif ? "Açýk" : "Kapalý"));
    }
}
