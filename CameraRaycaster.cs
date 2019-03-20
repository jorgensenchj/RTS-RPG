using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRaycaster : MonoBehaviour
{
  
    [SerializeField] Texture2D enemyCursor = null;
    float maxRaycastDepth = 100f; // Hard coded value
    [SerializeField] Vector2 CursorHotspot = new Vector2(0, 0);
    public event OnMouseOverTerrain onMouseOverEnemy;
    public delegate void OnMouseOverTerrain(Enemy enemy);
    Rect screenRectAtStartPlay = new Rect(0, 0, Screen.width, Screen.height);



    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
  //  void Update()
 //   {
       
 //   }

    void Update()
    {
        // Check if pointer is over an interactable UI element
        if (EventSystem.current.IsPointerOverGameObject())
        {
            //implement IU interaction
            PreformRaycasts();
        }
        else
        {
            PreformRaycasts();
            print("TEST");
        }
    }
    void PreformRaycasts()
    {
        if (screenRectAtStartPlay.Contains(Input.mousePosition))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (RayCastForEnemy(ray)) //{ return; }
          
            {
                return;
               
            }
        }
        //Specify layer priorities below
    }
    bool RayCastForEnemy(Ray ray)
    {
        RaycastHit hitInfo;
        Physics.Raycast(ray, out hitInfo, maxRaycastDepth);
        if (hitInfo.transform != null)
        {
            var gameObjectHit = hitInfo.collider.gameObject;
            print("TEST");
            var enemyHit = gameObjectHit.GetComponent<Enemy>();
            if (enemyHit)
            {
                
                Cursor.SetCursor(enemyCursor, CursorHotspot, CursorMode.Auto);
                onMouseOverEnemy(enemyHit);
                return true;
            }
        }
        return false;
    }


}
