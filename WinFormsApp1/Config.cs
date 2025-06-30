using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Config
    {
        public List<string> Fruits { get; set; }
        public List<string> Vegetables { get; set; }
        public int SelectedFruitsIndex { get; set; } = -1; // 기본값은 -1 (선택되지 않음)

    }
}
