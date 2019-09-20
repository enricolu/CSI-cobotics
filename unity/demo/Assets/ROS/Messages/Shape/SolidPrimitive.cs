/*
# Define box, sphere, cylinder, cone 
# All shapes are defined to have their bounding boxes centered around 0,0,0.

uint8 BOX=1
uint8 SPHERE=2
uint8 CYLINDER=3
uint8 CONE=4

# The type of the shape
uint8 type


# The dimensions of the shape
float64[] dimensions

# The meaning of the shape dimensions: each constant defines the index in the 'dimensions' array

# For the BOX type, the X, Y, and Z dimensions are the length of the corresponding
# sides of the box.
uint8 BOX_X=0
uint8 BOX_Y=1
uint8 BOX_Z=2


# For the SPHERE type, only one component is used, and it gives the radius of
# the sphere.
uint8 SPHERE_RADIUS=0


# For the CYLINDER and CONE types, the center line is oriented along
# the Z axis.  Therefore the CYLINDER_HEIGHT (CONE_HEIGHT) component
# of dimensions gives the height of the cylinder (cone).  The
# CYLINDER_RADIUS (CONE_RADIUS) component of dimensions gives the
# radius of the base of the cylinder (cone).  Cone and cylinder
# primitives are defined to be circular. The tip of the cone is
# pointing up, along +Z axis.

uint8 CYLINDER_HEIGHT=0
uint8 CYLINDER_RADIUS=1

uint8 CONE_HEIGHT=0
uint8 CONE_RADIUS=1
*/

using Newtonsoft.Json;
using CSI.ROS.Messages.Standard;

namespace CSI.ROS.Messages.Shape
{
    public class SolidPrimitive : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "shape_msgs/SolidPrimitive";

        public Uint8 BOX;
        public Uint8 SPHERE;
        public Uint8 CYLINDER;
        public Uint8 CONE;
        public Uint8 type;
        public Float64[] dimensions;
        public Uint8 BOX_X;
        public Uint8 BOX_Y;
        public Uint8 BOX_Z;
        public Uint8 SPHERE_RADIUS;
        public Uint8 CYLINDER_HEIGHT;
        public Uint8 CYLINDER_RADIUS;
        public Uint8 CONE_HEIGHT;
        public Uint8 CONE_RADIUS;
        
        public SolidPrimitive()
        {
            BOX = new Uint8();
            SPHERE = new Uint8();
            CYLINDER = new Uint8();
            CONE = new Uint8();
            type = new Uint8();
            dimensions = new Float64[] { };
            BOX_X = new Uint8();
            BOX_Y = new Uint8();
            BOX_Z = new Uint8();
            SPHERE_RADIUS = new Uint8();
            CYLINDER_HEIGHT = new Uint8();
            CYLINDER_RADIUS = new Uint8();
            CONE_HEIGHT = new Uint8();
            CONE_RADIUS = new Uint8();
        }
    }
}

