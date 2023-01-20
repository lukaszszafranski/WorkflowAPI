/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2023
 */

using BoardAPI.Models.OrganizationsModels;
using BoardAPI.Repositories;
using BoardAPI.Repositories.Domain;
using BoardAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardAPI.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrganizationService(IOrganizationRepository organizationRepository, IUnitOfWork unitOfWork)
        {
            _organizationRepository = organizationRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Organization>> ListAsync()
        {
            return await _organizationRepository.ListAsync();
        }
        public async Task<OrganizationResponse> SaveAsync(Organization organizationData)
        {
            try
            {
                await _organizationRepository.AddAsync(organizationData);
                await _unitOfWork.CompleteAsync();

                return new OrganizationResponse(organizationData);
            }
            catch (Exception ex)
            {
                return new OrganizationResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
        public async Task<Organization> FindByIDAsync(int ID)
        {
            return await _organizationRepository.FindByIDAsync(ID);
        }
        public async Task<OrganizationResponse> DeleteAsync(int ID)
        {
            var existingOrganizationData = await _organizationRepository.FindByIDAsync(ID);

            if (existingOrganizationData == null)
            {
                return new OrganizationResponse("Symbol not found");
            }

            try
            {
                _organizationRepository.Remove(existingOrganizationData);
                await _unitOfWork.CompleteAsync();

                return new OrganizationResponse(existingOrganizationData);
            }
            catch (Exception ex)
            {
                return new OrganizationResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
        public bool IsDbEmpty()
        {
            return _organizationRepository.IsDbEmpty();
        }
        public bool SpecificOrganizationDataExists(int ID)
        {
            return _organizationRepository.SpecificOrganizationDataExists(ID);
        }

        public int CountOfOrganizationData()
        {
            return _organizationRepository.CountOfOrganizationData();
        }
    }
}
