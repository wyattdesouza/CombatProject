using UnityEngine;

public class WeaponShooter : MonoBehaviour
{
    private Camera mainCamera;
    private Inventory inventory;

    private void Start()
    {
        GetReferences();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.transform.name);
        }
    }
    
    private void GetReferences()
    {
        mainCamera = Camera.main;
        inventory = GetComponent<Inventory>();
    }
}
