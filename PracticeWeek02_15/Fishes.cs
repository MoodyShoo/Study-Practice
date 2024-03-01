using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeWeek02_15
{
    public partial class Fishes : Form
    {
        class TFish
        {
            private int _x;
            private int _y;
            private double _speed;
            private string _color;
            private string _direction;

            public void Init()
            {

            }

            public virtual void Draw()
            {

            }

            private void Look(){

            }
            public void Run()
            {

            }
        }

        class Tpike : TFish
        {
            public override void Draw()
            {

            }
        }

        class Tkarp : TFish
        {
            public override void Draw()
            {

            }
        }

        class Taquarium
        {
            public void Init()
            {

            }

            public void Run()
            {

            }

            public void Done()
            {

            }
        }

        public Fishes()
        {
            InitializeComponent();
        }
    }
}
