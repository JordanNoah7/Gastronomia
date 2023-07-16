using System;
using System.Collections.Generic;
using DAL;
using ML;

namespace BLL
{
    public class UnitMeasureService
    {
        private readonly UnitMeasureRepository _unitMeasureRepository = new UnitMeasureRepository();

        public List<UnitMeasure> GetUnitMeasures()
        {
            try
            {
                return _unitMeasureRepository.GetUnitMeasures();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}