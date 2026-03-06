using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarTestDataAccessLayer;
using SharedObj;

namespace CarTestLogicalLayer
{
    public class clsCar
    {
        public string CarPlateNumber { get; set; }
        public string CarShassiNumber { get; set; }
        public string CarMakeModel { get; set; }
        public string CarMinufacuringYear { get; set; }
        public string CarColor { get; set; }
        public string CarEnginCapacity { get; set; }

        public bool IsCarValid()
        {
            return !string.IsNullOrWhiteSpace(CarPlateNumber) &&
                   !string.IsNullOrWhiteSpace(CarShassiNumber) &&
                   !string.IsNullOrWhiteSpace(CarMakeModel) &&
                   !string.IsNullOrWhiteSpace(CarMinufacuringYear) &&
                   !string.IsNullOrWhiteSpace(CarColor);
        }

        public clsCar()
        {

            CarPlateNumber = "";
            CarShassiNumber = "";
            CarColor = "";
            CarMakeModel = "";
            CarMinufacuringYear = "";
            CarEnginCapacity = "";

        }

        public clsCar(clsSharedclsCarTest DTO)
        {
            if (DTO == null) throw new ArgumentNullException(nameof(DTO));

            CarPlateNumber = DTO.CarPlateNumber ?? "";
            CarShassiNumber = DTO.CarShassiNumber ?? "";
            CarMakeModel = DTO.CarMakeModel ?? "";
            CarMinufacuringYear = DTO.CarMinufacuringYear ?? "";
            CarColor = DTO.CarColor ?? "";
            CarEnginCapacity = DTO.CarEnginCapacity ?? "";
        }
    }
}
