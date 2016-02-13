﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using TpFinalTDP2015.Service;
using TpFinalTDP2015.Service.Controllers;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Service.Enum;

namespace TpFinalTDP2015.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"App.config");
            AutoMapperConfigurations.Configure();


            DateIntervalController lController = new DateIntervalController();

            IList<DateIntervalDTO> lList = lController.GetDateIntervals();

            DateIntervalDTO lDto = lList.Where(dto => dto.Id == 3).FirstOrDefault();

            lDto.Days.Clear();

            lDto.Days.Add(Days.Domingo);
            lDto.Days.Add(Days.Lunes);
            lDto.Days.Add(Days.Martes);
            lDto.Days.Add(Days.Miercoles);
            lDto.Days.Add(Days.Jueves);
            lDto.Days.Add(Days.Viernes);

            lDto.Name = "xDD";

            var tii = lDto.ActiveHours.Where(ti => ti.Id ==22).Single();
           tii.EndTime = new TimeSpan(13, 0, 0);
           // tii.CreationDate = new DateTime(2050, 07, 11, 12, 0, 0);
            lDto.ActiveHours.Remove(lDto.ActiveHours.Where(ti => ti.Id ==23).Single());
            lDto.ActiveHours.Add(new TimeIntervalDTO()
            {
                EndTime = new TimeSpan(17, 0, 0),
                StartTime = new TimeSpan(13, 0, 0)
            });

           // lDto.Id = 0;

            lController.SaveDateInterval(lDto);





           /* Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ModoAdministrador());*/
        }
    }
}
