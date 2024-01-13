using UnityEngine;

public class CreateNewPoint : ICPoint {
    
    public GameObject CPoint( Transform line, Line lineScript ){
        
        var point = Resources.Load<GameObject>( "Point" );

        var p = point.GetComponent<Point>();
        p.type = Point.Type.Point;
        p.line = line;
        p.lineScript = lineScript;
        p.color = lineScript.material.GetColor( "_TopColor" );

        return point;
        
    }
    
}

public class CreatePointFromStone : ICPoint {
    
    public GameObject CPoint( Transform line, Line lineScript ){

        var point = Resources.Load<GameObject>( "Point" );

        var p = point.GetComponent<Point>();
        p.type = Point.Type.Point;
        p.line = line;
        p.lineScript = lineScript;
        p.color = lineScript.material.GetColor( "_TopColor" );

        return point;
        
    }
    
}

/*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

public interface ICPoint {
    
    GameObject CPoint( Transform line, Line lineScript );
    
}