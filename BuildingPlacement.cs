using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour {

    PlaceableBuilding placeableBuilding;
    [SerializeField] Transform currentBuilding;
    bool hasPlaced;
    public LayerMask buildingMask;
    PlaceableBuilding placeableBuildingOld;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentBuilding != null && !hasPlaced)
        {
            Vector3 m = Input.mousePosition;
            m = new Vector3(m.x, m.y, transform.position.y);
            Vector3 p = Camera.main.ScreenToWorldPoint(m);
            currentBuilding.position = new Vector3(p.x, 20, p.z);

            if (Input.GetMouseButtonDown(0))
            {
                if (IsLegalPosition())
                {
                    hasPlaced = true;
                }
            }
        
           else
           
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit = new RaycastHit();
                Ray ray = new Ray(new Vector3(p.x, 8, p.z), Vector3.down);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, buildingMask))
                { 
                    if (placeableBuildingOld != null)
                    {
                        hit.collider.gameObject.GetComponent<PlaceableBuilding>().SetSelected(true);
                        placeableBuildingOld = hit.collider.gameObject.GetComponent<PlaceableBuilding>();
                    }  
                }
                else
                {
                    if(placeableBuildingOld != null)
                    {
                        placeableBuildingOld.SetSelected(false);
                    }
                    
                }
            }
           
        }
    }
    bool IsLegalPosition()
    {
        if(placeableBuilding.colliders.Count > 0)
        {
            return false;
        }
        return true;
    }
    public void SetItem(GameObject b)
    {
        hasPlaced = false;
        currentBuilding = Instantiate(b).transform;
        placeableBuilding = currentBuilding.GetComponent<PlaceableBuilding>();

    }
}
