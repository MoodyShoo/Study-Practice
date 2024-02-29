using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeWeek02_14
{
    public enum CellStatus
    {
        Healthy,
        Infected,
        Immune
    }

    public class SquareCells : Button
    {
        public int X;
        public int Y;
        public CellStatus status;
        public int immunityCount; // Счетчик иммунитета

        public SquareCells()
        {
            status = CellStatus.Healthy;
        }
    }
}
