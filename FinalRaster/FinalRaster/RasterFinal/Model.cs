using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RasterFinal
{
    public class Model: ICloneable
    {

        public Vertex position;

        public Mesh mesh;

        Transform transform;
        public float rotationX;
        public float rotationY;
        public float rotationZ;
        public float scale;
        public Vertex traslation;

        public Model(Mesh mesh, Vertex position)
        {
            this.mesh = mesh;
            this.position = position;
            float[] values = new float[] { 0, 0, 0 };
            transform = new Transform(1, new Vertex(values), new Vertex(values));
            rotationX = rotationY = rotationZ = 0.05f;
            scale = 0;
            traslation = new Vertex(values);

        }
        public object Clone()
        {
            return new Model((Mesh)mesh.Clone(), (Vertex)position.Clone())
            {
                rotationX = this.rotationX,
                rotationY = this.rotationY,
                rotationZ = this.rotationZ,
                scale = this.scale,
                traslation = (Vertex)this.traslation.Clone(),
                transform = this.transform
            };
        }

    }
}
