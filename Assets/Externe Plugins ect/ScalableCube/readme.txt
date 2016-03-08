ScalableCube � Sascha Graeff

This script makes it possible to create "Scalable Cubes"
that update their unique UVs when their scale is updated.
This allows scene designers to create lots of walls, floors or ceilings
using the same material without having them displayed stretched.
Without this script, you'd need to copy the Material and change the tiling settings.

INSTRUCTIONS:
Simply use GameObject >> Create Other >> Scalable Cube [or Scalable Plane] to create a new Scalable Cube [or Plane].
Then add a Material and resize it.
To change the scale of the Material on the cube, use the "Uv Per Meter" property of the ScalableCube script.

The Scalable Plane has a property named "Additional Texture Names".
Add the Names of Texture Properties to this array to make sure they're scaled along with the other textures.
_MainTex (aka Diffuse) and _BumpMap (aka Normal Map) are automatically scaled.

CHANGES AND FIXES:

    1.1
        Added ScalablePlane.

    1.2
        Using sharedMesh now to remove mesh leak warnings.
        Properly setting mesh name now.