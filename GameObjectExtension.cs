using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace UnityObjectRetrieval
{

public static class GameObjectExtension
{
    public static TComponent ComponentOrNull<TComponent>( this GameObject gameObject )
        where TComponent : Component
    {
        return gameObject.GetComponent<TComponent>();
    }

    public static TComponent Component<TComponent>( this GameObject gameObject )
        where TComponent : Component
    {
        var c = gameObject.GetComponent<TComponent>();
        if( c == null ) {
            throw new ComponentNotFoundException( typeof( TComponent ) );
        }
        return c;
    }

    public static IEnumerable<TComponent> Components<TComponent>( this GameObject gameObject )
        where TComponent : Component
    {
        return gameObject.GetComponents<TComponent>();
    }
}

}