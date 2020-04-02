using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Puzzle_Vilan_Marius
{
    class Functie
    {
        public static Bitmap _imagineIntreaga, _fundal, _margine;
        public static List<Piesa> _piese;
        public static int _tintaDimensiune = 200;
        public static int _nrRand, _nrColoana, _inaltimeRand, _latimeColoana;
        public static Piesa _mutaPiesa;
        public static Point _mutaPunct;
        public static bool _gameOver = true;

        public static void incarcaImaginea(string numefisier,PictureBox imaginePuzzle, Form form)
        {
            try
            {
                using (var bm = new Bitmap(numefisier))
                {
                    _imagineIntreaga = new Bitmap(bm.Width, bm.Height);
                    using(var gr = Graphics.FromImage(_imagineIntreaga))
                    {
                        gr.DrawImage(bm, 0, 0, bm.Width, bm.Height);
                    }
                }
                _fundal = new Bitmap(_imagineIntreaga.Width, _imagineIntreaga.Height);
                _margine = new Bitmap(_imagineIntreaga.Width, _imagineIntreaga.Height);
                imaginePuzzle.Size = _imagineIntreaga.Size;
                imaginePuzzle.Image = _margine;
                form.ClientSize = new Size(imaginePuzzle.Right + imaginePuzzle.Left, imaginePuzzle.Bottom + imaginePuzzle.Left);
                StartGame(imaginePuzzle);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void StartGame(PictureBox imaginePuzzle)
        {
            if (_imagineIntreaga == null) return;
            _gameOver = false;
            _nrRand = _imagineIntreaga.Height / _tintaDimensiune;
            _inaltimeRand = _imagineIntreaga.Height / _nrRand;
            _nrColoana = _imagineIntreaga.Width / _tintaDimensiune;
            _latimeColoana = _imagineIntreaga.Width / _nrColoana;
            var rand = new Random();
            _piese = new List<Piesa>();
            for(int rand1=0; rand1 < _nrRand; rand1++)
            {
                int h = _inaltimeRand;
                if (rand1 == _nrRand - 1)
                    h = _imagineIntreaga.Height - rand1 * _inaltimeRand;
                for(int coloana=0; coloana < _nrColoana; coloana++)
                {
                    int l = _latimeColoana;
                    if (coloana == _nrColoana - 1)
                        l = _imagineIntreaga.Width - coloana * _latimeColoana;
                    var rect = new Rectangle(coloana * _latimeColoana, rand1 * _inaltimeRand, l, h);
                    var piesa_noua = new Piesa(_imagineIntreaga, rect)
                    {
                        _locatieCurenta = new Rectangle(rand.Next(0, _imagineIntreaga.Width - l), rand.Next(0, _imagineIntreaga.Height - h), l, h)
                    };
                    _piese.Add(piesa_noua);
                }
             }
            MakeBackground(imaginePuzzle);
            DrawBoard(imaginePuzzle);
        }

        public static void MakeBackground(PictureBox imaginePuzzle)
        {
            using(var gr = Graphics.FromImage(_fundal))
            {
                gr.Clear(imaginePuzzle.BackColor);
                using(var creionGri=new Pen(Color.DarkGray, 4))
                {
                    for(int y=0; y<= _imagineIntreaga.Height; y+= _inaltimeRand)
                    {
                        gr.DrawLine(creionGri, 0, y, _imagineIntreaga.Width, y);
                    }
                    gr.DrawLine(creionGri, 0, _imagineIntreaga.Height, _imagineIntreaga.Width, _imagineIntreaga.Height);
                    for(int x=0; x <= _imagineIntreaga.Width; x += _latimeColoana)
                    {
                        gr.DrawLine(creionGri, x, 0, x, _imagineIntreaga.Height);
                    }
                    gr.DrawLine(creionGri, _imagineIntreaga.Width, 0, _imagineIntreaga.Width, _imagineIntreaga.Height);
                }
                using(var creionAlb=new Pen(Color.White, 3))
                {
                    using(var creionRed=new Pen(Color.Red, 3))
                    {
                        foreach(var piesa in _piese)
                        {
                            if (piesa == _mutaPiesa) continue;
                            gr.DrawImage(_imagineIntreaga, piesa._locatieCurenta, piesa._locatieInceput, GraphicsUnit.Pixel);
                            if (_gameOver) continue;
                            gr.DrawRectangle(piesa.piesaAcasa() ? creionAlb : creionRed, piesa._locatieCurenta);
                        }
                    }
                }
            }
            imaginePuzzle.Visible = true;
            imaginePuzzle.Refresh();
        }

        public static void DrawBoard(PictureBox imaginePuzzle)
        {
            using (var gr = Graphics.FromImage(_margine))
            {
                gr.DrawImage(_fundal, 0, 0, _fundal.Width, _fundal.Height);
                if (_mutaPiesa != null)
                {
                    gr.DrawImage(_imagineIntreaga, _mutaPiesa._locatieCurenta, _mutaPiesa._locatieInceput, GraphicsUnit.Pixel);
                    using (var creionViolet=new Pen(Color.Magenta, 4))
                    {
                        gr.DrawRectangle(creionViolet, _mutaPiesa._locatieCurenta);
                    }
                }
            }
            imaginePuzzle.Visible = true;
            imaginePuzzle.Refresh();
        }
        public static void Rezolva(PictureBox imaginePuzzle)
        {
            if (_imagineIntreaga == null) return;
            _gameOver = false;
            _nrRand = _imagineIntreaga.Height / _tintaDimensiune;
            _inaltimeRand = _imagineIntreaga.Height / _nrRand;
            _nrColoana = _imagineIntreaga.Width / _tintaDimensiune;
            _latimeColoana = _imagineIntreaga.Width / _nrColoana;
            _piese = new List<Piesa>();
            for (int rand1 = 0; rand1 < _nrRand; rand1++)
            {
                int h = _inaltimeRand;
                if (rand1 == _nrRand - 1)
                    h = _imagineIntreaga.Height - rand1 * _inaltimeRand;
                for (int coloana = 0; coloana < _nrColoana; coloana++)
                {
                    int l = _latimeColoana;
                    if (coloana == _nrColoana - 1)
                        l = _imagineIntreaga.Width - coloana * _latimeColoana;
                    var rect = new Rectangle(coloana * _latimeColoana, rand1 * _inaltimeRand, l, h);
                    var piesa_noua = new Piesa(_imagineIntreaga, rect)
                    {
                        _locatieCurenta = rect
                    };
                    _piese.Add(piesa_noua);
                }
            }
            MakeBackground(imaginePuzzle);
            DrawBoard(imaginePuzzle);
        }
        }
    }

