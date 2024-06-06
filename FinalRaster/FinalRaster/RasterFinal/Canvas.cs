using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace RasterFinal
{
    public class Canvas
    {
        static PictureBox pctCanvas;

        Size size;
        Bitmap bitmap;
        public float Width, Height;
        byte[] bits;
        public Graphics g;
        int pixelFormatSize, stride;
        Rectangle rect;
        public int filter, filter2, br, conv;
        public float alpha;
        public float[,] kernel;

        public Canvas(PictureBox pctCanvas)
        {
            Canvas.pctCanvas = pctCanvas;
            this.size = pctCanvas.Size;
            Init(size.Width, size.Height);
            pctCanvas.Image = bitmap;
            filter = 0;
            filter2 = 0;
            br = 0;
            alpha = 0;
            conv = 0;
            kernel = new float[3, 3];

            // Calcular el valor de cada elemento del kernel
            float value = 1.0f / 9.0f;

            // Rellenar el kernel con el valor calculado
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    kernel[i, j] = value;
                }
            }
        }

        private void Init(int width, int height)
        {
            PixelFormat format;
            GCHandle handle;
            IntPtr bitPtr;
            int padding;

            format = PixelFormat.Format32bppArgb;
            Width = width;
            Height = height;
            pixelFormatSize = Image.GetPixelFormatSize(format) / 8; // 8 bits = 1 byte
            stride = width * pixelFormatSize; // total pixels (width) times ARGB (4)
            padding = (stride % 4); // PADD = move every pixel in bytes
            stride += padding == 0 ? 0 : 4 - padding; // 4 byte multiple Alpha, Red, Green, Blue
            bits = new byte[stride * height]; // total pixels (width) times ARGB (4) times Height
            handle = GCHandle.Alloc(bits, GCHandleType.Pinned); // TO LOCK THE MEMORY
            bitPtr = Marshal.UnsafeAddrOfPinnedArrayElement(bits, 0);
            bitmap = new Bitmap(width, height, stride, format, bitPtr);
            g = Graphics.FromImage(bitmap); // Para hacer pruebas regulares}
            rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
        }


        public void DrawPixel(int x, int y, Color c)
        {
            
            int res = (int)((x * pixelFormatSize) + (y * stride));


            bits[res + 0] = c.B;// (byte)Blue;
            bits[res + 1] = c.G;// (byte)Green;
            bits[res + 2] = c.R;// (byte)Red;
            bits[res + 3] = c.A;// (byte)ALPHA;

            

            applyPixelToPixelFilters(res);

        }

        public void applyPixelToPixelFilters(int res)
        {
            int newRed;
            int newBlue;
            int newGreen;

            switch (filter)
            {
                case 1:
                    byte intensity = (byte)((bits[res + 0] + bits[res + 1] + bits[res + 2]) / 3);

                    bits[res + 0] = intensity;// (byte)Blue;
                    bits[res + 1] = intensity;// (byte)Green;
                    bits[res + 2] = intensity;// (byte)Red;
                    break;
                case 2:

                    bits[res + 0] = (byte)(255 - bits[res + 0]);// (byte)Blue;
                    bits[res + 1] = (byte)(255 - bits[res + 1]);// (byte)Green;
                    bits[res + 2] = (byte)(255 - bits[res + 2]);// (byte)Red;
                    break;

                case 3:


                    newRed = (int)((bits[res + 0] * 0.393) + (bits[res + 1] * 0.769) + (bits[res + 2] * 0.189));
                    newGreen = (int)((bits[res + 0] * 0.349) + (bits[res + 1] * 0.686) + (bits[res + 2] * 0.168));
                    newBlue = (int)((bits[res + 0] * 0.272) + (bits[res + 1] * 0.534) + (bits[res + 2] * 0.131));

                    newRed = Math.Min(255, newRed);
                    newGreen = Math.Min(255, newGreen);
                    newBlue = Math.Min(255, newBlue);
                    bits[res + 0] = (byte)newBlue;// (byte)Blue;
                    bits[res + 1] = (byte)newGreen;// (byte)Green;
                    bits[res + 2] = (byte)newRed;// (byte)Red;
                    break;
            }

            switch (filter2)
            {

                case 1:
                    newRed = (int)bits[res + 0] + br;
                    newGreen = (int)bits[res + 1] + br;
                    newBlue = (int)bits[res + 2] + br;
                    newRed = Math.Max(0, Math.Min(255, newRed));
                    newGreen = Math.Max(0, Math.Min(255, newGreen));
                    newBlue = Math.Max(0, Math.Min(255, newBlue));

                    bits[res + 0] = (byte)newBlue;// (byte)Blue;
                    bits[res + 1] = (byte)newGreen;// (byte)Green;
                    bits[res + 2] = (byte)newRed;// (byte)Red;
                    break;
                case 2:

                    newRed = (int)(alpha * ((int)bits[res + 0] - 128) + 128);
                    newGreen = (int)(alpha * ((int)bits[res + 1] - 128) + 128);
                    newBlue = (int)(alpha * ((int)bits[res + 2] - 128) + 128);


                    newRed = Math.Max(0, Math.Min(255, newRed));
                    newGreen = Math.Max(0, Math.Min(255, newGreen));
                    newBlue = Math.Max(0, Math.Min(255, newBlue));

                    bits[res + 0] = (byte)newBlue;// (byte)Blue;
                    bits[res + 1] = (byte)newGreen;// (byte)Green;
                    bits[res + 2] = (byte)newRed;// (byte)Red;
                    break;

            }
        }

        public void pixelConvFilter(int x, int y, float[,] zbuffer, Color[,] colorbuffer)
        {
           
            int inputY;
            int inputX;
            float newRed = 0;
            float newBlue = 0;
            float newGreen = 0;
            int res = (int)((x * pixelFormatSize) + (y * stride));
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    // Coordenadas del vecino
                    inputX = x + xOffset;
                    inputY = y + yOffset;

                    // Acumular solo si el vecino es válido
                    if (checkValidPixel(inputX, inputY, zbuffer))
                    {
                        // Multiplicar el valor del kernel por el componente de color del vecino
                        try {
                            newBlue += colorbuffer[inputX, inputY].B * kernel[yOffset + 1, xOffset + 1];
                            newGreen += colorbuffer[inputX, inputY].G * kernel[yOffset + 1, xOffset + 1];
                            newRed += colorbuffer[inputX, inputY].R * kernel[yOffset + 1, xOffset + 1];
                        }
                        catch (Exception e)
                        {
                            newBlue += 0;
                            newGreen += 0;
                            newRed += 0;
                        }
                        
                    }
                }
            }

            bits[res + 0] = (byte)newBlue;// (byte)Blue;
            bits[res + 1] = (byte)newGreen;// (byte)Green;
            bits[res + 2] = (byte)newRed;// (byte)Red;
            applyPixelToPixelFilters(res);

        }

        public bool checkValidPixel(int inputX, int inputY, float[,] zbuffer)
        {
            return (inputY < zbuffer.GetLength(1) && inputY > 0 && inputX < zbuffer.GetLength(0) && inputX > 0);
        }

        public void applyConvolusionalFilter(float[,] zbuffer,Color[,] colorbuffer)
        {
            if (conv==1)
            {
                for (int x = 0; x < zbuffer.GetLength(0); x++)
                {
                    for (int y = 0; y < zbuffer.GetLength(1); y++)
                    {
                        if (zbuffer[x, y] == float.MaxValue)
                        {
                            continue;
                        }
                        else
                        {
                            pixelConvFilter(x, y, zbuffer, colorbuffer);
                        }
                    }
                }
            }
            
        }
        public void FastClear()
        {
            int div = 16;

            Parallel.For(0, bits.Length / div, i => // unrolling 
            {
                bits[(i * div) + 0] = 0;
                bits[(i * div) + 1] = 0;
                bits[(i * div) + 2] = 0;
                bits[(i * div) + 3] = 0;

                bits[(i * div) + 4] = 0;
                bits[(i * div) + 5] = 0;
                bits[(i * div) + 6] = 0;
                bits[(i * div) + 7] = 0;

                bits[(i * div) + 8] = 0;
                bits[(i * div) + 9] = 0;
                bits[(i * div) + 10] = 0;
                bits[(i * div) + 11] = 0;

                bits[(i * div) + 12] = 0;
                bits[(i * div) + 13] = 0;
                bits[(i * div) + 14] = 0;
                bits[(i * div) + 15] = 0;
            });
        }


    }

   




       
}

