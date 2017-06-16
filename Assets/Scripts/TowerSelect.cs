using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGL;

public class TowerSelect : MonoBehaviour
{

    public float pieceHeight = 5f;
    public float rayDistance = 1000f;
    public LayerMask selectionIgnoreLayer;
    public Bullet bulletPrefab;
    public Transform shootPoint;

    bool spawning = true;

    private TowerShoot selectedTower;


    void Start()
    {
        
    }

    // Check if we are selecting a piece
    void CheckSelection()
    {
        // If there is already a selected piece
        if (selectedTower != null)
        {
            return; // Exit the function

        }
        // Creating a ray from camera mouse position to world
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        GizmosGL.color = Color.red;
        GizmosGL.AddLine(ray.origin, ray.origin + ray.direction * rayDistance);
        

        // Check if the player hits the mouse button
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            // Cast a ray to detect
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // Set the selected object to be the hit object
                selectedTower = hit.collider.GetComponent<TowerShoot>();
                // If the user did not hit an object
                if (selectedTower == null)
                {
                    Debug.Log("Cannot pick up object: " + hit.collider.name);
                }
            }
        }
    }

    // Move the selected piece if one is selected
    void MoveSelection()
    {
        // Check if a place has been selected
        if (selectedTower != null)
        {
            // Create a new ray from the camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            GizmosGL.color = Color.yellow;
            GizmosGL.AddLine(ray.origin, ray.origin + ray.direction * rayDistance, 0.1f, 0.1f);
            RaycastHit hit;
            Vector3 hitPoint = Vector3.zero;
            // Raycast to only hit objects that aren't towers
            if (Physics.Raycast(ray, out hit, rayDistance, ~selectionIgnoreLayer))
            {
                // Obtain the hit point
                GizmosGL.color = Color.blue;
                GizmosGL.AddSphere(hit.point, 0.5f);
                hitPoint = hit.point;
                // Move the tower to position
                Vector3 piecePos = hit.point + Vector3.up * pieceHeight;
                selectedTower.transform.position = piecePos;
                
            }

            // Check if mouse button is released
            if (Input.GetMouseButtonUp(0))
            {
                
                // Drop the piece on hitPoint
                selectedTower.transform.position = hitPoint;

                // Deselect the piece
                selectedTower = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckSelection();
        MoveSelection();
    }
}
