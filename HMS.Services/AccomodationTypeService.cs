using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class AccomodationTypeService
    {
        HMSContext context = new HMSContext();
        public IEnumerable<AccomodationType> GetAllAccomodationTypes()
        {
            return context.AccomodationTypes.ToList();
        }

        public IEnumerable<AccomodationType> SearchccomodationTypes(string searchTerm)
        {
            var accomodationTypes = context.AccomodationTypes.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accomodationTypes = accomodationTypes.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return accomodationTypes.ToList();
        }

        public AccomodationType GetAccomodationTypeById(int id)
        {
            return context.AccomodationTypes.Find(id);
        }

        public bool SaveAccomodationType(AccomodationType accomodationType)
        {
            context.AccomodationTypes.Add(accomodationType);
            return context.SaveChanges() > 0;
        }

        public bool UpdateAccomodationType(AccomodationType accomodationType)
        {
            context.Entry(accomodationType).State = EntityState.Modified;
            return context.SaveChanges() > 0;
        }

        public bool DeleteAccomodationType(AccomodationType accomodationType)
        {
            context.Entry(accomodationType).State = EntityState.Deleted;
            return context.SaveChanges() > 0;
        }
    }
}
