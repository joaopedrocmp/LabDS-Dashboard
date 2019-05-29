using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UabDashboard.Classes
{
    public class PersColors
    {
        Color color { get; set; }
        int id { get; set; }

        public PersColors(Color color, int id)
        {
            this.color = color;
            this.id = id;
        }

        public Color GetColor()
        {
            return this.color;
        }
    }

    public class NewColors
    {
        List<PersColors> colorList { get; set; }

        public NewColors()
        {
            this.colorList.Add(new PersColors(Color.Red, 1));
            this.colorList.Add(new PersColors(Color.Blue, 2));
            this.colorList.Add(new PersColors(Color.Green, 3));
            this.colorList.Add(new PersColors(Color.Yellow, 4));
            this.colorList.Add(new PersColors(Color.Orange, 5));
        }

        public List<PersColors> GetColorList()
        {
            return this.colorList;
        }
    }
}
