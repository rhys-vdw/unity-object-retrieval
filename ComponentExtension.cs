using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace UnityBasics
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
}

}