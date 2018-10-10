using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerArtisan
{
    class Command
    {
        public string command;
        public string description;

        public override string ToString()
        {
            return this.command;
        }
    }
}
