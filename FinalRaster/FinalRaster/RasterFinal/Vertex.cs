using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFinal
{
    public class Vertex: ICloneable
    {

        public float X;
        public float Y;
        public float Z;
        public float intensity;
        public float[] Values;

        public float this[int i]
        {
            get { return Values[i]; }
            set { Values[i] = value; }
        }

        public Vertex(float[] values)
        {
            this.Values = values;
            this.X = values[0];
            this.Y = values[1];
            this.Z = values[2];
        }

        public Vertex()
        {

        }//end Vertex
        public float CalculateDistance(Light light)
        {
            int dx = light.x - (int)this.X;
            int dy = light.y - (int)this.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        /*
        public static Vertex operator *(Vertex a, Vertex b)
        {
            return new Vertex(new float[] { a[x] * b[x], a[y] * b[y], a[z] * b[z] });
        }

        public static Vertex operator +(Vertex a, Vertex b)
        {
            return new Vertex(new float[] { a[x] + b[x], a[y] + b[y], a[z] + b[z] });
        }

        public override string ToString()
        {
            return this[x] + ", " + this[y] + ", " + this[z];

        }
        */
        public object Clone()
        {
            return new Vertex(new float[] { this.X, this.Y, this.Z })
            {
                intensity = this.intensity, // Si tienes otros campos en Vertex, asegúrate de copiarlos aquí
                X = this.X,
                Y = this.Y,
                Z = this.Z,
                Values = this.Values
            };
        }
    }
}
