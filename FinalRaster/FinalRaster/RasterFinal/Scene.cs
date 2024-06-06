using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFinal
{
    public class Scene: ICloneable
    {
        public List<Model> Models;
        public Scene(List<Model> models)
        {
            Models = new List<Model>();
            Models = models;
        }

        public object Clone()
        {
            // Creamos una nueva instancia de Scene
            List<Model> modelsC = new List<Model>();
            foreach (Model model in Models)
            {
                modelsC.Add((Model)model.Clone());
            }
            Scene clone = new Scene(modelsC);

            // Clonamos cada modelo en la lista
            

            return clone;
        }


    }
}
