using System;
using UnityEngine;

public class Ray : MonoBehaviour {
    
    public GameObject selectedGO;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public Vector3 pos;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private void Update(){
        
        var ray = Camera.main.ScreenPointToRay( Input.mousePosition );

        if ( Physics.Raycast( ray, out var hit ) )
            pos = hit.point;

        pos.y = 0.5f;
        
        if ( selectedGO )
            selectedGO.transform.position = pos;

    }

    private void OnMouseDown(){
        
        if ( selectedGO )
            selectedGO = null;
        
    }
    
}