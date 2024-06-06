using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFinal
{
    internal class Mtx
    {
        const int x = 0;
        const int y = 1;
        const int z = 2;
        private float[,] Mat;

        public float this[int x, int y]
        {
            get { return Mat[x, y]; }
            set { Mat[x, y] = value; }
        }

        public Mtx(float[,] Mat)
        {
            this.Mat = Mat;
        }

        public Vertex Mul(Vertex vector)
        {
            Vertex pts;
            pts = new Vertex(new float[3]);

            pts[x] = (this[x, x] * vector[x]) + (this[y, x] * vector[y]) + (this[z, x] * vector[z]);
            pts[y] = (this[x, y] * vector[x]) + (this[y, y] * vector[y]) + (this[z, y] * vector[z]);
            pts[z] = (this[x, z] * vector[x]) + (this[y, z] * vector[y]) + (this[z, z] * vector[z]);

            return pts;

        }
    }
}
