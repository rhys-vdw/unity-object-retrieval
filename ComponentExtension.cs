using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace UnityObjectRetrieval
{

public static class ComponentExtension
{
    public static TComponent ComponentOrNull<TComponent>( this Component component )
        where TComponent : Component
    {
        return component.GetComponent<TComponent>();
    }

    public static TComponent Component<TComponent>( this Component component )
        where TComponent : Component
    {
        var c = component.GetComponent<TComponent>();
        if( c == null ) {
            throw new ComponentNotFoundException( typeof( TComponent ) );
        }
        return c;
    }

    public static IEnumerable<TComponent> Components<TComponent>( this Component component )
        where TComponent : Component
    {
        return component.GetComponents<TComponent>();
    }

    public static IEnumerable<Transform> Children( this Component component )
    {
        return component.transform.Children();
    }

    public static IEnumerable<Transform> Descendants( this Component component )
    {
        return component.transform.Descendants();
    }

    public static IEnumerable<Transform> Ancestors( this Component component )
    {
        return component.transform.Ancestors();
    }

    public static IEnumerable<Transform> SelfChildren( this Component component )
    {
        return component.transform.SelfChildren();
    }

    public static IEnumerable<Transform> SelfDescendants( this Component component )
    {
       return component.transform.SelfDescendants();
    }

    public static IEnumerable<Transform> SelfAncestors( this Component component )
    {
        return component.transform.SelfAncestors();
    }
}

}