using UnityEngine;

public class Mat : MonoBehaviour {

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public static Material NewMat( Material mat, Color color ){
        
        var material = new Material( mat );

        material.SetColor( "_TopColor", color );
        material.SetColor( "_EmissionColor", color );

        return material;

    }
    
    public static Color GetColor( Material material ){ return material.GetColor( "_TopColor" ); }

}