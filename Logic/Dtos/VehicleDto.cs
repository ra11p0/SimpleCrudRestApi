using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Dtos
{
    public abstract class VehicleDto
    {
        public ManufacturerDto Manufacturer { get; set; } = new();
        public ModelDto Model { get; set; } = new();
        public string ManufactureYear { get; set; } = String.Empty;
    }
}
