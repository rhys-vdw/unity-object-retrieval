using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace UnityBasics
{

public static class Hierarchy
{
    public static IEnumerable<Transform> Children( this Transform transform )
    {
        foreach( Transform child in transform )
        {
            yield return child;
        }
    }

    public static IEnumerable<Transform> Descendants( this Transform transform )
    {
        foreach( var child in transform.Children() )
        {
            yield return child;
            foreach( var descendant in child.Descendants() )
            {
                yield return descendant;
            }
        }
    }

    public static IEnumerable<Transform> Ancestors( this Transform transform )
    {
        while( transform.parent != null )
        {
            transform = transform.parent;
            yield return transform;
        }
    }

    public static IEnumerable<Transform> SelfChildren( this Transform transform )
    {
        return new [] { transform }.Concat( transform.Children() );
    }

    public static IEnumerable<Transform> SelfDescendants( this Transform transform )
    {
        return new [] { transform }.Concat( transform.Descendants() );
    }

    public static IEnumerable<Transform> SelfAncestors( this Transform transform )
    {
        while( transform != null )
        {
            yield return transform;
            transform = transform.parent;
        }
    }
}

}