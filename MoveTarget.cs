using UnityEngine;
using System.Collections;

/// <summary>
/// A simple script to go from a point to another and go back
/// </summary>
public class MoveTarget : MonoBehaviour 
{
    /// <summary>
    /// The starting point
    /// </summary>
    public Vector3 From;
    /// <summary>
    /// The destination point
    /// </summary>
    public Vector3 To;

    /// <summary>
    /// Are we going back?
    /// </summary>
    private bool back = false;

    void Start()
    {
        transform.position = From;    
    }

	void Update () 
    {
        if (!back)
        {
            // Lerp from origin to destination
            transform.position = Vector3.Lerp(transform.position, To, Time.deltaTime);
            // Did we arrived...?
            if (Mathf.Abs((transform.position - To).magnitude) < 1f)
            {
                back = !back; //... Then go back
            }
        }
        else // do the opoposite to go back
        {
            transform.position = Vector3.Lerp(transform.position, From, Time.deltaTime);
            if (Mathf.Abs((transform.position - From).magnitude) < 1f)
            {
                back = !back;
            }
        }
	}
}
