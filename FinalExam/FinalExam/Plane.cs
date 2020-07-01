using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    public class Plane
    {
        private int _speed;

        public List<TController> controllers;

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        private int _height;

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }
        



        public Plane()
        {
            _name = "Boing 747";
            controllers = new List<TController>();
        }


    }
}
