/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2020
 */

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
using static BoardAPI.Resources.ProjectResource;

namespace BoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

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

            return Ok(_mapper.Map<Project, ProjectResource>(ProjectData));
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public IActionResult PutProject([FromRoute] int id, [FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            if (_projectService.FindByIDAsync(id).Result == null)
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

        // PUT: api/Projects/5/columns/2
        [HttpPut("{id}/column/{columnID}")]
        public IActionResult PutColumn([FromRoute] int id, [FromRoute] int columnID, [FromBody] Column column)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            if (_projectService.FindByIDAsync(id).Result == null)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            // map model to entity and set id
            var editColumn = _mapper.Map<Column>(column);
            editColumn.ColumnID = columnID;

            try
            {
                // update project 
                _projectService.UpdateColumn(editColumn, columnID, id);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Projects/5/column/2/task/3
        [HttpPut("{id}/column/{columnID}/task/{taskID}")]
        public IActionResult PutTask([FromRoute] int id, [FromRoute] int columnID, [FromRoute] int taskID, [FromBody] Models.ProjectsModels.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            if (_projectService.FindByIDAsync(id).Result == null)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            // map model to entity and set id
            var editTask = _mapper.Map<Models.ProjectsModels.Task>(task);
            editTask.TaskID = taskID;

            try
            {
                // update project 
                _projectService.UpdateTask(editTask, id, columnID, taskID);
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

            var newProject = _mapper.Map<Project>(project);

            newProject.Columns = new List<Column>()
            {
                new Column()
                {
                    ColumnName = "TestColumn",
                    Tasks = new List<Models.ProjectsModels.Task>()
                    {
                        new Models.ProjectsModels.Task()
                        {
                            Name = "TestTask"
                        }
                    }
                }
            };

            var result = _projectService.SaveAsync(newProject);

            if (!result.Result.Success)
            {
                return BadRequest(result.Result.Message);
            }

            return await System.Threading.Tasks.Task.Run(() => Ok(_mapper.Map<Project, ProjectResource>(result.Result._project)));
        }

        // POST: api/Projects/5/add-column
        [HttpPost]
        [Route("{id}/add-column")]
        public async Task<IActionResult> PostColumn([FromBody] Column column, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            var newColumn = _mapper.Map<Column>(column);

            newColumn.Tasks = new List<Models.ProjectsModels.Task>()
            {
                new Models.ProjectsModels.Task()
                {
                    Name = "TestTask"
                }
            };

            var result = _projectService.SaveAsyncColumn(newColumn, id);

            if (!result.Result.Success)
            {
                return BadRequest(result.Result.Message);
            }

            return await System.Threading.Tasks.Task.Run(() => Ok(_mapper.Map<Column, ColumnResource>(result.Result._column)));
        }

        // POST: api/Projects/5/column/2/add-task
        [HttpPost]
        [Route("{ProjectID}/column/{ColumnID}/add-task")]
        public async Task<IActionResult> PostTask([FromBody] Models.ProjectsModels.Task task, int ProjectID, int ColumnID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            var newTask = _mapper.Map<Models.ProjectsModels.Task>(task);

            var result = _projectService.SaveAsyncTask(task, ProjectID, ColumnID);

            if (!result.Result.Success)
            {
                return BadRequest(result.Result.Message);
            }

            return await System.Threading.Tasks.Task.Run(() => Ok(_mapper.Map<Models.ProjectsModels.Task, TaskResource>(result.Result._task)));
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

        // DELETE: api/Projects/5/column/2
        [HttpDelete]
        [Route("{id}/column/{columnID}")]
        public async Task<IActionResult> DeleteColumn([FromRoute] int id, [FromRoute] int columnID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            var result = await _projectService.DeleteColumnAsync(id, columnID);

            if (!result.Message.Contains("Column was removed!"))
            {
                return BadRequest(result.Message);
            }

            var columnResource = _mapper.Map<Column, ColumnResource>(result._column);

            return Ok(columnResource);
        }

        // DELETE: api/Projects/5/column/2/task/1
        [HttpDelete]
        [Route("{id}/column/{columnID}/task/{taskID}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id, [FromRoute] int columnID, [FromRoute] int taskID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            var result = await _projectService.DeleteTaskAsync(id, columnID, taskID);

            if (!result.Message.Contains("Task was removed!"))
            {
                return BadRequest(result.Message);
            }

            var columnResource = _mapper.Map<Models.ProjectsModels.Task, TaskResource>(result._task);

            return Ok(columnResource);
        }
    }
}