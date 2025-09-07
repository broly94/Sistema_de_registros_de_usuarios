using Sistema_de_registros_de_usuarios.DAO;
using Sistema_de_registros_de_usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_registros_de_usuarios.Services
{
    internal class ScheduleService
    {

        private readonly ScheduleDao _scheduleDao;

        public ScheduleService(ScheduleDao scheduleDao)
        {
            this._scheduleDao = scheduleDao;
        }

        public void EntryDataTime(Schedule schedule)
        {
            this._scheduleDao.EntryDataTime(schedule);
        }
    }
}
