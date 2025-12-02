using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.DTO.Responses;
using HealthCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.BLL.Services.Classes
{
    public class DoctorWorkingHoursService: IDoctorWorkingHoursService
    {
        private readonly IDoctorWorkingHoursRepository _doctorWorkingHoursRepository;

        public DoctorWorkingHoursService(IDoctorWorkingHoursRepository doctorWorkingHoursRepository)
        {
            _doctorWorkingHoursRepository = doctorWorkingHoursRepository;
        }

        public async Task<int> AddWorkingHoursAsync(string doctorId, DoctorWorkingHoursRequestDTO request)
        {
            //check if the weekday has workinghours

            if (await HasWorkingHoursAsync(doctorId, request.Weekday))
            { 
                return 0;
            }

                var workingHour = new DoctorWorkingHours
            {
                DoctorId = doctorId,
                Weekday = request.Weekday, 
                StartTime = request.StartTime,
                EndTime = request.EndTime

            };
            return await _doctorWorkingHoursRepository.AddAsync(workingHour);

        }

       

        public async Task<IEnumerable<DoctorWorkingHours>> GetWorkingHoursAsync(string doctorId)
        {
            return await _doctorWorkingHoursRepository.GetWorkingHoursByDoctorAsync(doctorId);
        }

        public async Task<int> UpdateWorkingHoursAsync(int id, DoctorWorkingHoursRequestDTO request)
        {
            var workingHour = await  _doctorWorkingHoursRepository.GetByIdAsyn(id);
            if (workingHour == null)
            {
                return 0;
            }
            workingHour.Weekday = request.Weekday;
            workingHour.StartTime = request.StartTime;
            workingHour.EndTime = request.EndTime;

            return await _doctorWorkingHoursRepository.UpdateAsync(workingHour);
        }

        public async Task<bool> HasWorkingHoursAsync(string doctorId, DayOfWeekEnum weekday)
        {
            var existingWorkingHours = await _doctorWorkingHoursRepository.GetWorkingHoursByDoctorAndDayAsync(doctorId, weekday);
            return existingWorkingHours.Any();
        }
         

    }
}
