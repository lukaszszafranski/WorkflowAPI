using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoardAPI.Models.ProjectsModels;
using AutoMapper;
using BoardAPI.Services;
using Microsoft.Extensions.Logging;
using BoardAPI.Resources;
using BoardAPI.Helpers;

namespace BoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(IProjectService projectService, IMapper mapper, ILogger<ProjectsController> logger)
        {
            _projectService = projectService;
            _mapper = mapper;
            _logger = logger;
            _logger.LogDebug("NLog injected in ProjectsController");
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<IEnumerable<ProjectResource>> GetProjects()
        {
            var ProjectData = await _projectService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(ProjectData);

            return resources;
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            var ProjectData = await _projectService.FindByIDAsync(id);

            if (!_projectService.SpecificProjectDataExists(id))
            {
                return NotFound();
            }

            return Ok(ProjectData);
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public IActionResult PutProject([FromRoute] int id, [FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            if (id != project.ProjectID)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            // map model to entity and set id
            var editProject = _mapper.Map<Project>(project);
            editProject.ProjectID = id;

            try
            {
                // update project 
                _projectService.Update(editProject);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<IActionResult> PostProject([FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            var result = _projectService.SaveAsync(project);

            if (!result.Result.Success)
            {
                return BadRequest(result.Result.Message);
            }

            return await System.Threading.Tasks.Task.Run(() => Ok(_mapper.Map<Project, ProjectResource>(result.Result._project)));
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            var result = await _projectService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var projectResource = _mapper.Map<Project, ProjectResource>(result._project);

            return Ok(projectResource);
        }
    }
}