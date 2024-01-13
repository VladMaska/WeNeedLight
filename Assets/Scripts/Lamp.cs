using System;
using UnityEngine;

[ExecuteInEditMode]
public class Lamp : MonoBehaviour {

    public Material[] materials;

    public MeshRenderer mr;

    public bool on;
    
    public new Light light;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private Material _m;
    private bool _on;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private void Update(){
        
        if ( !_m )
            _m = new Material( materials[ 1 ] );

    }
    
    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private void On(){

        on = true;
        
        mr.material = _m;
        light.gameObject.SetActive( true );
    
    }

    private void Off(){
        
        on = false;
        
        mr.material = materials[ 0 ];
        light.gameObject.SetActive( false );

    }
    
    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private void OnTriggerEnter( Collider other ){
        
        if ( !other.CompareTag( "Point" ) ) return;
        
        if ( @on ) return;
    
        var p = other.GetComponent<Point>();
        
        _m.SetColor( "_TopColor", p.color );
        _m.SetColor( "_EmissionColor", p.color );
        light.color = p.color;
            
        On();
    
    }
    
    private void OnTriggerExit( Collider other ){
        
        if ( !other.CompareTag( "Point" ) ) return;
        
        var p = other.GetComponent<Point>();
        
        if ( @on && _m.GetColor( "_TopColor" ) == p.color )
            Off();
        
    }

}