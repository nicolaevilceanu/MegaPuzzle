using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Puzzle_Vilan_Marius
{
    class Piesa
    {
        public Bitmap _imagine;
        public Rectangle _locatieInceput, _locatieCurenta;

        public Piesa(Bitmap _imagineNoua, Rectangle _locatieInceputNoua)
        {
            _imagine = _imagineNoua;
            _locatieInceput = _locatieInceputNoua;
        }

        public bool Contains (Point _punct)
        {
            return _locatieCurenta.Contains(_punct);
        }

        public bool piesaAproape()
        {
            if ((Math.Abs(+_locatieCurenta.X - _locatieInceput.X)) >= 20 || (Math.Abs(+_locatieCurenta.Y - _locatieInceput.Y)>=20)) return false;
                _locatieCurenta = _locatieInceput;
                return true;
        }

        public bool piesaAcasa()
        {
            return _locatieInceput.Equals(_locatieCurenta);
        }
    }

}
