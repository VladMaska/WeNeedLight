using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour {

    public GameObject[] points;
    public Material material;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private LineRenderer _lineR;
    private GameObject[] _p;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private void Start(){

        _lineR = this.gameObject.GetComponent<LineRenderer>();

    }

    private void Update(){
        
        if ( _lineR.positionCount != points.Length )
            _lineR.positionCount = points.Length;

        for ( var i = 0; i < points.Length; i++ )
            _lineR.SetPosition( i, points[ i ].transform.position );

    }
    
    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public void SetMaterial() => _lineR.material = material;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public void AddPoint( GameObject point ){

        var p = points.ToList();
        p.Add( point );
        points = p.ToArray();

    }

}