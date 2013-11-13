using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace UnityObjectRetrieval
{

public class ComponentNotFoundException : InvalidOperationException
{
    public ComponentNotFoundException( Type componentType )
        : base( string.Format(
            "Could not find component of type {0}.", componentType )
        )
    { }
}

public static class ComponentEnumerableExtension
{

    // Fully generic extension methods that can't implicitly determine type.

    public static TOut ComponentOrNull<TIn, TOut>( this IEnumerable<TIn> components )
        where TIn : Component
        where TOut : Component
    {
        return components
            .Select( c => c.GetComponent<TOut>() )
            .FirstOrDefault( c => c != null );
    }

    public static TOut Component<TIn, TOut>( this IEnumerable<TIn> components )
        where TIn : Component
        where TOut : Component
    {
        var c = components.ComponentOrNull<TIn, TOut>();
        if( c == null ) {
            throw new ComponentNotFoundException( typeof( TOut ) );
        }
        return c;
    }

    public static IEnumerable<TOut> Components<TIn, TOut>( this IEnumerable<TIn> components )
        where TIn : Component
        where TOut : Component
    {
        return components
            .SelectMany( t => t.GetComponents<TOut>() );
    }

    // Transform

    public static TComponent ComponentOrNull<TComponent>( this IEnumerable<Transform> transforms )
        where TComponent : Component
    {
        return transforms.ComponentOrNull<Transform, TComponent>();
    }

    public static TComponent Component<TComponent>( this IEnumerable<Transform> transforms )
        where TComponent : Component
    {
        return transforms.Component<Transform, TComponent>();
    }

    public static IEnumerable<TComponent> Components<TComponent>( this IEnumerable<Transform> transforms )
        where TComponent : Component
    {
        return transforms.Components<Transform, TComponent>();
    }
}

}