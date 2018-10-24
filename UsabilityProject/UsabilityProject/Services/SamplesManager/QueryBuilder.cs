using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsabilityProject.Model;
namespace UsabilityProject.Services.SamplesManager
{
    public class QueryBuilder
    {
        private IQueryable<Sample> query;
        private SamplesSelectionModel sm;
        public QueryBuilder(SamplesSelectionModel _sm, IQueryable<Sample> _query)
        {
            sm = _sm;
            query = _query;        
        }
        public IQueryable<Sample> getQuery()
        {
            SelectByName();
            SelectByDepartment();
            SelectByStartPulse();
            SelectByEndPulse();
            SelectByStartTemperature();
            SelectByEndTemperature();
            SelectByStartDate();
            SelectByEndDate();
            return query;
        }
        private void SelectByName()
        {            
            if (sm.UserName != null)
            {
                query = query.Where(a => a.User.Name==sm.UserName);
            }
        }
        private void SelectByDepartment()
        {
            if (sm.DepartmentId != null)
            {
                query = query.Where(a => a.User.DepartmentId == sm.DepartmentId);
            }
        }
        private void SelectByRole()
        {
            if (sm.UserRole != null)
            {
                query = query.Where(a => a.User.RoleId == sm.UserRole);
            }
        }
        private void SelectByStartPulse()
        {
            if (sm.StartPulse != null)
            {
                query = query.Where(a => a.Pulse > sm.StartPulse);
            }
        }
        private void SelectByEndPulse()
        {
            if (sm.EndPulse != null)
            {
                query = query.Where(a => a.Pulse < sm.EndPulse);
            }
        }
        private void SelectByStartTemperature()
        {
            if (sm.StartTemperature != null)
            {
                query = query.Where(a => a.Temperature > sm.StartTemperature);
            }
        }
        private void SelectByEndTemperature()
        {
            if (sm.EndTemperature != null)
            {
                query = query.Where(a => a.Temperature < sm.EndTemperature);
            }
        }
        private void SelectByStartDate()
        {                          
            if (sm.StartDate != DateTime.MinValue)
            {
                query = query.Where(a => a.Date > sm.StartDate);
            }
        }
        private void SelectByEndDate()
        {
            if (sm.EndDate != DateTime.MinValue)
            {
                query = query.Where(a => a.Date < sm.EndDate);
            }
        }
    }
}
