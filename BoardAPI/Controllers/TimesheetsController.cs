using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoardAPI.Data;
using BoardAPI.Models.ProjectsModels;
using AutoMapper;
using BoardAPI.Resources;

namespace WorkflowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetsController : ControllerBase
    {
        private readonly WorkflowAPIContext _context;
        private readonly IMapper _mapper;

        public TimesheetsController(WorkflowAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Timesheets
        [HttpGet]
        public IEnumerable<TimesheetResource> GetTimesheet()
        {
            var resources = _mapper.Map<IEnumerable<Timesheet>, IEnumerable<TimesheetResource>>(_context.Timesheet.Include(x => x.TimesheetDetails));

            foreach (var item in resources)
            {
                foreach (var item2 in item.TimesheetDetails)
                {
                    var otherInfo = _context.TimesheetDetails.First(x => x.TimesheetDetailsID == item2.TimesheetDetailsID);
                    var foundProject = _context.Projects.First(x => x.ProjectID == otherInfo.ProjectID);
                    item2.ProjectTitle = foundProject.Title;
                }
            }

            return resources;
        }

        // GET: api/Timesheets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTimesheet([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timesheet = await System.Threading.Tasks.Task.Run(() => _context.Timesheet.Include(x => x.TimesheetDetails).Where(x => x.TimesheetID == id).AsEnumerable());
            var resource = _mapper.Map<IEnumerable<TimesheetResource>>(timesheet);

            foreach (var item in resource)
            {
                foreach (var item2 in item.TimesheetDetails)
                {
                    var otherInfo = _context.TimesheetDetails.First(x => x.TimesheetDetailsID == item2.TimesheetDetailsID);
                    var foundProject = _context.Projects.First(x => x.ProjectID == otherInfo.ProjectID);
                    item2.ProjectTitle = foundProject.Title;
                }
            }

            if (resource == null)
            {
                return NotFound();
            }

            return Ok(resource);
        }

        //GET: api/Timesheets/status
        [HttpGet]
        [Route("Manager/{timesheetStatus}")]
        public async Task<IActionResult> GetTimesheetsByStatus([FromRoute] string timesheetStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timesheet = await System.Threading.Tasks.Task.Run(() => _context.Timesheet.Include(x => x.TimesheetDetails).Where(x => x.TimesheetStatus == timesheetStatus).AsEnumerable());
            var resources = _mapper.Map<IEnumerable<TimesheetResource>>(timesheet);

            foreach (var item in resources)
            {
                foreach (var item2 in item.TimesheetDetails)
                {
                    var otherInfo = _context.TimesheetDetails.First(x => x.TimesheetDetailsID == item2.TimesheetDetailsID);
                    var foundProject = _context.Projects.First(x => x.ProjectID == otherInfo.ProjectID);
                    item2.ProjectTitle = foundProject.Title;
                }
            }

            if (resources == null)
            {
                return NotFound();
            }

            return Ok(resources.OrderBy(x => x.Year).OrderBy(x => x.Month));
        }

        [HttpGet]
        [Route("Users/{userId}")]
        public async Task<IActionResult> GetTimesheetsByUserId([FromRoute] int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timesheet = await System.Threading.Tasks.Task.Run(() => _context.Timesheet.Include(x => x.TimesheetDetails).Where(x => x.UserId == userId).AsEnumerable());
            var resource = _mapper.Map<IEnumerable<TimesheetResource>>(timesheet);

            foreach (var item in resource)
            {
                foreach (var item2 in item.TimesheetDetails)
                {
                    var otherInfo = _context.TimesheetDetails.First(x => x.TimesheetDetailsID == item2.TimesheetDetailsID);
                    var foundProject = _context.Projects.First(x => x.ProjectID == otherInfo.ProjectID);
                    item2.ProjectTitle = foundProject.Title;
                }
            }

            if (resource == null)
            {
                return NotFound();
            }

            return Ok(resource.OrderBy(x => x.Year).OrderBy(x => x.Month));
        }

        [HttpGet]
        [Route("Manager/Table")]
        public async Task<IActionResult> GetTimesheetsByUserIdWithDifferentStructure()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timesheet = await System.Threading.Tasks.Task.Run(() => _context.Timesheet.Include(x => x.TimesheetDetails).AsEnumerable());
            var resource = _mapper.Map<IEnumerable<ManagerTimesheetResource>>(timesheet);

            foreach (var item in resource)
            {
                var foundUser = _context.Users.Include(x => x.Role).First(x => x.Id == int.Parse(item.userId));
                item.firstName = foundUser.FirstName;
                item.lastName = foundUser.LastName;
                item.role = foundUser.Role.Name;
            }

            if (resource == null)
            {
                return NotFound();
            }

            return Ok(resource.OrderBy(x => x.userId).OrderBy(x => x.Year).OrderBy(x => x.Month));
        }

        [HttpGet]
        [Route("Manager/Chart/Data")]
        public async Task<IActionResult> GetTimesheetsDataForChart()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timesheet = await System.Threading.Tasks.Task.Run(() => _context.Timesheet.Include(x => x.TimesheetDetails).AsEnumerable());
            var resource = _mapper.Map<IEnumerable<ManagerTimesheetResource>>(timesheet);

            var listOfChartData = new List<ChartData>();

            foreach (var item in resource)
            {
                var foundUser = _context.Users.Include(x => x.Role).First(x => x.Id == int.Parse(item.userId));

                var chartData = new ChartData()
                {
                    name = foundUser.FirstName + ' ' + foundUser.LastName,
                    totalRegisteredHours = (int)item.TimesheetDetails.Select(x => x.RegisteredHours).Sum()
                };

                listOfChartData.Add(chartData);
            }

            if (resource == null)
            {
                return NotFound();
            }

            return Ok(listOfChartData.GroupBy(x => x.name).Select(x => new { name = x.Key, value = x.Select(x => x.totalRegisteredHours).Sum() }));
        }

        [HttpGet]
        [Route("User/Chart/Data/{userId}")]
        public async Task<IActionResult> GetTimesheetsDataForChartForUser([FromRoute] string userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timesheet = await System.Threading.Tasks.Task.Run(() => _context.Timesheet.Include(x => x.TimesheetDetails).Where(x => x.UserId == int.Parse(userId)).AsEnumerable());
            var resource = _mapper.Map<IEnumerable<ManagerTimesheetResource>>(timesheet).OrderBy(x => x.Year).OrderBy(x => x.Month);

            var listOfChartData = new List<ChartData>();

            foreach (var item in resource)
            {
                var foundUser = _context.Users.Include(x => x.Role).First(x => x.Id == int.Parse(userId));

                var chartData = new ChartData()
                {
                    name = item.Month.ToString() + "-" +  item.Year.ToString(),
                    totalRegisteredHours = (int)item.TimesheetDetails.Select(x => x.RegisteredHours).Sum()
                };

                listOfChartData.Add(chartData);
            }

            if (resource == null)
            {
                return NotFound();
            }

            return Ok(listOfChartData.GroupBy(x => x.name).Select(x => new { name = x.Key, value = x.Select(x => x.totalRegisteredHours).Sum() }));
        }

        [HttpGet]
        [Route("User/Chart/Data/Project/{userId}")]
        public async Task<IActionResult> GetTimesheetsDataForChartForUserPerProject([FromRoute] string userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timesheet = await System.Threading.Tasks.Task.Run(() => _context.Timesheet.Include(x => x.TimesheetDetails).Where(x => x.UserId == int.Parse(userId)).AsEnumerable());
            var resource = _mapper.Map<IEnumerable<ManagerTimesheetResource>>(timesheet);

            var listOfChartData = new List<ChartData>();

            foreach (var item in resource)
            {
                var foundUser = _context.Users.Include(x => x.Role).First(x => x.Id == int.Parse(userId));
                var foundDetails = _context.TimesheetDetails.Where(x => x.TimesheetID == item.TimesheetID).AsEnumerable().GroupBy(x => x.ProjectID).Select( x => new { ProjectId = x.Key, value = x.Select(x => x.RegisteredHours).Sum() });

                foreach (var item2 in foundDetails)
                {
                    var chartData = new ChartData()
                    {
                        name = foundDetails != null ? _context.Projects.First(x => x.ProjectID == item2.ProjectId).Title : "Brak projektu",
                        totalRegisteredHours = (int)item2.value
                    };

                    listOfChartData.Add(chartData);
                }
            }

            if (resource == null)
            {
                return NotFound();
            }

            return Ok(listOfChartData.GroupBy(x => x.name).Select(x => new { name = x.Key, value = x.Select(x => x.totalRegisteredHours).Sum() }));
        }

        // PUT: api/Timesheets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimesheet([FromRoute] int id, [FromBody] TimesheetResource timesheetResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timesheetResource.TimesheetID)
            {
                return BadRequest();
            }

            var timesheet = _mapper.Map<Timesheet>(timesheetResource);
            timesheet.CreatedOn = DateTime.UtcNow;
            
            _context.Entry(timesheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimesheetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Timesheets
        [HttpPost]
        public async Task<IActionResult> PostTimesheet([FromBody] TimesheetResource timesheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTimesheet = _mapper.Map<Timesheet>(timesheet);

            var foundUser = _context.Users.First(x => x.Id == int.Parse(timesheet.userId));
            newTimesheet.User = foundUser;
            newTimesheet.CreatedOn = DateTime.UtcNow;

            _context.Timesheet.Add(newTimesheet);
            await _context.SaveChangesAsync();

            timesheet.TimesheetID = newTimesheet.TimesheetID;

            return CreatedAtAction("GetTimesheet", new { id = timesheet.TimesheetID }, timesheet);
        }

        // POST: api/Timesheets
        [HttpPost]
        [Route("Details")]
        public async Task<IActionResult> PostTimesheetDetails([FromBody] IEnumerable<TimesheetDetailsResource> timesheetDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wasDeleted = false;

            foreach (var item in timesheetDetails)
            {
                var test = _context.TimesheetDetails.Where(x => x.TimesheetID == item.TimesheetID).AsEnumerable();

                if (wasDeleted == false)
                {
                    _context.TimesheetDetails.RemoveRange(test);
                    wasDeleted = true;
                }

                var newTimesheetDetails = _mapper.Map<TimesheetDetails>(item);

                var foundProject = _context.Projects.First(x => x.Title == item.ProjectTitle);
                newTimesheetDetails.Project = foundProject;
                newTimesheetDetails.ProjectID = foundProject.ProjectID;

                _context.TimesheetDetails.Add(newTimesheetDetails);
                await _context.SaveChangesAsync();
                
                item.TimesheetDetailsID = newTimesheetDetails.TimesheetDetailsID;
            }

            return Ok(timesheetDetails);
        }

        // DELETE: api/Timesheets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimesheet([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timesheet = await _context.Timesheet.FindAsync(id);
            if (timesheet == null)
            {
                return NotFound();
            }

            _context.Timesheet.Remove(timesheet);
            await _context.SaveChangesAsync();

            var resource = _mapper.Map<TimesheetResource>(timesheet);

            return Ok(resource);
        }

        private bool TimesheetExists(int id)
        {
            return _context.Timesheet.Any(e => e.TimesheetID == id);
        }
    }
}