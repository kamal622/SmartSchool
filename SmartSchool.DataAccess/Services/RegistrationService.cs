using SmartSchool.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.DataAccess.Services
{
    public class RegistrationService
    {
        public int Insert(Registration registration)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                dataModel.Registrations.Add(registration);
                dataModel.SaveChanges();
                return registration.Id;
            }

        }
    }
}
