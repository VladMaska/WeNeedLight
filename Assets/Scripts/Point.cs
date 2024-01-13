using UnityEngine;

public class Point : MonoBehaviour {

    public Ray ray;

    public Type type;
    public Transform line;
    public Line lineScript;

    public Color color;
    
    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/
    
    private Material _material;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public enum Type {
        Stone,
        Point
    }
    
    private ICPoint _pointFactory;

    private MeshRenderer _mr;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private void Start(){
        
        ray = FindObjectOfType<Ray>();

        if ( type != Type.Stone ) return;
        
        line = transform.GetChild( 0 );
        lineScript = line.gameObject.GetComponent<Line>();
        
        _mr = this.gameObject.GetComponent<MeshRenderer>();
        
        _material = Mat.NewMat( _mr.material, color );

        _mr.material = _material;

        lineScript.material = _material;
        lineScript.SetMaterial();

    }
    
    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private void OnMouseOver(){
        
        if ( Input.GetMouseButtonDown( 0 ) && type != Type.Stone )
            ray.selectedGO = this.gameObject;

        if ( !Input.GetMouseButtonDown( 1 ) ) return;
        
        if ( type == Type.Stone )
            _pointFactory = new CreatePointFromStone();

        else
            _pointFactory = new CreateNewPoint();
        
        NewPoint();

    }
    
    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private void NewPoint(){
        
        var newPoint = Instantiate( _pointFactory.CPoint( line, lineScript ), ray.pos, Quaternion.identity, line );
        newPoint.name = "Point";

        lineScript.AddPoint( newPoint );
        ray.selectedGO = newPoint;
        
    }
    
    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private void OnMouseUp() => ray.selectedGO = null;

}