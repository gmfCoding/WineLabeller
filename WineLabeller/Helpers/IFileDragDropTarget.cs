using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineLabeller.Helpers
{
    public interface IFileDragDropTarget
    {
        void OnFileDrop(string[] files);
    }
}
