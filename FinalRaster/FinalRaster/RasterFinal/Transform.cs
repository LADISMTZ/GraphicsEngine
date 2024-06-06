using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFinal
{
    public class Transform
    {

        float scale;
        Vertex traslation;
        Vertex rotation;

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        public Vertex Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        public Vertex Translation
        {
            get { return traslation; }
            set { traslation = value; }
        }
        public Transform(float scale, Vertex rotation, Vertex traslation)
        {
            this.scale = scale;
            this.rotation = rotation;
            this.traslation = traslation;

        }
    }
}
