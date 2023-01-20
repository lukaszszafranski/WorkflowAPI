/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2023
 */

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoardAPI.Models.OrganizationsModels;
using BoardAPI.Services;
using AutoMapper;
using Microsoft.Extensions.Logging;
using BoardAPI.Resources;

namespace BoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        private readonly IMapper _mapper;
        private readonly ILogger<OrganizationsController> _logger;

        public OrganizationsController(IOrganizationService organizationService, IMapper mapper, ILogger<OrganizationsController> logger)
        {
            _organizationService = organizationService;
            _mapper = mapper;
            _logger = logger;
            _logger.LogDebug("NLog injected in OrganizationController");
        }

        // GET: api/Organizations
        [HttpGet]
        public async Task<IEnumerable<OrganizationResource>> GetOrganizations()
        {
            var OrganizationData = await _organizationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Organization>, IEnumerable<OrganizationResource>>(OrganizationData);

            return resources;
        }

        // GET: api/Organizations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganization([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            var OrganizationData = await _organizationService.FindByIDAsync(id);

            if (!_organizationService.SpecificOrganizationDataExists(id))
            {
                return NotFound();
            }

            return Ok(OrganizationData);
        }

        // POST: api/Organizations
        [HttpPost]
        public async Task<IActionResult> PostOrganization([FromBody] Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            var result = _organizationService.SaveAsync(organization);

            if (!result.Result.Success)
            {
                return BadRequest(result.Result.Message);
            }

            return await Task.Run(() => Ok(_mapper.Map<Organization, OrganizationResource>(result.Result._organization)));
        }

        // DELETE: api/Organizations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            var result = await _organizationService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var organizationResource = _mapper.Map<Organization, OrganizationResource>(result._organization);

            return Ok(organizationResource);
        }
    }
}